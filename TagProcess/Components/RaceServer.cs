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
        private int competition_id = -5;
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

        /// <summary>
        /// 選單設定伺服器網址 return連線結果
        /// </summary>
        /// <param name="url">網址</param>
        public bool SetServerUrl(string url)
        {
            serverUrl = url;
            competition_id = -5;
            var response = ExecuteHttpRequest(new RestRequest("competitions/current", Method.GET));
            if (response == null)
            {
                OnLog("連線失敗");
                return false;
            }

            try
            {
                JObject result = JsonConvert.DeserializeObject<JObject>(response.Content);
                int id = (int)result["id"];
                string name = (string)result["name"];

                if(id < 0)
                {
                    OnLog("警告： 目前無啟用中活動");
                    return false;
                }
                else
                {
                    competition_id = id;
                    OnLog("成功： 目前進行中活動[" + name + "]");
                    this.name = name;
                    return true;
                }
            }
            catch (Exception e)
            {
                OnLog("Json解析錯誤: " + e.Message);
                return false;
            }
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
