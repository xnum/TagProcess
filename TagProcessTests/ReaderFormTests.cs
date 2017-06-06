using Microsoft.VisualStudio.TestTools.UnitTesting;
using TagProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagProcess.Tests
{
    [TestClass()]
    public class ReaderFormTests
    {
        [TestMethod()]
        public void stringToCmdTest()
        {
            var form = new ReaderForm();
            Cmd res = form.stringToCmd("aa0005800322d0ee01001706052030415f0b");
            Assert.AreEqual(res.time.Year, 2017);
            Assert.AreEqual(res.time.Month, 6);
        }
    }
}