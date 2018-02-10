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
        public string reg;
        public string type;
        public DateTime start_time;
    }

    public class ParticipantHelper
    {
        private static List<RaceGroups> groups = new List<RaceGroups>();
        private static HashSet<string> tags = new HashSet<string>();

        /// <summary>
        /// True如果還沒被使用過。False如果已經被使用
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public bool tryAddTag(string tag) 
        {
            if (tag == "") return true;
            return tags.Add(tag);
        }

        public bool isExistsTag(string tag)
        {
            if (tag == "") return false;
            return tags.Contains(tag);
        }

        public void cancelTag(string tag)
        {
            tags.Remove(tag);
        }

        public string maleIntToString(int male)
        {
            string[] table = { "男", "女", "無"};
            return table[male];
        }

        public int maleStringToInt(string male_s)
        {
            if (male_s == "男") return 0;
            if (male_s == "女") return 1;
            return 2;
        }

        public string groupIntToString(int group_id)
        {
            foreach(RaceGroups g in groups)
            {
                if (group_id == g.id) return g.name;
            }

            throw new Exception("Unknown Group ID: " + group_id);
        }

        public int groupStringToInt(string group)
        {
            foreach (RaceGroups g in groups)
            {
                if (group == g.name) return g.id;
            }

            throw new Exception("Unknown Group Name: " + group);
        }

        public List<string> getGroupNames()
        {
            List<string> ret = new List<string>();

            foreach (RaceGroups g in groups)
            {
                ret.Add(g.name);
            }

            return ret;
        }

        public List<RaceGroups> getGroups()
        {
            return groups;
        }

        public void setGroups(List<RaceGroups> g)
        {
            groups = g;
        }

        public void Clear()
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

        private string _team_name = String.Empty;
        public string team_name
        {
            get { return _team_name; }
            set
            {
                if (_team_name == value) return;
                if (_team_name != String.Empty)is_dirty = true;;
                _team_name = value;
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
            get { return ParticipantsRepository.Instance.helper.maleIntToString(male); }
            set
            {
                int tmp = ParticipantsRepository.Instance.helper.maleStringToInt(value);
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
            { return ParticipantsRepository.Instance.helper.groupIntToString(group_id); }
            set
            {
                int tmp = ParticipantsRepository.Instance.helper.groupStringToInt(value);
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
    public class ParticipantsRepository
    {
        private static readonly ParticipantsRepository _instance = new ParticipantsRepository();

        private ParticipantsRepository()
        {
            server = RaceServer.Instance;
            participants = new List<Participant>();

        }

        public static ParticipantsRepository Instance { get { return _instance; } }

        private RaceServer server = null;
        public List<Participant> participants { get; private set; }
        public ParticipantHelper helper = new ParticipantHelper();

        public delegate void LogHandler(string msg);
        public event LogHandler Log;

        protected void OnLog(string msg)
        {
            Log?.Invoke(msg);
        }

        public void Clear()
        {
            helper.Clear();
            participants?.Clear();
        }

        /// <summary>
        /// 從伺服器撈取目前進行中活動的選手清單，blocking IO
        /// JSON格式
        /// </summary>
        /// <returns></returns>
        public bool fetchParticipants()
        {
            Clear();
            var req = new RestRequest("api/json/chip_user/list", Method.GET);
            req.AddParameter("activity", server.competition_id);
            var res_for_parti = server.ExecuteHttpRequest(req);
            if (res_for_parti == null) return false;

            OnLog("Json decoding (participants)");
            var def = new { result = "", ret = new List<Participant>() };
            var r = JsonConvert.DeserializeAnonymousType(res_for_parti.Content, def);
            participants = r.ret;

            foreach (var p in participants)
            {
                helper.tryAddTag(p.tag_id);
            }

            var rg = new RestRequest("api/json/chip_race_group/list", Method.GET);
            rg.AddParameter("activity", server.competition_id);
            var res_for_groups = server.ExecuteHttpRequest(rg);

            if (res_for_groups == null) return false;

            OnLog("Json decoding (groups)");
            var d = new { result = "", ret = new List<RaceGroups>() };
            var g = JsonConvert.DeserializeAnonymousType(res_for_groups.Content, d);
            var groups = g.ret;

            helper.setGroups(groups);

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
        public bool uploadParticipant(Participant p)
        {
            OnLog("開始上傳修改後選手資料，ID = " + p.id);
            RestRequest req_for_parti = new RestRequest("api/json/chip_user/"+p.id+"/edit", Method.PUT);
            //req_for_parti.AddParameter("id", p.id);
            //req_for_parti.AddParameter("group_id", p.group_id);
            req_for_parti.AddParameter("race_id", p.race_id);
            req_for_parti.AddParameter("gender", p.male);
            req_for_parti.AddParameter("tag_id", p.tag_id);
            req_for_parti.AddParameter("name", p.name);
            req_for_parti.AddParameter("birthday", p.birth);
            //req_for_parti.AddParameter("address", p.address);
            req_for_parti.AddParameter("team_name", p.team_name);
            //req_for_parti.AddParameter("phone", p.phone);
            var res_for_parti = server.ExecuteHttpRequest(req_for_parti);

            if (res_for_parti == null) return false;

            //updateResult res = JsonConvert.DeserializeObject<updateResult>(res_for_parti.Content);
            if (!res_for_parti.Content.Contains("ok"))
            {
                OnLog("更新選手資料發生錯誤: " + res_for_parti.Content);
                return false;
            }

            /* 將伺服器UPDATE後的資料，同步回本地物件中 */
            var result_body = p;
            for(int i = 0; i < participants.Count; ++i)
            {
                if(participants[i].id == result_body.id)
                {
                    helper.cancelTag(participants[i].tag_id);
                    helper.tryAddTag(result_body.tag_id);
                    participants[i] = result_body;
                    participants[i].beenWriteBack();
                    return true;
                }
            }

            OnLog("嚴重錯誤： 伺服器傳回了一個不存在的選手");
            return false;
        }

        /// <summary>
        /// 使用於Excel匯入時，將參賽選手資料以及整理好的組別資料上傳到伺服器進行建立
        /// </summary>
        /// <param name="str">Json encode participants data</param>
        /// <param name="groups">Json encode groups data</param>
        /// <returns></returns>
        public bool storeParticipants(string str)
        {          
            RestRequest req = new RestRequest("api/json/chip_user/import", Method.POST);
            req.AddParameter("activity", server.competition_id);
            req.AddParameter("user", str);
            IRestResponse res = server.ExecuteHttpRequest(req);

            if (res == null) return false;

            if (!res.Content.Contains("ok"))
            {
                OnLog("上傳選手失敗: " + res.Content);
                return false;
            }

            return true;
        }

        public bool storeGroups(string str)
        {
            RestRequest req = new RestRequest("api/json/chip_race_group/import", Method.POST);
            req.AddParameter("activity", server.competition_id);
            req.AddParameter("group", str);
            IRestResponse res = server.ExecuteHttpRequest(req);

            if (res == null) return false;

            if (!res.Content.Contains("ok"))
            {
                OnLog("上傳選手失敗: " + res.Content);
                return false;
            }

            return true;
        }

        public Participant findByTag(string tag)
        {
            if(participants != null)
            for(int i = 0; i < participants.Count; ++i)
            {
                if (participants[i].tag_id == tag)
                    return participants[i];
            }
            return null;
        }

        public Participant findByRaceID(string race_id)
        {
            for (int i = 0; i < participants.Count; ++i)
            {
                if (participants[i].race_id == race_id)
                {
                    return participants[i];
                }
            }

            return null;
        }

        public bool updateParticipantName(int id, string name)
        {
            RestRequest req = new RestRequest("participant", Method.PATCH);
            req.AddParameter("id", id);
            req.AddParameter("name", name);
            var res = server.ExecuteHttpRequest(req);

            if (res == null) return false;

            if (!res.Content.Equals("Ok"))
            {
                OnLog("上傳姓名失敗: " + res.Content);
                return false;
            }

            return true;
        }


    }
}
