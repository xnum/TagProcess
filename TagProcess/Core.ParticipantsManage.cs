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
    public static class ParticipantHelper
    {
        public static bool isUsedTag(string tag) 
        {
            /* If False were returned, also insert it to used tag sets */
            return false;
        }

        public static void cancelTag(string tag)
        {

        }

        public static string maleIntToString(int male)
        {
            return "";
        }

        public static int maleStringToInt(string male_s)
        {
            return 1;
        }

        public static string groupIntToString(int group_id)
        {
            return "男1";
        }

        public static int groupStringToInt(string group)
        {
            return 1;
        }
    }
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
                if (_tag_id == value) return; // check if is same tag id
                // TODO duplicated check
                if(ParticipantHelper.isUsedTag(value))
                {
                    MessageBox.Show("這個晶片已經被其他選手使用");
                }
                else
                { 
                    is_dirty = true; // decided to use new tag, make it dirty
                    ParticipantHelper.cancelTag(_tag_id); // make old tag unused
                    _tag_id = value; // assign new tag
                }
                
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
            get { return ParticipantHelper.maleIntToString(male); }
            set
            {
                int tmp = ParticipantHelper.maleStringToInt(value);
                if (tmp != male) is_dirty = true;
                male = tmp;
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
            { return ParticipantHelper.groupIntToString(group_id); }
            set
            {
                int tmp = ParticipantHelper.groupStringToInt(value);
                if (tmp != group_id) is_dirty = true;
                group_id = tmp;
            }
        }

        /* for update data to server */
        private bool is_dirty = false;

        public bool needWriteBack()
        {
            return is_dirty;
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
