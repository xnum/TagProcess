﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TagProcess
{
    class UploadType
    {
        public string tag;
        public DateTime time;
        public int station;
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
        private HashSet<string> uploaded_tag = new HashSet<string>();
        // 待上傳資料
        private List<UploadType> buffered_data = new List<UploadType>();

        protected void OnLog(string msg)
        {
            Log?.Invoke(msg);
        }

        private RaceServer server = RaceServer.Instance;
        private const string MySqlDateTimeFormat = "yyyy/MM/dd HH:mm:ss";
        /// <summary>
        /// 通知伺服器有哪些組別起跑，作為大會起跑時間
        /// </summary>
        /// <param name="station"></param>
        /// <param name="max_round"></param>
        /// <param name="groups_id"></param>
        /// <returns></returns>
        public bool setStartCompetition(int station, List<int> groups_id)
        {
            station_id = station;

            // build table
            foreach (Participant p in ParticipantsRepository.Instance.participants)
            {
                tag_id_to_participant_table[p.tag_id] = p;
            }

            foreach (int id in groups_id)
            {
                group_start_time[id] = DateTime.Now;
            }

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

        /// <summary>
        /// 比賽進行時，上傳Tag資料
        /// </summary>
        /// <param name="force">設為True，表示要強制上傳資料，否則讓程式決定是否上傳</param>
        /// <returns></returns>
        public bool uploadTagData(bool force)
        {
            // 從 tag_store 撈出該上傳的資料
            foreach(KeyValuePair<string, DateTime> tag in tag_store)
            {
                if (uploaded_tag.Contains(tag.Key)) continue;

                DateTime rec_time = tag.Value;
                // 記錄到的資料 比10秒前還早 代表為10秒之前的資料
                if(rec_time <= DateTime.Now.Subtract(TimeSpan.FromSeconds(10)))
                {
                    // addData時已經確認存在
                    Participant p = tag_id_to_participant_table[tag.Key];

                    // 還沒起跑 略過
                    if(group_start_time.ContainsKey(p.group_id) == false)
                    {
                        continue;
                    }

                    DateTime gtime = group_start_time[p.group_id];

                    // 記錄到的時間 比組別起跑時間晚三秒
                    if(rec_time.AddSeconds(3) >= gtime)
                    {
                        uploaded_tag.Add(tag.Key);
                        buffered_data.Add(new UploadType { tag = tag.Key, station = station_id, time = tag.Value });
                    }
                }
            }

            if(buffered_data.Count >= 10 || (force == true && buffered_data.Count >= 1))
            {
                RestRequest req = new RestRequest("api/json/chip_records/batch_create", Method.POST);
                req.AddParameter("tag_data ", JsonConvert.SerializeObject(buffered_data));
                req.AddParameter("activity", server.competition_id);

                buffered_data.Clear();

                IRestResponse res = server.ExecuteHttpRequest(req);

                if (res == null) return false;

                if (!res.Content.Contains("ok"))
                {
                    OnLog("上傳組別失敗" + res.Content);
                    return false;
                }

            }

            return true;
        }

        public bool addData(int station, IPXCmd data)
        {
            if(tag_id_to_participant_table.ContainsKey(data.data) == false)
            {
                OnLog(data.data + "不存在");
                return false;
            }

            Participant p = tag_id_to_participant_table[data.data];

            // 還沒起跑或無資料 存最後一筆
            if(group_start_time.ContainsKey(p.group_id) == false || tag_store.ContainsKey(data.data) == false)
            {
                tag_store[data.data] = data.time;
                return true;
            }

            // 已經起跑 比對已存成績和目前成績 決定是否更新
            // 紀錄時間比群組時間早 才有必要更新
            DateTime group_time = group_start_time[p.group_id];
            if(tag_store[data.data] <= group_time)
            {
                tag_store[data.data] = data.time;
                uploadTagData(false);
                return true;
            }

            return false;
        }

        public int GetTotalP()
        {
            return ParticipantsRepository.Instance.participants.Count;
        }

        public int GetTaggedP()
        {
            return tag_store.Count;
        }

        public int GetUploadP()
        {
            return uploaded_tag.Count - buffered_data.Count;
        }

        public int GetBufferedP()
        {
            return buffered_data.Count;
        }

        public void notifyTimeout()
        {
            uploadTagData(true);
        }

        public class Record
        {
            public int id;
            public string tag_id;
            public string station_id;
            public DateTime time;
        }

        public class Group
        {
            public int id;
            public string name;
            public string reg;
            public string type;

            public DateTime batch_start_time;
        }

        public class RecordResult
        {
            public int code;
            public string msg;
            public Record[] recs;
            public Group group;
            public Dictionary<string, string> p;
            public int overall;
            public int team;

            public bool checkData()
            {
                /*
                textBox_date.Text = DateTime.Now.ToShortDateString();
                textBox_name.Text = res.p["name"];
                textBox_group.Text = res.group.name;
                textBox_batch_start.Text = res.group.batch_start_time.ToLongTimeString();
                textBox_overall_rank.Text = res.overall.ToString();
                textBox_team_rank.Text = res.team.ToString();
                textBox_team_name.Text = res.p["team_name"];
                */

                if (!p.ContainsKey("name") || p["name"] == "")
                {
                    MessageBox.Show("姓名不存在");
                    return false;
                }

                if (!p.ContainsKey("team_name"))
                {
                    MessageBox.Show("團體名稱不存在");
                    return false;
                }

                if (group.name == "")
                {
                    MessageBox.Show("報名組別不存在");
                    return false;
                }

                if (overall <= 0)
                {
                    MessageBox.Show("總排名有誤");
                    return false;
                }

                if (group.batch_start_time.CompareTo(new DateTime(2017, 10, 28)) <= 0)
                {
                    MessageBox.Show("組別[" + group.name + "]起跑時間異常: " + group.batch_start_time.ToString());
                    return false;
                }

                int station_count = 0;
                foreach (var r in recs)
                {
                    switch (r.station_id)
                    {
                        case "1":
                        case "5":
                            station_count += int.Parse(r.station_id);
                            DateTime t = r.time;
                            if (DateTime.Now.AddDays(-15) < t && t < DateTime.Now.AddDays(15))
                            {
                                // 進行第二個確認 給予容忍誤差60秒 (消去起跑時間早於組別起跑的時間誤差)
                                t.AddSeconds(60);
                                if (t.CompareTo(group.batch_start_time) <= 0)
                                {
                                    MessageBox.Show((r.station_id == "1" ? "起點" : "終點") + "時間異常 個別時間[" + r.time + "] 組別起跑時間[" + group.batch_start_time + "]");
                                    return false;
                                }
                                break;
                            }
                            else
                            {
                                MessageBox.Show("站點" + r.station_id + "成績有誤" + t);
                                return false;
                            }
                        default:
                            break;
                    }
                }

                switch (station_count)
                {
                    case 0:
                        MessageBox.Show("缺少起點、終點資訊");
                        return false;
                    case 1:
                        MessageBox.Show("缺少起點資訊");
                        return false;
                    case 5:
                        MessageBox.Show("缺少終點資訊");
                        return false;
                    case 6:
                        break;
                    default:
                        MessageBox.Show("紀錄例外: " + station_count);
                        break;
                }

                return true;
            }
        }

        public RecordResult fetchResultByTagOrRace(string tag, string race)
        {
            RestRequest req = new RestRequest("record", Method.GET);
            if (tag != null) req.AddParameter("tag_id", tag);
            else if (race != null) req.AddParameter("race_id", race);
            var res = server.ExecuteHttpRequest(req);
            var obj = JsonConvert.DeserializeObject<RecordResult>(res.Content);

            if (obj.code == 200)
                return obj;
            else
                MessageBox.Show(obj.msg);
            return null;
        }

        public Dictionary<string, string> fetchStartRecords()
        {
            RestRequest req = new RestRequest("recstart", Method.GET);
            var res = server.ExecuteHttpRequest(req);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(res.Content);
        }
    }
}
