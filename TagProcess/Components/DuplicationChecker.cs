using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagProcess.Components
{
    class DuplicationChecker
    {
        HashSet<int> group = null;
        HashSet<string> tags = null;

        private FileStream pacFile;
        private StreamWriter pacWriter;

        public DuplicationChecker()
        {
            Init();
        }

        public void Init()
        {
            group = new HashSet<int>();
            tags = new HashSet<string>();

            pacFile = new FileStream("record.txt", FileMode.Append, FileAccess.Write, FileShare.Read, bufferSize: 4096);
            pacWriter = new StreamWriter(pacFile, Encoding.UTF8);
            pacWriter.AutoFlush = true;
        }

        public void Set(HashSet<int> input)
        {
            group = input;

            tags.Clear();

            foreach (int n in input)
            {
                pacWriter.WriteLine("---- " + DateTime.Now.ToString() + " 起跑 -- " + ParticipantsRepository.Instance.helper.groupIntToString(n) + " ----");
            }
        }

        public enum CheckResult
        {
            Ok,
            Fail,
            Dup
        }
        public CheckResult Check(int n, string tag)
        {
            if (group.Contains(n))
                return CheckResult.Ok;

            if (tags.Contains(tag) == false)
            {
                pacWriter.WriteLine("---- " + DateTime.Now.ToString() + " 組別錯誤 -- " + tag + " ----");
                tags.Add(tag);
                return CheckResult.Fail;
            }

            return CheckResult.Dup;
        }

        public int Count()
        {
            return tags.Count;
        }

        public void Clear()
        {
            tags.Clear();
        }
    }
}
