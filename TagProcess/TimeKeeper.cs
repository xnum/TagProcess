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
            return true;
        }

        /// <summary>
        /// 比賽進行時，上傳Tag資料
        /// </summary>
        /// <param name="station"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool uploadTagData(int station, List<Cmd> data)
        {
            List<Dictionary<string, string>> payload = new List<Dictionary<string, string>>();
            foreach (var d in data)
            {
                payload.Add(
                    new Dictionary<string, string>() {
                        { "tag_id", d.data },
                        { "time", d.time.ToString(MySqlDateTimeFormat) },
                        { "station_id", station.ToString() }
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
            return true;
        }
    }
}
