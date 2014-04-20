namespace PersianCulture.Tests
{
    using System;
    using System.Threading;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        [TestMethod]
        public void Test_GetLocalizedDayOfMonth()
        {
            var date = new DateTime(2014, 4, 20);
            var dayOfMonth = date.GetLocalizedDayOfMonth();

            Assert.AreEqual(dayOfMonth, 31);
        }

        [TestMethod]
        public void Test_GetDayOfMonth()
        {
            Thread.CurrentThread.CurrentCulture = new PersianCultureInfo();
            var date = new DateTime(2014, 4, 20);
            var dayOfMonth = date.GetDayOfMonth();

            Assert.AreEqual(dayOfMonth, 31);
        }

        [TestMethod]
        public void Test_GetLocalizedMonth()
        {
            var date = new DateTime(2014, 4, 20);
            var month = date.GetLocalizedMonth();

            Assert.AreEqual(month, 1);
        }

        [TestMethod]
        public void Test_GetMonth()
        {
            Thread.CurrentThread.CurrentCulture = new PersianCultureInfo();
            var date = new DateTime(2014, 4, 20);
            var month = date.GetMonth();

            Assert.AreEqual(month, 1);
        }

        [TestMethod]
        public void Test_GetLocalizedYear()
        {
            var date = new DateTime(2014, 4, 20);
            var year = date.GetLocalizedYear();

            Assert.AreEqual(year, 1393);
        }

        [TestMethod]
        public void Test_GetYear()
        {
            Thread.CurrentThread.CurrentCulture = new PersianCultureInfo();
            var date = new DateTime(2014, 4, 20);
            var year = date.GetYear();

            Assert.AreEqual(year, 1393);
        }

        // ReSharper restore InconsistentNaming
    }
}