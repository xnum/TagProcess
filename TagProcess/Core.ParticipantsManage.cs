using System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
using System.Data;
using RestSharp;

namespace TagProcess
{
    /// <summary>
    /// 與參賽選手相關資料的處理
    /// </summary>
    public partial class Core
    {
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
