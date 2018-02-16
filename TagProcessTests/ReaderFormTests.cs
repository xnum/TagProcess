using Microsoft.VisualStudio.TestTools.UnitTesting;
using TagProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TagProcess.Tests
{
    [TestClass()]
    public class ReaderFormTests
    {
        [TestInitialize()]
        public void setup()
        {
            var pr = ParticipantsRepository.Instance;
            var k = TimeKeeper.Instance;

            pr.helper.setGroups(new List<RaceGroups>() {
                new RaceGroups() { id = 1, name = "Test1", start_time = new DateTime() },
                new RaceGroups() { id = 2, name = "Test2", start_time = new DateTime() },
                new RaceGroups() { id = 3, name = "Test3", start_time = new DateTime() }
            });

            pr.participants.Clear();
            pr.participants.Add(new Participant() { id = 1, group_id = 1, tag_id = "tag0001" });

            k.Clear();
            k.Init(1);
        }

        [TestMethod()]
        public void ReadEqStartTimeTest()
        {
            var pr = ParticipantsRepository.Instance;
            var k = TimeKeeper.Instance;

            // 紀錄起跑時間
            k.setStartCompetition(1, new List<int>() { 1, 2, 3 });

            // 所以tag時間也要用Now
            k.addData(1, new IPXCmd() { data = "tag0001", time = DateTime.Now });

            Assert.AreEqual(k.GetTagCount(), 1);
            Assert.AreEqual(k.GetBufferedCount(), 0);
            Assert.AreEqual(k.GetUploadedCount(), 0);

            // 5秒強制刷新 不應該寫入資料
            k.uploadTagData(true, DateTime.Now.AddSeconds(5));

            Assert.AreEqual(k.GetBufferedCount(), 0);
            Assert.AreEqual(k.GetUploadedCount(), 0);

            // 12秒強制刷新 應該寫入資料
            k.uploadTagData(true, DateTime.Now.AddSeconds(12));

            Assert.AreEqual(k.GetBufferedCount(), 0);
            Assert.AreEqual(k.GetUploadedCount(), 1);
        }

        [TestMethod()]
        public void ReadBeforeStartTimeTest()
        {
            var pr = ParticipantsRepository.Instance;
            var k = TimeKeeper.Instance;

            // 2秒前感應
            k.addData(1, new IPXCmd() { data = "tag0001", time = DateTime.Now.Subtract(TimeSpan.FromSeconds(2)) });
            // 還沒開跑
            Assert.AreEqual(k.GetTagCount(), 1);
            Assert.AreEqual(k.GetBufferedCount(), 0);
            Assert.AreEqual(k.GetUploadedCount(), 0);

            // 紀錄起跑時間
            k.setStartCompetition(1, new List<int>() { 1, 2, 3 });

            Assert.AreEqual(k.GetTagCount(), 1);
            Assert.AreEqual(k.GetBufferedCount(), 0);
            Assert.AreEqual(k.GetUploadedCount(), 0);

            // 5秒內強制刷新 不應該寫入資料
            k.uploadTagData(true, DateTime.Now.AddSeconds(5));

            Assert.AreEqual(k.GetBufferedCount(), 0);
            Assert.AreEqual(k.GetUploadedCount(), 0);

            // 12秒強制刷新 應該寫入資料
            k.uploadTagData(true, DateTime.Now.AddSeconds(12));

            Assert.AreEqual(k.GetBufferedCount(), 0);
            Assert.AreEqual(k.GetUploadedCount(), 1);
        }

        [TestMethod()]
        public void ReadBeforeStartTimeTooFarTest()
        {
            var pr = ParticipantsRepository.Instance;
            var k = TimeKeeper.Instance;

            // 2秒前感應
            k.addData(1, new IPXCmd() { data = "tag0001", time = DateTime.Now.Subtract(TimeSpan.FromSeconds(5)) });
            // 還沒開跑
            Assert.AreEqual(k.GetTagCount(), 1);
            Assert.AreEqual(k.GetBufferedCount(), 0);
            Assert.AreEqual(k.GetUploadedCount(), 0);

            // 紀錄起跑時間
            k.setStartCompetition(1, new List<int>() { 1, 2, 3 });

            Assert.AreEqual(k.GetTagCount(), 1);
            Assert.AreEqual(k.GetBufferedCount(), 0);
            Assert.AreEqual(k.GetUploadedCount(), 0);

            // 5秒內強制刷新 不應該寫入資料
            k.uploadTagData(true, DateTime.Now.AddSeconds(5));

            Assert.AreEqual(k.GetBufferedCount(), 0);
            Assert.AreEqual(k.GetUploadedCount(), 0);

            // 12秒強制刷新 應該寫入資料
            k.uploadTagData(true, DateTime.Now.AddSeconds(12));

            // 不會算進去
            Assert.AreEqual(k.GetBufferedCount(), 0);
            Assert.AreEqual(k.GetUploadedCount(), 0);
        }
    }
}