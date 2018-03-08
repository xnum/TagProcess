using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TagProcess.Components
{
    class ActivityCountHelper
    {
        public class GroupCount
        {
            public int group_count = 0;
            public int class_count = 0;
            public int class_boy_count = 0;
            public int class_girl_count = 0;
        }

        private static Dictionary<int, GroupCount> list = null;
        private static RaceServer server = RaceServer.Instance;

        private static void fetchGroupCounts()
        {
            if (list == null)
            {
                RestRequest req = new RestRequest("api/json/chip_race_group/"+server.competition_id+"/count/list", Method.GET);

                var res = server.ExecuteHttpRequest(req);

                var def = new { result = "", ret = new Dictionary<int, GroupCount>() };
                var obj = JsonConvert.DeserializeAnonymousType(res.Content, def);

                if (obj.result == "ok")
                {
                    list = obj.ret;
                }
                else
                    FileLogger.Instance.log(obj.result);
                return;
            }

            return;
        }

        public static int getGroupCount(int key)
        {
            fetchGroupCounts();
            if (list.ContainsKey(key))
                return list[key].group_count;
            FileLogger.Instance.log("不存在的group_id" + key);
            return 0;
        }
        public static int getClassCount(int key)
        {
            fetchGroupCounts();
            if (list.ContainsKey(key))
                return list[key].class_count;
            FileLogger.Instance.log("不存在的group_id"+key);
            return 0;
        }
        public static int getClassBoyCount(int key)
        {
            fetchGroupCounts();
            if (list.ContainsKey(key))
                return list[key].class_boy_count;
            FileLogger.Instance.log("不存在的group_id" + key);
            return 0;
        }
        public static int getClassGirlCount(int key)
        {
            fetchGroupCounts();
            if (list.ContainsKey(key))
                return list[key].class_girl_count;
            FileLogger.Instance.log("不存在的group_id" + key);
            return 0;
        }
    }
}
