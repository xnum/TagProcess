using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
using System.Data;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace TagProcess
{
    /// <summary>
    /// Http層的RESTful API呼叫wrapper
    /// 幫助處理例外與預先設定Server baseurl
    /// </summary>
    public partial class RaceServer
    {
        private static readonly RaceServer _instance = new RaceServer();

        private string serverUrl = null;
        public int competition_id = -5;
        public string name { get; private set; }

        public delegate void LogHandler(string msg);
        public event LogHandler Log;

        protected void OnLog(string msg)
        {
            Log?.Invoke(msg);
        }

        private RaceServer()
        {

        }

        public static RaceServer Instance { get { return _instance; } }

        /// <summary>
        /// 封裝HttpRequest，並於發生錯誤時回傳null
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IRestResponse ExecuteHttpRequest(RestRequest request)
        {
            if (serverUrl == null) return null;
            OnLog("嘗試連線到: " + serverUrl + "/" + request.Resource);
            RestClient client = new RestClient(serverUrl);
            IRestResponse response = client.Execute(request);

            if (response.ErrorException != null || response.ResponseStatus != ResponseStatus.Completed)
            {
                OnLog("連線伺服器失敗: " + request.Resource + " / " + response.ErrorMessage);
                return null;
            }

            if (response.StatusCode != HttpStatusCode.OK || response.Content == "")
            {
                OnLog("HTTP Error: " + response.StatusCode);
                return null;
            }

            OnLog("成功: " + request.Resource);
            return response;
        }

        public class ActResult
        {
            public string result;
            public List<Dictionary<string, string>> ret;
        }

        public class Activity
        {
            public int id;
            public string name;
            public override string ToString() { return name; }
        }

        public Activity[] GetActivityList()
        {
            var response = ExecuteHttpRequest(new RestRequest("api/json/activity/list", Method.GET));
            if(response == null)
            {
                OnLog("連線失敗");
                return null;
            }

            ActResult result = JsonConvert.DeserializeObject<ActResult>(response.Content);

            //string r = result["result"];
            //List<Dictionary<string, string>> ret = result["ret"];
            List<Activity> retList = new List<Activity>();
            foreach(Dictionary<string, string> obj in result.ret)
            {
                string is_enable = obj["chipEnable"];
                if (is_enable == "true")
                {
                    Activity act = new Activity();
                    act.id = int.Parse(obj["id"]);
                    act.name = obj["name"];
                    retList.Add(act);
                 }
            }

            return retList.ToArray();
        }

        /// <summary>
        /// 選單設定伺服器網址 return連線結果
        /// </summary>
        /// <param name="url">網址</param>
        public bool SetServerUrl(string url)
        {
            serverUrl = url;
            competition_id = -5;
            GetActivityList();
            /*
            var response = ExecuteHttpRequest(new RestRequest("api/json/activity/list", Method.GET));
            if (response == null)
            {
                OnLog("連線失敗");
                return false;
            }
            */

            return true;
        }

        /// <summary>
        /// 簡單檢查是否已經設定完成
        /// </summary>
        /// <returns></returns>
        public bool IsConnected()
        {
            return competition_id >= 0;
        }
    }
}
