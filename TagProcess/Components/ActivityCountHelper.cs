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
            public int group_count;
            public int class_count;
        }

        private static Dictionary<int, GroupCount> list = null;
        private static RaceServer server = RaceServer.Instance;

        private static void fetchGroupCounts()
        {
            if (list == null)
            {
                RestRequest req = new RestRequest("api/json/chip_race_group/"+server.competition_id+"/count/list", Method.GET);

                var res = server.ExecuteHttpRequest(req);

                var def = new { result = "", ret = new Dictionary<int, RaceGroups>() };
                var obj = JsonConvert.DeserializeAnonymousType(res.Content, def);

                if (obj.result == "ok")
                    return;
                else
                    FileLogger.Instance.log(obj.result);
                return;
            }

            return;
        }

        public static int getGroupCount(int key)
        {
            if (list.ContainsKey(key))
                return list[key].group_count;
            return 0;
        }
        public static int getClassCount(int key)
        {
            if (list.ContainsKey(key))
                return list[key].class_count;
            return 0;
        }
    }
}
