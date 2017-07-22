using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagProcess
{
    public class TimeKeeper
    {
        private static readonly TimeKeeper _instance = new TimeKeeper();
        private TimeKeeper() { }

        public static TimeKeeper Instance { get { return _instance; } }

        public delegate void LogHandler(string msg);
        public event LogHandler Log;

        private Dictionary<string, DateTime> filter = null;
        private Dictionary<string, int> roundCounter = null;
        private List<IPXCmd> uploadList = new List<IPXCmd>();

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
        /// <param name="batch"></param>
        /// <param name="groups_id"></param>
        /// <returns></returns>
        public bool setStartCompetition(int station, int batch, List<int> groups_id)
        {
            RestRequest req = new RestRequest("competitions/batch_start", Method.POST);
            req.AddParameter("station", station);
            req.AddParameter("batch", batch);
            req.AddParameter("groups", JsonConvert.SerializeObject(groups_id));
            req.AddParameter("time", DateTime.Now.ToString(MySqlDateTimeFormat));
            IRestResponse res = server.executeHttpRequest(req);

            if (res == null) return false;

            if (!res.Content.Equals("Ok"))
            {
                OnLog("上傳組別失敗" + res.Content);
                return false;
            }

            filter = new Dictionary<string, DateTime>();
            roundCounter = new Dictionary<string, int>();
            uploadList = new List<IPXCmd>();
            return true;
        }

        /// <summary>
        /// 比賽進行時，上傳Tag資料
        /// </summary>
        /// <param name="force">設為True，表示要強制上傳資料，否則讓程式決定是否上傳</param>
        /// <returns></returns>
        public bool uploadTagData(bool force) 
        {
            if (force == false && uploadList.Count <= 10) // 小於10筆不主動上傳
                return true;

            List<Dictionary<string, string>> payload = new List<Dictionary<string, string>>();
            foreach (var d in uploadList)
            {
                payload.Add(
                    new Dictionary<string, string>() {
                        { "tag_id", d.data },
                        { "time", d.time.ToString(MySqlDateTimeFormat) },
                        { "station_id", d.station_id.ToString() }
                    });
            }

            RestRequest req_for_group = new RestRequest("records", Method.POST);
            req_for_group.AddParameter("tags", JsonConvert.SerializeObject(payload));
            IRestResponse res_for_group = server.executeHttpRequest(req_for_group);

            if (res_for_group == null) return false;

            if (!res_for_group.Content.Equals("Ok"))
            {
                OnLog("上傳組別失敗" + res_for_group.Content);
                return false;
            }

            uploadList.Clear();
            return true;
        }

        public bool addData(int station, IPXCmd data)
        {
            // 檢測是否在五秒內已新增過
            if(filter.ContainsKey(data.data))
            {
                var lastSeenTime = filter[data.data];
                TimeSpan diff = DateTime.Now - lastSeenTime;
                if (diff.TotalSeconds <= 5) return false; // 小於五秒內的資料 即忽略
            }

            filter[data.data] = DateTime.Now;

            int res_station = 1;
            if(station == 0) // 單點模式，用內建的Counter紀錄圈數
            {
                if(roundCounter.ContainsKey(data.data)) // 存在的情況下 將其+1後取出使用
                {
                    res_station = ++roundCounter[data.data];
                }
                else // 不存在的情況下 設為1(=起點)
                {
                    roundCounter[data.data] = 1;
                }
            }
            data.station_id = res_station;
            uploadList.Add(data);
            uploadTagData(false);

            return true;
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
            public int start_batch;
            public DateTime batch_start_time;
        }

        public class RecordResult
        {
            public int code;
            public string msg;
            public Record[] recs;
            public Group group;
            public Dictionary<string, string> p;
        }

        public RecordResult fetchResultByTagOrRace(string tag, string race)
        {
            RestRequest req = new RestRequest("record", Method.GET);
            if (tag != null) req.AddParameter("tag_id", tag);
            else if (race != null) req.AddParameter("race_id", race);
            var res = server.executeHttpRequest(req);
            var obj = JsonConvert.DeserializeObject<RecordResult>(res.Content);
            if (obj.code == 200)
                return obj;
            return null;
        }
    }
}
