using System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
using System.Data;
using RestSharp;
using System.Windows.Forms;

namespace TagProcess
{
    public class Participant
    {
        public int id;
        public int competition_id; // don't care
        public int group_id;
        public string race_id;
        public string tag_id;
        public string name;
        public DateTime birth;
        public int male;
        public string address;
        public string zipcode;
        public string phone;

        public string male_s
        {
            get
            {
                switch (male)
                {
                    case 0:
                        return "男";
                    case 1:
                        return "女";
                    default:
                        return "無";
                }
            }
            set
            {
                switch (value)
                {
                    case "男":
                        if (male != 0) is_dirty = true;
                        male = 0;
                        break;
                    case "女":
                        if (male != 1) is_dirty = true;
                        male = 1;
                        break;
                    default:
                        if (male == 1 || male == 0) is_dirty = true;
                        male = 2;
                        break;
                }
            }
        }

        public int age
        {
            get
            {
                // Save today's date.
                var today = DateTime.Today;
                // Calculate the age.
                var age = today.Year - birth.Year;
                // Go back to the year the person was born in case of a leap year
                if (birth > today.AddYears(-age)) age--;

                return age;
            }
            private set { }
        }

        bool is_dirty;

        Participant()
        {
            is_dirty = false;
        }

    }

    /// <summary>
    /// 與參賽選手相關資料的處理
    /// </summary>
    public partial class Core
    {
        public List<Participant> participants;
        /// <summary>
        /// 從伺服器撈取目前進行中活動的選手清單，blocking IO
        /// JSON格式
        /// </summary>
        /// <returns></returns>
        public bool loadParticipants()
        {
            RestClient client = new RestClient(serverUrl);
            RestRequest request = new RestRequest("participants/current", Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.ErrorException != null || response.ResponseStatus != ResponseStatus.Completed)
            {
                MessageBox.Show("連線伺服器失敗，請重試: " + response.ErrorMessage);
                return false;
            }

            if (response.StatusCode != HttpStatusCode.OK || response.Content == "")
            {
                msgCallback(0, "HTTP NOT OK: " + response.StatusCode);
                return false;
            }

            participants = JsonConvert.DeserializeObject<List<Participant>>(response.Content);

            return true;
        }
    }
}
