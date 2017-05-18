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
        /* mapping to JSON data */
        public int id; /* PK MUST NOT modify it*/
        public int competition_id; // don't care
        public int group_id; /* modified by __group__ */
        public string race_id; /* TODO: how to modify */

        private string _tag_id = String.Empty;
        public string tag_id
        {
            get { return _tag_id; }
            set
            {
                if (_tag_id == value) return;
                if (_tag_id != String.Empty) is_dirty = true;
                // TODO duplicated check

                _tag_id = value;
            }
        }

        private string _name = String.Empty;
        public string name
        {
            get { return _name; }
            set
            {
                if (_name == value) return;
                if (_name != String.Empty) is_dirty = true;
                _name = value;
            }
        }

        private DateTime _birth = DateTime.MinValue;
        public string birth
        {
            get { return _birth.ToString("yyyy-M-d"); }
            set
            {
                try
                {
                    if (_birth.Equals(DateTime.ParseExact(value, "yyyy-M-d", null))) return;
                    if (!_birth.Equals(DateTime.MinValue)) is_dirty = true;
                    _birth = DateTime.ParseExact(value, "yyyy-M-d", null);
                }
                catch (FormatException e)
                {
                    MessageBox.Show("日期格式錯誤，必須為1970-1-1");
                }
            }
        }

        private string _address = String.Empty;
        public string address
        {
            get { return _address; }
            set
            {
                if (_address == value) return;
                if (_address != String.Empty) is_dirty = true;
                _address = value;
            }
        }

        private string _zipcode = String.Empty;
        public string zipcode
        {
            get { return _zipcode; }
            set
            {
                if (_zipcode == value) return;
                if (_zipcode != String.Empty)is_dirty = true;;
                _zipcode = value;
            }
        }

        private string _phone = String.Empty;
        public string phone
        {
            get { return _phone; }
            set
            {
                if (_phone == value) return;
                if (_phone != String.Empty) is_dirty = true; ;
                _phone = value;
            }
        }

        public int male; /* modified by male_s */

        /* data represetation helper members */
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
                var age = today.Year - _birth.Year;
                // Go back to the year the person was born in case of a leap year
                if (_birth > today.AddYears(-age)) age--;

                return age;
            }
            private set { } /* Not allow change age directly */
        }

        public string group
        {
            get
            {
                return "男1";
            }
            set
            {
                group_id = 0;
                is_dirty = true;
            }
        }

        /* for update data to server */
        private bool is_dirty = false;

        public Participant()
        {
            is_dirty = false;
            _birth = DateTime.MinValue;
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
