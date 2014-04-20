namespace PersianCulture
{
    using System;
    using System.Globalization;

    public static class CultureInfoExtensions
    {
        /// <summary>
        /// Returns a <see cref="PersianCultureInfo"/> that represents this instance.
        /// </summary>
        /// <param name="cultureInfo">The culture information to convert.</param>
        /// <returns>A <see cref="PersianCultureInfo"/> that represents this instance.</returns>
        /// <exception cref="System.ArgumentNullException">cultureInfo</exception>
        public static PersianCultureInfo ToPersianCultureInfo(this CultureInfo cultureInfo)
        {
            if( cultureInfo == null )
                throw new ArgumentNullException("cultureInfo");

            return new PersianCultureInfo(cultureInfo.UseUserOverride);
        }

        /// <summary>
        /// Adds an instance of <see cref="PersianCalendar" /> to the list of optional calendars of this instance and
        /// applies localization and correct persian formatting if the culture name is "fa-IR".
        /// </summary>
        /// <param name="cultureInfo">The <see cref="CultureInfo"/> instance to extend.</param>
        /// <returns>
        /// The <see cref="CultureInfo"/> instance that has <see cref="PersianCalendar"/> as its optional calendars.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">cultureInfo</exception>
        /// <exception cref="System.ArgumentException">Unable to set the calendar to a new instance of PersianCalendar.</exception>
        public static CultureInfo AddPersianCalendar(this CultureInfo cultureInfo)
        {
            if( cultureInfo == null )
                throw new ArgumentNullException("cultureInfo");

            return PersianCultureInfo.AddPersianCalendar(cultureInfo);
        }
    }
}