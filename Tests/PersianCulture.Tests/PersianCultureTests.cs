namespace PersianCulture.Tests
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    // ReSharper disable InconsistentNaming
    [TestClass]
    public class PersianCultureTests
    {
        [TestMethod]
        public void Add_PersianCalendar_To_CultureInfo()
        {
            var culture = new CultureInfo("fa-IR").AddPersianCalendar();
            Thread.CurrentThread.CurrentCulture = culture;
            var date = new DateTime(1393, 1, 28, new PersianCalendar());

            Assert.AreEqual(date.ToShortDateString(), "1393/01/28");
        }

        [TestMethod]
        public void Add_PersianCalendar_To_CultureInfo2()
        {
            var culture = new CultureInfo("en-US").AddPersianCalendar();
            var hasPersianCalendar = culture.OptionalCalendars.Any(p => p is PersianCalendar);

            Assert.IsTrue(hasPersianCalendar);
        }

        [TestMethod]
        public void Convert_CultureInfo_To_PersianCultureInfo()
        {
            var culture = new CultureInfo("fa-IR").ToPersianCultureInfo();
            Thread.CurrentThread.CurrentCulture = culture;
            var date = new DateTime(1393, 1, 28, new PersianCalendar());

            Assert.AreEqual(date.ToShortDateString(), "1393/01/28");
        }

        [TestMethod]
        public void PersianCultureInfo_Localization_LongDatePattern()
        {
            Thread.CurrentThread.CurrentCulture = new PersianCultureInfo();
            var date = new DateTime(1393, 1, 30, new PersianCalendar());

            Assert.AreEqual(date.ToLongDateString(), "30 (شنبه) فروردین 1393");
        }

        [TestMethod]
        public void Use_PersianCultureInfo_As_Thread_Culture()
        {
            Thread.CurrentThread.CurrentCulture = new PersianCultureInfo();
            var date = new DateTime(1393, 1, 28, new PersianCalendar());

            Assert.AreEqual(date.ToShortDateString(), "1393/01/28");
        }

        // ReSharper restore InconsistentNaming
    }
}