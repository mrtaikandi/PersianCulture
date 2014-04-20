using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersianCulture.Tests
{
    // ReSharper disable InconsistentNaming
    [TestClass]
    public class DateTimeExtensionsTests
    {
        [TestMethod]
        public void Test_ToLocalizedLongDateString()
        {
            var date = new DateTime(2014, 4, 19);
            var longDateString = date.ToLocalizedLongDateString();

            Assert.AreEqual(longDateString, "30 (شنبه) فروردین 1393");
        }

        [TestMethod]
        public void Test_ToLocalizedShortDateString()
        {
            var date = new DateTime(2014, 4, 19);
            var shortDateString = date.ToLocalizedShortDateString();

            Assert.AreEqual(shortDateString, "1393/01/30");
        }

        [TestMethod]
        public void Test_ToLocalizedString()
        {
            var date = new DateTime(2014, 4, 19, 22, 20, 23, 30);
            var dateString = date.ToLocalizedString();

            Assert.AreEqual(dateString, "1393/01/30 10:20:23 ب.ظ");
        }

        // ReSharper restore InconsistentNaming
    }
}
