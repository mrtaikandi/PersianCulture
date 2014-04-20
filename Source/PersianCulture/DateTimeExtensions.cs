namespace PersianCulture
{
    using System;
    using System.Globalization;
    using System.Threading;

    public static class DateTimeExtensions
    {
        private static DateTimeFormatInfo _dateTimeFormatInfo;

        private static DateTimeFormatInfo FormatProvider
        {
            get
            {
                if( _dateTimeFormatInfo == null )
                {
                    var threadCulture = Thread.CurrentThread.CurrentCulture;
                    if( threadCulture.Name == "fa-IR" )
                        _dateTimeFormatInfo = (DateTimeFormatInfo)threadCulture.GetFormat(typeof(DateTimeFormatInfo));
                    else
                        _dateTimeFormatInfo = new PersianCultureInfo().DateTimeFormat;
                }

                return _dateTimeFormatInfo;
            }
        }

        /// <summary>
        /// Converts the value of the current <see cref="DateTime"/> object to its 
        /// equivalent long date localized in Persian string representation.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to extend.</param>
        /// <returns>A string that contains the long date string representation of the current <see cref="DateTime"/> object.</returns>
        public static string ToLocalizedLongDateString(this DateTime dateTime)
        {
            return ToLocalizedString(dateTime, "D");
        }

        /// <summary>
        /// Converts the value of the current <see cref="DateTime"/> object to its 
        /// equivalent short date localized in Persian string representation.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to extend.</param>
        /// <returns>A string that contains the short date string representation of the current <see cref="DateTime"/> object.</returns>
        public static string ToLocalizedShortDateString(this DateTime dateTime)
        {
            return ToLocalizedString(dateTime, "d");
        }

        /// <summary>
        /// Converts the value of the current <see cref="DateTime"/> object to its equivalent 
        /// localized to Persian string representation using the specified format.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to extend.</param>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <returns>A string representation of value of the current <see cref="DateTime"/> object as specified by format.</returns>
        public static string ToLocalizedString(this DateTime dateTime, string format)
        {
            if( string.IsNullOrWhiteSpace(format) )
                return dateTime.ToString(FormatProvider);

            return dateTime.ToString(format, FormatProvider);
        }

        /// <summary>
        /// Converts the value of the current <see cref="DateTime" /> object to its equivalent 
        /// localized in Persian string representation.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to extend.</param>
        /// <returns>
        /// A string representation of the value of the current <see cref="DateTime" /> object.
        /// </returns>
        public static string ToLocalizedString(this DateTime dateTime)
        {
            return ToLocalizedString(dateTime, "G");
        }

        /// <summary>
        /// Returns the year part of this <see cref="DateTime"/> using the current culture <see cref="DateTimeFormatInfo"/>.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to extend.</param>
        /// <returns>An integer between 1 and 9999 representing the year part of this <see cref="DateTime"/>.</returns>
        public static int GetYear(this DateTime dateTime)
        {
            var format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
            return format.Calendar.GetYear(dateTime);
        }

        /// <summary>
        /// Returns the year part of this <see cref="DateTime"/> localized in Persian calendar.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to extend.</param>
        /// <returns>An integer between 1 and 9999 representing the year part of this <see cref="DateTime"/>.</returns>
        public static int GetLocalizedYear(this DateTime dateTime)
        {
            return FormatProvider.Calendar.GetYear(dateTime);
        }

        /// <summary>
        /// Returns the month part of this <see cref="DateTime"/> localized in Persian calendar.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to extend.</param>
        /// <returns>An integer between 1 and 12 representing the month part of this <see cref="DateTime"/>.</returns>
        public static int GetLocalizedMonth(this DateTime dateTime)
        {
            return FormatProvider.Calendar.GetMonth(dateTime);
        }

        /// <summary>
        /// Returns the month part of this <see cref="DateTime"/> using the current culture <see cref="DateTimeFormatInfo"/>.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to extend.</param>
        /// <returns>An integer between 1 and 12 representing the month part of this <see cref="DateTime"/>.</returns>
        public static int GetMonth(this DateTime dateTime)
        {
            var format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
            return format.Calendar.GetMonth(dateTime);
        }

        /// <summary>
        /// Returns the day-of-month part of this <see cref="DateTime"/> using the current culture <see cref="DateTimeFormatInfo"/>.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to extend.</param>
        /// <returns>An integer between 1 and 31 representing the day-of-month part of this <see cref="DateTime"/>.</returns>
        public static int GetDayOfMonth(this DateTime dateTime)
        {
            var format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
            return format.Calendar.GetDayOfMonth(dateTime);
        }

        /// <summary>
        /// Returns the day-of-month part of this <see cref="DateTime"/> localized in Persian calendar.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to extend.</param>
        /// <returns>An integer between 1 and 31 representing the day-of-month part of this <see cref="DateTime"/>.</returns>
        public static int GetLocalizedDayOfMonth(this DateTime dateTime)
        {
            return FormatProvider.Calendar.GetDayOfMonth(dateTime);
        }
    }
}