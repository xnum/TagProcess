using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
using System.Data;
using RestSharp;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace TagProcess
{
    public class RaceGroups
    {
        public int id;
        public string name;
    }

    public static class ParticipantHelper
    {
        private static List<RaceGroups> groups = new List<RaceGroups>();
        private static HashSet<string> tags = new HashSet<string>();

        /// <summary>
        /// True如果還沒被使用過。False如果已經被使用
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static bool tryAddTag(string tag) 
        {
            if (tag == "") return true;
            return tags.Add(tag);
        }

        public static bool isExistsTag(string tag)
        {
            if (tag == "") return false;
            return tags.Contains(tag);
        }

        public static void cancelTag(string tag)
        {
            tags.Remove(tag);
        }

        public static string maleIntToString(int male)
        {
            string[] table = { "男", "女", "無"};
            return table[male];
        }

        public static int maleStringToInt(string male_s)
        {
            if (male_s == "男") return 0;
            if (male_s == "女") return 1;
            return 2;
        }

        public static string groupIntToString(int group_id)
        {
            foreach(RaceGroups g in groups)
            {
                if (group_id == g.id) return g.name;
            }

            throw new Exception("Unknown Group ID: " + group_id);
        }

        public static int groupStringToInt(string group)
        {
            foreach (RaceGroups g in groups)
            {
                if (group == g.name) return g.id;
            }

            throw new Exception("Unknown Group Name: " + group);
        }

        public static List<string> getGroupNames()
        {
            List<string> ret = new List<string>();

            foreach (RaceGroups g in groups)
            {
                ret.Add(g.name);
            }

            return ret;
        }

        internal static void setGroups(List<RaceGroups> g)
        {
            groups = g;
        }

        internal static void Clear()
        {
            tags.Clear();
            groups.Clear();
        }
    }
    public class Participant
    {
        /* mapping to JSON data */
        public int id; /* PK MUST NOT modify it*/

        [JsonIgnore]
        public int competition_id; // don't care
        public int group_id; /* modified by __group__ */
        public string race_id; /* TODO: how to modify */

        private string _tag_id = String.Empty;
        public string tag_id
        {
            get { return _tag_id; }
            set
            {
                if (value == "")
                {
                    _tag_id = "";
                    return;
                }
                if (_tag_id == value) return; // check if is same tag id
                else is_dirty = true;
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
                    MessageBox.Show("日期格式錯誤，必須為1970-1-1" + e.Message);
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
        [JsonIgnore]
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

        [JsonIgnore]
        public string age
        {
            get
            {
                // Save today's date.
                var today = DateTime.Today;
                // Calculate the age.
                var age = today.Year - _birth.Year;
                // Go back to the year the person was born in case of a leap year
                if (_birth > today.AddYears(-age)) age--;

                return age.ToString();
            }
            private set { } /* Not allow change age directly */
        }

        [JsonIgnore]
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

        /// <summary>
        /// 查詢是否需要回寫到伺服器
        /// </summary>
        /// <returns></returns>
        public bool needWriteBack()
        {
            return is_dirty;
        }

        /// <summary>
        /// 回寫成功後呼叫以重設狀態
        /// </summary>
        public void beenWriteBack()
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
            RestRequest req_for_participants = new RestRequest("participants/current", Method.GET);
            IRestResponse res_for_parti = client.Execute(req_for_participants);

            if (res_for_parti.ErrorException != null || res_for_parti.ResponseStatus != ResponseStatus.Completed)
            {
                msgCallback(0, "連線伺服器失敗，請重試: " + res_for_parti.ErrorMessage);
                return false;
            }

            if (res_for_parti.StatusCode != HttpStatusCode.OK || res_for_parti.Content == "")
            {
                msgCallback(0, "HTTP NOT OK: " + res_for_parti.StatusCode);
                return false;
            }

            ParticipantHelper.Clear();
            participants = JsonConvert.DeserializeObject<List<Participant>>(res_for_parti.Content);

            foreach(var p in participants)
            {
                ParticipantHelper.tryAddTag(p.tag_id);
            }

            RestRequest req_for_groups = new RestRequest("race_groups/current", Method.GET);
            IRestResponse res_for_groups = client.Execute(req_for_groups);

            if (res_for_groups.ErrorException != null || res_for_groups.ResponseStatus != ResponseStatus.Completed)
            {
                MessageBox.Show("連線伺服器失敗，請重試: " + res_for_groups.ErrorMessage);
                return false;
            }

            if (res_for_groups.StatusCode != HttpStatusCode.OK || res_for_groups.Content == "")
            {
                msgCallback(0, "HTTP NOT OK: " + res_for_groups.StatusCode);
                return false;
            }

            var groups = JsonConvert.DeserializeObject<List<RaceGroups>>(res_for_groups.Content);
            ParticipantHelper.setGroups(groups);

            return true;
        }

        internal class updateResult
        {
            public string code = String.Empty;
            public Participant p = null;
            public string msg = String.Empty;
        }

        /// <summary>
        /// 將參賽選手資料傳回伺服器進行更新，blocking IO
        /// </summary>
        public bool updateParticipant(Participant p)
        {
            msgCallback(0, "開始上傳修改後選手資料，ID = " + p.id);
            RestClient client = new RestClient(serverUrl);
            RestRequest req_for_parti = new RestRequest("participant", Method.PATCH);
            req_for_parti.AddParameter("id", p.id);
            req_for_parti.AddParameter("group_id", p.group_id);
            req_for_parti.AddParameter("race_id", p.race_id);
            req_for_parti.AddParameter("male", p.male);
            req_for_parti.AddParameter("tag_id", p.tag_id);
            req_for_parti.AddParameter("name", p.name);
            req_for_parti.AddParameter("birth", p.birth);
            req_for_parti.AddParameter("address", p.address);
            req_for_parti.AddParameter("zipcode", p.zipcode);
            req_for_parti.AddParameter("phone", p.phone);
            IRestResponse res_for_parti = client.Execute(req_for_parti);

            if (res_for_parti.ErrorException != null || res_for_parti.ResponseStatus != ResponseStatus.Completed)
            {
                msgCallback(0, "連線伺服器失敗，請重試: " + res_for_parti.ErrorMessage);
                return false;
            }

            if (res_for_parti.StatusCode != HttpStatusCode.OK || res_for_parti.Content == "")
            {
                msgCallback(0, "HTTP NOT OK: " + res_for_parti.StatusCode);
                return false;
            }

            updateResult res = JsonConvert.DeserializeObject<updateResult>(res_for_parti.Content);
            if (res.code != "200")
            {
                MessageBox.Show(res.msg);
                return false;
            }

            /* 將伺服器UPDATE後的資料，同步回本地物件中 */
            var result_body = res.p;
            for(int i = 0; i < participants.Count; ++i)
            {
                if(participants[i].id == result_body.id)
                {
                    ParticipantHelper.cancelTag(participants[i].tag_id);
                    ParticipantHelper.tryAddTag(result_body.tag_id);
                    participants[i] = result_body;
                    participants[i].beenWriteBack();
                    return true;
                }
            }

            MessageBox.Show("嚴重錯誤： 伺服器傳回了一個不存在的選手");
            return false;
        }
    }
}
