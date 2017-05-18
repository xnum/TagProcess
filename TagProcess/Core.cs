using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
using System.Data;

namespace TagProcess
{
    public class Core
    {
        private string serverUrl = null;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel = null;
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
            Debug.WriteLine(url);
            WebClient client = new WebClient();
            client.DownloadStringCompleted += (sender, e) =>
            {
                DownloadStringCompletedEventArgs args = (DownloadStringCompletedEventArgs)e;
                if (args.Cancelled || args.Error != null)
                {
                    msgCallback(0, "連線伺服器失敗" + args.Error);
                    return;
                }

                string response = args.Result;

                if (response == null)
                {
                    msgCallback(0, "連線伺服器失敗");
                }
                else
                {
                    msgCallback(0, "連線伺服器成功");
                    try
                    {
                        int tmp = Int32.Parse(response);
                        if (tmp < 0)
                        {
                            msgCallback(0, "目前無進行中的活動");
                        }
                        else
                        {
                            msgCallback(0, "成功取得活動id" + tmp);
                            competition_id = tmp;
                        }
                    } catch 
                    {
                        competition_id = -4;
                        msgCallback(0, "活動id解析錯誤，可能是伺服器端問題");
                    }
                }


            };

            client.DownloadStringAsync(new Uri(url + "/competitions/current"));
        }

        /// <summary>
        /// 簡單檢查是否已經設定完成
        /// </summary>
        /// <returns></returns>
        public bool checkServerStatus()
        {
            return competition_id >= 0;
        }

        /// <summary>
        /// 從伺服器撈取目前進行中活動的選手清單
        /// JSON格式
        /// </summary>
        /// <returns></returns>
        public DataSet getParticipants()
        {
            WebClient client = new WebClient();
            string response = client.DownloadString(serverUrl + "/participants/current");
            
            response = @"{'Table1': " + response + @"}";
            Debug.WriteLine(response);
            DataSet res = JsonConvert.DeserializeObject<DataSet>(response);
            return res;
        }
    }
}
