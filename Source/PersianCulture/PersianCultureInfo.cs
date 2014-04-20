namespace PersianCulture
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Reflection;

    public class PersianCultureInfo : CultureInfo
    {
        private const BindingFlags AllModifiersBindingFlag = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        private const string CultureInfoName = "fa-IR";

        /// <summary>
        /// Initializes a new instance of the <see cref="PersianCultureInfo"/> class.
        /// </summary>
        public PersianCultureInfo()
            : this(false) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersianCultureInfo" /> class.
        /// </summary>
        /// <param name="useUserOverride">A Boolean that denotes whether to use the user-selected culture settings (true) or the default culture settings (false).</param>
        public PersianCultureInfo(bool useUserOverride)
            : base(CultureInfoName, useUserOverride)
        {
            AddPersianCalendar(this);
        }

        /// <summary>
        /// Adds an instance of <see cref="PersianCalendar"/> to the list of optional calendars of the 
        /// specified <see cref="CultureInfo"/> and applies localization and correct persian formatting 
        /// if the culture name is "fa-IR".
        /// </summary>
        /// <param name="culture">The <see cref="CultureInfo"/> instance to add the <see cref="PersianCalendar"/> to its list of optional calendars.</param>
        /// <returns>The <see cref="CultureInfo"/> instance that has <see cref="PersianCalendar"/> as its optional calendars.</returns>
        /// <exception cref="System.ArgumentException">Unable to set the calendar to a new instance of PersianCalendar.</exception>
        public static CultureInfo AddPersianCalendar(CultureInfo culture)
        {
            if( culture == null )
                throw new ArgumentNullException("culture");

            culture = AddOptionalCalendars(culture, -1);

            var cultureInfoReadOnly = typeof(CultureInfo).GetField("m_isReadOnly", AllModifiersBindingFlag);
            var readOnly = cultureInfoReadOnly != null && (bool)cultureInfoReadOnly.GetValue(culture);

            if( readOnly )
                cultureInfoReadOnly.SetValue(culture, false);

            if( culture.Name == "fa-IR" )
            {
                var cultureCalendar = typeof(CultureInfo).GetField("calendar", AllModifiersBindingFlag);
                if( cultureCalendar == null )
                    throw new ArgumentException("Unable to set the calendar to a new instance of PersianCalendar.");

                cultureCalendar.SetValue(culture, new PersianCalendar());
                culture.DateTimeFormat = LocalizeDateTimeFormatInfo(culture.DateTimeFormat);
            }

            if( readOnly )
                cultureInfoReadOnly.SetValue(culture, true);

            return culture;
        }

        /// <summary>
        /// Returns a new instance of <see cref="DateTimeFormatInfo"/> localized for Persian Calendar.
        /// </summary>
        /// <returns>A new instance of <see cref="DateTimeFormatInfo"/> localized for Persian Calendar.</returns>
        public static DateTimeFormatInfo GetDateTimeFormat()
        {
            return LocalizeDateTimeFormatInfo(new DateTimeFormatInfo());
        }

        /// <summary>
        /// Adds <see cref="PersianCalendar"/> to the list of optional calendars of the specified <paramref name="culture"/> in the given <paramref name="index"/>.
        /// </summary>
        /// <param name="culture">The <see cref="CultureInfo"/> instance to add the <see cref="PersianCalendar"/> to its list of OptionalCalendars.</param>
        /// <param name="index">The index of element in optional calendars to be set to PersianCalendar or a negative number to add the PersianCalendar at the end of available calendars.</param>
        /// <returns>Same instance of passed <paramref name="culture"/> which has <see cref="PersianCalendar"/> as an optional calendar.</returns>
        private static CultureInfo AddOptionalCalendars(CultureInfo culture, int index)
        {
            Debug.Assert(culture != null, "culture is null");

            var cultureDataField = culture.GetType().GetField("m_cultureData", AllModifiersBindingFlag);
            if( cultureDataField != null )
            {
                var cultureData = cultureDataField.GetValue(culture);
                var calendarIdProperty = cultureData.GetType().GetProperty("CalendarIds", AllModifiersBindingFlag);
                var calendars = (int[])calendarIdProperty.GetValue(cultureData, null);

                if( index >= calendars.Length )
                    throw new ArgumentException(string.Format("index should be less than {0} (Optional Calendars length).", calendars.Length));

                if( index < 0 )
                    index = calendars.Length - 1;

                calendars[index] = 0x16;
            }

            return culture;
        }

        /// <summary>
        /// Localizes the specified <paramref name="dateTimeFormat" /> and adds an instance of <see cref="PersianCalendar" /> as its calendar.
        /// </summary>
        /// <param name="dateTimeFormat">The DateTimeFormatInfo to localize.</param>
        /// <returns>
        /// Same instance of <see cref="DateTimeFormatInfo" /> passed but localized and with an instance of <see cref="PersianCalendar" /> as its calendar.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">info</exception>
        /// <exception cref="System.ArgumentException">
        /// Unable to get IsReadOnly field from the specified DateTimeFormatInfo.;info
        /// or
        /// Unable to get Calendar field from the specified DateTimeFormatInfo.;info
        /// </exception>
        private static DateTimeFormatInfo LocalizeDateTimeFormatInfo(DateTimeFormatInfo dateTimeFormat)
        {
            Debug.Assert(dateTimeFormat != null, "dateTimeFormat is null");

            var infoType = dateTimeFormat.GetType();
            var formatInfoIsReadOnly = infoType.GetField("m_isReadOnly", AllModifiersBindingFlag);
            var formatInfoCalendar = infoType.GetField("calendar", AllModifiersBindingFlag);

            if( formatInfoIsReadOnly == null )
                throw new ArgumentException("Unable to get IsReadOnly field from the specified DateTimeFormatInfo.", "dateTimeFormat");

            if( formatInfoCalendar == null )
                throw new ArgumentException("Unable to get Calendar field from the specified DateTimeFormatInfo.", "dateTimeFormat");

            var isReadOnly = (bool)formatInfoIsReadOnly.GetValue(dateTimeFormat);

            if( isReadOnly )
                formatInfoIsReadOnly.SetValue(dateTimeFormat, false);

            formatInfoCalendar.SetValue(dateTimeFormat, new PersianCalendar());
            dateTimeFormat.AbbreviatedDayNames = new[] { "ی", "د", "س", "چ", "پ", "ج", "ش" };
            dateTimeFormat.ShortestDayNames = new[] { "ی", "د", "س", "چ", "پ", "ج", "ش" };
            dateTimeFormat.DayNames = new[] { "یکشنبه", "دوشنبه", "ﺳﻪشنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" };
            dateTimeFormat.AbbreviatedMonthNames = new[] { "فروردین", "ارديبهشت", "خرداد", "تير", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", string.Empty };
            dateTimeFormat.MonthNames = new[] { "فروردین", "ارديبهشت", "خرداد", "تير", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", string.Empty };
            dateTimeFormat.AMDesignator = "ق.ظ";
            dateTimeFormat.PMDesignator = "ب.ظ";
            dateTimeFormat.FirstDayOfWeek = DayOfWeek.Saturday;
            dateTimeFormat.FullDateTimePattern = "dd (dddd) MMMM yyyy - HH:mm:ss";
            dateTimeFormat.LongDatePattern = "dd (dddd) MMMM yyyy";
            dateTimeFormat.ShortDatePattern = "yyyy/MM/dd";

            if( isReadOnly )
                formatInfoIsReadOnly.SetValue(dateTimeFormat, true);

            return dateTimeFormat;
        }
    }
}