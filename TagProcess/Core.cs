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
    public partial class Core
    {
        private string serverUrl = null;
        Action<int, string> msgCallback = null;

        private int competition_id = -5;

        public Core(Action<int, string> callback)
        {
            msgCallback = callback;
        }

        /// <summary>
        /// 選單設定伺服器網址
        /// </summary>
        /// <param name="url">網址</param>
        public string setServerUrl(string url)
        {
            this.serverUrl = url;
            competition_id = -5;
            Debug.WriteLine(serverUrl);
            msgCallback(0, "嘗試連線中");
            RestClient client = new RestClient(serverUrl);
            RestRequest request = new RestRequest("competitions/current", Method.GET);
            IRestResponse response = client.Execute(request);
            
            if(response.ErrorException != null || response.ResponseStatus != ResponseStatus.Completed)
            {
                return "連線伺服器失敗: " + url + " / " + response.ErrorMessage;
            }

            if(response.StatusCode != HttpStatusCode.OK || response.Content == "")
            {
                return "HTTP NOT OK: " + response.StatusCode;
            }

            try
            {
                JObject result = JsonConvert.DeserializeObject<JObject>(response.Content);
                int id = (int)result["id"];
                string name = (string)result["name"];

                if(id < 0)
                {
                    return "警告： 目前無啟用中活動";
                }
                else
                {
                    competition_id = id;
                    return "成功： 目前進行中活動[" + name + "]";
                }
            }
            catch (Exception e)
            {
                return "Json解析錯誤: " + e.Message;
            }
            
        }

        /// <summary>
        /// 簡單檢查是否已經設定完成
        /// </summary>
        /// <returns></returns>
        public bool checkServerStatus()
        {
            return competition_id >= 0;
        }


    }
}
