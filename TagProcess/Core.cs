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
        public void setServerUrl(string url)
        {
            this.serverUrl = url;
            Debug.WriteLine(serverUrl);
            RestClient client = new RestClient(serverUrl);
            RestRequest request = new RestRequest("competitions/current", Method.GET);
            client.GetAsync(request, (response, handler) => {
                if(response.ErrorException != null || response.ResponseStatus != ResponseStatus.Completed)
                {
                    msgCallback(0, "連線伺服器失敗: " + response.ErrorMessage);
                    return;
                }

                if(response.StatusCode != HttpStatusCode.OK || response.Content == "")
                {
                    msgCallback(0, "HTTP NOT OK: " + response.StatusCode);
                    return;
                }

                try
                {
                    JObject result = JsonConvert.DeserializeObject<JObject>(response.Content);
                    int id = (int)result["id"];
                    string name = (string)result["name"];

                    if(id < 0)
                    {
                        msgCallback(0, "警告： 目前無啟用中活動");
                        return;
                    }
                    else
                    {
                        msgCallback(0, "成功： 目前進行中活動[" + name + "]");
                        competition_id = id;
                    }
                }
                catch (Exception e)
                {
                    msgCallback(0, "Json解析錯誤: " + e.Message);
                    return;
                }
            });
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
