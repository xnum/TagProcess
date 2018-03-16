using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagProcess.Components;

namespace TagProcess
{
    class UploadType
    {
        public string tag_id;
        public DateTime time;
        public int station_id;
    }
    public class TimeKeeper
    {
        private static readonly TimeKeeper _instance = new TimeKeeper();
        private TimeKeeper() { }

        public static TimeKeeper Instance { get { return _instance; } }

        public delegate void LogHandler(string msg);
        public event LogHandler Log;

        private int station_id = 0;
        private Dictionary<string, DateTime> tag_store = new Dictionary<string, DateTime>();
        private Dictionary<string, Participant> tag_id_to_participant_table = new Dictionary<string, Participant>();
        private Dictionary<int, DateTime> group_start_time = new Dictionary<int, DateTime>();

        // 包含待上傳資料，防止重複
        private int upload_count = 0;
        private HashSet<string> committed_tag = new HashSet<string>();
        // 待上傳資料
        private List<UploadType> buffered_data = new List<UploadType>();

        // 檢測組別
        private DuplicationChecker gcheck = new DuplicationChecker();

        protected void OnLog(string msg)
        {
            Log?.Invoke(msg);
        }

        private RaceServer server = RaceServer.Instance;
        private const string MySqlDateTimeFormat = "yyyy/MM/dd HH:mm:ss";

        // for test, don't call
        public void Clear()
        {
            tag_store.Clear();
            tag_id_to_participant_table.Clear();
            group_start_time.Clear();
            committed_tag.Clear();
            buffered_data.Clear();
            upload_count = 0;
        }

        public void ClearTagged()
        {
            HashSet<string> removeTags = new HashSet<string>();
            foreach (string key in tag_store.Keys)
            {
                if (committed_tag.Contains(key) == false)
                    removeTags.Add(key);
            }

            foreach (string key in removeTags)
            {
                tag_store.Remove(key);
            }
        }

        public void Init(int n)
        {
            station_id = n;
            // build table
            foreach (Participant p in ParticipantsRepository.Instance.participants)
            {
                tag_id_to_participant_table[p.tag_id] = p;
            }
        }
        /// <summary>
        /// 通知伺服器有哪些組別起跑，作為大會起跑時間
        /// </summary>
        /// <param name="station"></param>
        /// <param name="max_round"></param>
        /// <param name="groups_id"></param>
        /// <returns></returns>
        public bool setStartCompetition(List<int> groups_id)
        {
            foreach (int id in groups_id)
            {
                if (!group_start_time.ContainsKey(id))
                    group_start_time[id] = DateTime.Now;
            }

            gcheck.Set(new HashSet<int>(groups_id));
            
            RestRequest req = new RestRequest("api/json/chip_race_group/batch_start", Method.PUT);
            req.AddParameter("groups", JsonConvert.SerializeObject(groups_id));
            req.AddParameter("time", DateTime.Now.ToString(MySqlDateTimeFormat));
            IRestResponse res = server.ExecuteHttpRequest(req);

            if (res == null) return false;

            if (!res.Content.Contains("ok"))
            {
                OnLog("上傳組別失敗" + res.Content);
                return false;
            }

            return true;
        }

        private void enqueue(string tag, int station, DateTime t)
        {
            committed_tag.Add(tag);
            buffered_data.Add(new UploadType
            {
                tag_id = tag,
                station_id = station,
                time = t
            });
            FileLogger.Instance.log(tag + " ok");
        }

        /// <summary>
        /// 比賽進行時，上傳Tag資料
        /// </summary>
        /// <param name="force">設為True，表示要強制上傳資料，否則讓程式決定是否上傳</param>
        /// <returns></returns>
        public bool uploadTagData(bool force, DateTime? now = null)
        {
            DateTime nowt = now.GetValueOrDefault(DateTime.Now);
            // 從 tag_store 撈出該上傳的資料
            foreach (KeyValuePair<string, DateTime> tag in tag_store)
            {
                if (committed_tag.Contains(tag.Key)) continue;

                DateTime rec_time = tag.Value;
                // 記錄到的資料 比10秒前還早 代表為10秒之前的資料
                if (rec_time <= nowt.Subtract(TimeSpan.FromSeconds(10)))
                {
                    if (station_id == 1)
                    {
                        // addData時已經確認存在
                        Participant p = tag_id_to_participant_table[tag.Key];

                        // 還沒起跑 略過
                        if (group_start_time.ContainsKey(p.group_id) == false)
                        {
                            continue;
                        }

                        DateTime gtime = group_start_time[p.group_id];

                        // 感應時間 - 起跑時間
                        TimeSpan timediff = rec_time.Subtract(gtime);
                        double timediff_sec = timediff.TotalSeconds;
                        if (-3 <= timediff_sec && timediff_sec <= 600)
                        {
                            enqueue(tag.Key, station_id, tag.Value < gtime ? gtime : tag.Value);
                        }
                    }
                    else
                    {
                        enqueue(tag.Key, station_id, tag.Value);
                    }
                }
            }
            
            if (buffered_data.Count >= 10 || (force == true && buffered_data.Count >= 1))
            {
                RestRequest req = new RestRequest("api/json/chip_records/batch_create", Method.POST);
                req.AddParameter("tag_data", JsonConvert.SerializeObject(buffered_data));
                req.AddParameter("activity", server.competition_id);

                var copied_data = buffered_data.ToArray();
                buffered_data.Clear();

                IRestResponse res = server.ExecuteHttpRequest(req);

                if (res == null)
                {
                    OnLog("連線失敗");
                    buffered_data.AddRange(copied_data);
                    return false;
                }

                var def = new { result = "", total = 0, error = new List<Dictionary<string, string>>() };
                var obj = JsonConvert.DeserializeAnonymousType(res.Content, def);

                foreach (var ele in obj.error)
                {
                    OnLog("Error: " + ele["tag_id"] + " " + ele["error"]);
                }

                upload_count += obj.total;
            }

            return true;
        }

        public bool addData(int station, IPXCmd data)
        {
            FileLogger.Instance.logPacket(String.Format("{0}\t{1}\t{2}\t{3}",
                station, data.data, data.time.ToString(), DateTime.Now.ToString()));

            if (tag_id_to_participant_table.ContainsKey(data.data) == false)
            {
                OnLog(data.data + "不存在");
                return false;
            }

            Participant p = tag_id_to_participant_table[data.data];

            if (station != 1)
            {
                if (tag_store.ContainsKey(data.data) == false)
                {
                    OnLog(data.data + " 非起點 update");
                    tag_store[data.data] = data.time;
                    return true;
                }
                else
                    return false;
            }

            // 以下皆為判斷起點資料
            
            bool is_current_group = gcheck.Check(p.group_id, data.data);

            // 還沒起跑
            if (group_start_time.ContainsKey(p.group_id) == false)
            {
                // 時間與上次記錄相異 更新值
                if (tag_store[data.data] != data.time)
                {
                    OnLog(data.data + " 還沒起跑 update");
                    tag_store[data.data] = data.time;
                    return true;
                }

                return false;
            }            
            
            // 以下皆為 起點 + 該組別已起跑
            
            // 尚無資料
            if (tag_store.ContainsKey(data.data) == false)
            {
                // 判斷是否為當前起跑組別
                if (is_current_group == true)
                {               
                    OnLog(data.data + " 尚無資料 update");
                    tag_store[data.data] = data.time;
                    return true;
                }
                
                return false;
            }

            // 以下為 起點 + 該組別已經起跑 + 已經有該選手感應過的資料
            
            // 已經起跑 比對已存成績和目前成績 決定是否更新
            // 紀錄時間比群組時間早 才有必要更新
            DateTime group_time = group_start_time[p.group_id];
            if (tag_store[data.data] <= group_time && tag_store[data.data] != data.time)
            {
                //多加判斷是否為當前組別
                if (false == is_current_group)
                {
                    return false;
                }

                OnLog(data.data + " 已起跑 新成績 update");
                tag_store[data.data] = data.time;
                uploadTagData(false);
                return true;
            }

            return false;
        }

        public int GetTotalCount()
        {
            return ParticipantsRepository.Instance.participants.Count;
        }

        public int GetTagCount()
        {
            return tag_store.Count;
        }

        public int GetUploadedCount()
        {
            return upload_count - buffered_data.Count;
        }

        public int GetBufferedCount()
        {
            return buffered_data.Count;
        }

        public void notifyTimeout()
        {
            uploadTagData(true);
        }

        public class RecordResult
        {
            public int id;
            public string id_number;
            public string name;
            public int male;
            public DateTime birth;
            public string team_name;
            public string tag_id;
            public string race_id;
            public int total_rank;
            public int total_gender_rank;
            public int group_rank;
            public int activity_time;
            public int personal_time;
            public int group_id;
            public string chip_race_group_name;
            public int activity;
            public string reg;
            public string type;
            public DateTime chip_race_group_start_time;
            public DateTime chip_user_start_time;
            public DateTime chip_user_end_time;

            public string checkData()
            {
                // ScoreGenerator裡的Check也要修改

                if (name == "")
                {
                    return "姓名不存在";
                }

                if (chip_race_group_name == "")
                {
                    return "報名組別不存在";
                }

                if (total_rank <= 0)
                {
                    return "總排名有誤";
                }

                if (activity_time <= 0 || personal_time <= 0)
                {
                    return "成績有誤";
                }

                if (chip_user_start_time.CompareTo(new DateTime(2017, 10, 28)) <= 0)
                {
                    return "起點時間異常: " + chip_user_start_time;
                }

                if (chip_user_end_time.CompareTo(new DateTime(2017, 10, 28)) <= 0)
                {
                    return "終點時間異常: " + chip_user_end_time;
                }
                
                return null;
            }
        }

        public RecordResult fetchResultByTagOrRace(string tag, string race)
        {
            try
            {
                RestRequest req = new RestRequest("api/json/chip_user/records", Method.GET);
                req.AddParameter("activity", server.competition_id);
                if (tag != null) req.AddParameter("tag_id", tag);
                else if (race != null) req.AddParameter("race_id", race);
                var res = server.ExecuteHttpRequest(req);

                var def = new { result = "", ret = new RecordResult() };
                var obj = JsonConvert.DeserializeAnonymousType(res.Content, def);

                if (obj.result == "ok")
                {
                    return obj.ret;
                }
                else
                {
                    var redef = new { result = "", msg = "" };
                    var reobj = JsonConvert.DeserializeAnonymousType(res.Content, redef);

                    OnLog(reobj.msg);
                }

                FileLogger.Instance.log("抓取成績錯誤：" + res.Content);
            }
            catch (Exception ex)
            {
                OnLog("伺服器錯誤");
                FileLogger.Instance.log("抓取成績錯誤：" + ex.Message);
                return null;
            }
            return null;
        }

        // 固定時間觸發伺服器工作
        public string triggerServer()
        {
            try
            {
                RestRequest req = new RestRequest("api/json/update_records_time/" + server.competition_id, Method.POST);
                var res = server.ExecuteHttpRequest(req);

                var def = new { result = "", ret = "" };
                var obj = JsonConvert.DeserializeAnonymousType(res.Content, def);

                FileLogger.Instance.log(obj.ret);

                RestRequest req2 = new RestRequest("api/json/update_records_rank/" + server.competition_id, Method.POST);
                var res2 = server.ExecuteHttpRequest(req2);

                var obj2 = JsonConvert.DeserializeAnonymousType(res2.Content, def);

                FileLogger.Instance.log(obj2.ret);

                return obj.ret + "\r\n" + obj2.ret;
            }
            catch(Exception ex)
            {
                OnLog("觸發定時工作錯誤：" + ex.Message);
                return null;
            }
        }

        public Dictionary<string, string> fetchStartRecords()
        {
            try
            {
                RestRequest req = new RestRequest("api/json/chip_records/list", Method.GET);
                req.AddParameter("activity", server.competition_id);
                req.AddParameter("station_id", 1);
                var res = server.ExecuteHttpRequest(req);

                var def = new { result = "", ret = new List<Dictionary<string, string>>() };
                var obj = JsonConvert.DeserializeAnonymousType(res.Content, def);

                Dictionary<string, string> ret = new Dictionary<string, string>();
                foreach (var item in obj.ret)
                {
                    ret[item["tag_id"]] = item["time"];
                }

                return ret;
            }
            catch (Exception ex)
            {
                OnLog("讀取起點時間錯誤：" + ex.Message);
                return null;
            }
        }
    }
}
