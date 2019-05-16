using System;
using NodaTime;
using NodaTime.TimeZones;

namespace AdventureTime
{
    /// <summary>
    /// ����� ������� ��� ������ � ��������.
    /// </summary>
    internal static class Time
    {
        /// <summary>
        /// ���������� ������� ��������� �����.
        /// </summary>
        public static DateTime WhatTimeIsIt()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// ���������� ������� ����� � UTC.
        /// </summary>
        public static DateTime WhatTimeIsItInUtc()
        {
            return DateTime.UtcNow;
        }

        /// <summary>
        /// ���������� ������ <see cref="DateTime"/> � ��������� �������� � ��������� <see cref="DateTime.Kind"/>.
        /// </summary>
        /// <param name="dt">������ <see cref="DateTime"/>, �������� �����.</param>
        /// <param name="kind">�������� <see cref="DateTime.Kind"/>, �������� ��������������� �������� ������������� �������.</param>
        /// <returns>������ <see cref="DateTime"/> � ��������� �������� � ��������� <see cref="DateTime.Kind"/>.</returns>
        public static DateTime SpecifyKind(DateTime dt, DateTimeKind kind)
        {
            /*
                ���������: ����� � ����������� ������� DateTime.
            */
            return DateTime.SpecifyKind(dt, kind);
        }

        /// <summary>
        /// ������������ ������ <see cref="DateTime"/> � ������������� ��� ��������� ������������� ������� � ������� ISO 8601 (aka round-trip format).
        /// </summary>
        /// <param name="dt">������ <see cref="DateTime"/> ��� ����������� � ������.</param>
        /// <returns>��������� ������������� ������� � ������� ISO 8601.</returns>
        public static string ToRoundTripFormatString(DateTime dt)
        {
            /*
                ����������� ��������� � �������� �� ��������� ���������� � ����������� �� dt.Kind (��� ����� ���� ������� ����� ����).
                �� � �� ������� ������� ���� ���������� ��������� ������ ������������� ������� - �� ���� ���!
                �������� ���������� �� �����, ������ �����, ��� ��� �������� �������� � ���� ������, �������� ����� ������������ ������������ ������������/�������������� �������.
            */
            return dt.ToString("O");
        }

        /// <summary>
        /// ������������ ��������� ������������� ������� � ������� ISO 8601 � ������ <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dtStr">��������� ������������� ������� � ������� ISO 8601.</param>
        /// <returns>������ <see cref="DateTime"/>.</returns>
        public static DateTime ParseFromRoundTripFormat(string dtStr)
        {
            /*
                ��������� � �������, ��� round-trip ������������� round-trip, �.�. ����-������� ����� ��������� (��� ���� ������������ ���������� �������).
                ������� ��� ���� �������� DateTime.Kind.
            */
            return DateTime.Parse(dtStr);
        }

        /// <summary>
        /// ����������� �������� �������� ������� <see cref="DateTime"/> �� ����� UTC.
        /// </summary>
        public static DateTime ToUtc(DateTime dt)
        {
            /*
                E��� �������������� ������ �������, �� ���������, ��� ��������� ��� ������ ������� �� dt.Kind.
                � ������ dt.Kind == Unspecified ��������������, ��� ����� ���������, �.�. ��������� ������ � ������ Local � Unspecified ���������. ����� ����
            */
            return dt.ToUniversalTime();
        }

        /// <summary>
        /// ���������� �����, ������������ ������ �� 10 ������ �� ���������.
        /// </summary>
        /// <param name="dt">�������� �����.</param>
        /// <returns>�����, ������������ ������ �� 10 ������ �� ���������</returns>
        public static DateTime AddTenSeconds(DateTime dt)
        {
            // ����� ������������ �������� ������ ������� � ������ �������� ����� ��� ������� ����
            return dt.AddSeconds(10);
        }

        /// <summary>
        /// ���������� �����, ������������ ������ �� 10 ������ �� ���������.
        /// </summary>
        /// <param name="dt">�������� �����.</param>
        /// <returns>�����, ������������ ������ �� 10 ������ �� ���������</returns>
        public static DateTime AddTenSecondsV2(DateTime dt)
        {
            /*
                �� � ����� ������������ ��������� � TimeSpan. ������ ��������, ��� ������ ������������, � ������ ���� ����� �������� ����������� �������-������.
                ������ ��������, ��� � TimeSpan ��� ����������� ������� FromMonth, FromYear. ��� �������, ������?
            */
            return dt + TimeSpan.FromSeconds(10);
        }

        /// <summary>
        /// ���������� ������ ���������� ����� ��������� ���������� �������.
        /// </summary>
        /// <param name="dt1">������ ���������� �������.</param>
        /// <param name="dt2">����� ���������� �������.</param>
        /// <returns>������ ���������� ����� ��������� ���������� �������.</returns>
        public static int GetHoursBetween(DateTime dt1, DateTime dt2)
        {
            /*
                1) �������, � ��� ������� ����� Hours � TotalHours
                2) �������, ����������� �� Kind �������� ��� �������������� ���������.
                3) �������, ������ ������������ �������� ����� ���������� �� ����������������.
            */
            return (int)(dt2 - dt1).TotalHours;
        }

        /// <summary>
        /// ���������� ���������� ����� �� ��������� ����������, ������ ���� �������.
        /// </summary>
        public static int GetTotalMinutesInThreeMonths()
        {

            // �� ��� ��� ������ � ��������, ���� ������ ��������� � ������� ��� ��������� � ���������.
            //
            throw new ArgumentException();
        }

        #region Adventure time saga

        /// <summary>
        /// ���������� ���������� �����, ����������� � ���� �� ������ � ������.
        /// </summary>
        /// <remarks>
        /// ���� � �����, ������ ��������, ������, ��� ����� ��� �������� � ������� ����� �����������, ������� ������ ������� ����, ������� ����� ���� � ����������� �� ������������ ������ � ������������ ������ ������ �� ���� ���������.
        /// ������� ����� ��� ������� � ����, ���� ������ ��� �������� 28.03.2010 � 02:15 �� �������� �������, � � ������ ������� � 28.03.2010 � 02:15 �� ��������?
        /// </remarks>
        public static int GetAdventureTimeDurationInMinutes_ver0_Dumb()
        {
            /*
                ��� �� ���������, ����� ������� �� ������ ���, �� ��� ������ ����� ���������� ������ ��������.
                ������ ��������� � ������� ����� +0 (GMT), � ������ � +3 (MSK). ������������ DateTimeOffset, ����� ������ ���������� �����, � �������� ������� � �������. �������� �� ���������.
                �����, ����������� ��� ���������:
                    - 2010, 3, 28, 2, 15, 0
            */
            DateTimeOffset time_msk = new DateTimeOffset(2010, 3, 28, 2, 15, 0, new TimeSpan(3,0,0));
            DateTimeOffset time_london = new DateTimeOffset(2010, 3, 28, 2, 15, 0, new TimeSpan(0,0,0));
            return (int)(time_london - time_msk).TotalMinutes;

        }

        /// <summary>
        /// ���������� ���������� �����, ����������� � ���� �� ������ � ������.
        /// </summary>
        /// <remarks>
        /// ������ � ����, �������� ��������� ����������� �� ������ ������, ������, ��� ��� ��� ������� ������ ����� ����� �� ����� � ������ ����� ����� ��� �����������! ���� ������� ����, ������� ����� ���� � ����������� �� 
        /// ������ ������������ ������ � ������ ������������ ������ ������ �� ����� ���������.
        /// ������� ����� ��� ������� � �����������, ���� ������ ��� �������� 28.03.2010 � 03:15 �� �������� �������, � � ������ ������� � 28.03.2010 � 01:15 �� ��������?
        /// </remarks>
        public static int GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb()
        {
            /*
                ����� �� �� �����. �����, ������� ���������� �������. ��� ����������� ��� ��������� �������:
                    - 2010, 3, 28, 3, 15, 0
                    - 2010, 3, 28, 1, 15, 0
            */
            DateTimeOffset time_msk = new DateTimeOffset(2010, 3, 28, 3, 15, 0, new TimeSpan(3,0,0));
            DateTimeOffset time_london = new DateTimeOffset(2010, 3, 28, 1, 15, 0, new TimeSpan(0,0,0));
            return (int)((time_london - time_msk).TotalMinutes);
        }

        /// <summary>
        /// ���������� ���������� �����, ����������� � ���� �� ������ � ������.
        /// </summary>
        public static int GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter()
        {
            /*
                ����� ������, � ������� �����������, ��� � ��������� ������� ������� ����� ����� ��� ������ ����� (�� ������ ��, ��� ������� ���� ���� ���� ���).

                ������������ �������� ��� ���������� � ������ ���� ������� ������ � �� �������� ������������ UTC � ��� �� ����.
                �� ����� ���� �������� ������: ������ +1 (BST - British Summer Time), ������ +4 (MSD - Moscow Daylight Time).
                ����� ������ ����� ���������� ��������. � �������, ��� ��� ��������, ��� ��������� �� ���������, �� ���� �� �� ������ ������������ � ������ �������� ��������?
            */
            DateTimeOffset time_msk = new DateTimeOffset(2010, 3, 28, 3, 15, 0, new TimeSpan(4,0,0));
            DateTimeOffset time_london = new DateTimeOffset(2010, 3, 28, 1, 15, 0, new TimeSpan(1,0,0));
            return (int)(time_london - time_msk).TotalMinutes;
        }

        // GetGenderSwappedAdventureTimeDurationInMinutes_ver1_FeelsSmarter �������, ��� �� �� �����

        /// <summary>
        /// ���������� ���������� �����, ����������� � ���� �� ������ � ������.
        /// </summary>
        public static int GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()
        {
            /*
                ����� ������ � ���������, � ������� �������� �����������, ��� ���� � ������ ��������� � ������������ � ���������� � ���� �������� ������������ �������������, ������� � ������������� �� ������ � ������.

                ���� � ���, ��� ������� �� ������ ����� � 2010� ���� � ������ ��������� � 02:00 (������� ����� �������� �� ��� ������), � � ������� - � 01:00.
                ����� ������� � ������ �� ���� 02:15 - ������ �����, ��������, �������, ��� ����� ������� ������������� 03:15. �� � � ������� 01:15 ��� �� ����� ���� 02:15.
                ������ ��� ��� ���������� � ������ ������ DateTimeOffset? ��, ��� ����������� ������� �� ����� �� ���� ������� "��������� �������" � ��������� ���������� �����, �� ��� ������ � ����� ������?
                ��� �������� ��������������� ������� � ������� ������. �� ���� � .Net.

                ���� �� �� �������[-���], ��� � ������ msdn � stackoverflow � ������� ������ (� ����� ������, ����� ���� ��� � ����� ������������� �����������),
                ���� �� ������� ������� ����� GetZonedTime. ������ �������� �� ���� (������ ���� ���������� ������ � �������� ���� TimeZoneInfo, ���� ���������) � ������������ �� ��� ���������� ����������� �������
                "�������" � "��������" ����� ������. ����� �������� ������������ �����������. ����� ���� ���������� �������������� ���.
            */
            const string moscowZoneId = "Russian Standard Time";
            const string londonZoneId = "GMT Standard Time";

            DateTimeOffset time_msk = GetZonedTime(new DateTime(2010, 3, 28, 2, 15, 0), moscowZoneId);
            DateTimeOffset time_london = GetZonedTime(new DateTime(2010, 3, 28, 2, 15, 0), londonZoneId);
            return (int)(time_london - time_msk).TotalMinutes;
        }

        /// <summary>
        /// ���������� ���������� �����, ����������� � ���� �� ������ � ������.
        /// </summary>
        public static int GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()
        {
            /*
                ���� �� �������� � ���������� ������� � �������, ��� ��� ������ ������������� ���������� ���� � �� �� ����� (� ��� ��� ����������).
            */
            const string moscowZoneId = "Russian Standard Time";
            const string londonZoneId = "GMT Standard Time";
            DateTimeOffset time_msk = GetZonedTime(new DateTime(2010, 3, 28, 3, 15, 0), moscowZoneId);
            DateTimeOffset time_london = GetZonedTime(new DateTime(2010, 3, 28, 1, 15, 0), londonZoneId);
            return (int)(time_london - time_msk).TotalMinutes;
        }

        private static DateTimeOffset GetZonedTime(DateTime localTime, string timeZoneId)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

            // � ���������� �������� ��� ���� � �������:
            var isInvalid = timeZone.IsInvalidTime(localTime);
            var isDaylightSaving = timeZone.IsDaylightSavingTime(localTime);
            var isAmbiguous = timeZone.IsAmbiguousTime(localTime);

            Console.WriteLine($"{localTime}: invalid = {isInvalid}; daylight = {isDaylightSaving}; ambigous = {isAmbiguous}");

            // �������� �� ��, ��� DateTimeOffset ������ ��������� ����� + ��������, � ���������������� ����� �� ��������� ���������� ���������� �������� (����� UTC)
            return new DateTimeOffset(localTime, timeZone.GetUtcOffset(localTime));
        }

        // ���� ������ ������� � �������������� ���������� NodaTime

        /// <summary>
        /// ���������� ���������� �����, ����������� � ���� �� ������ � ������.
        /// </summary>
        public static int GetAdventureTimeDurationInMinutes_ver3_NodaTime()
        {
            const string londonTimeZoneId = "Europe/London";
            const string moscowTimeZoneId = "Europe/Moscow";

            // ��� LocalDateTime �� ������ ���������� � ���, ��� "�����������" ��� �����, �� ���� �������, ��� ������ ����� ����� ���������� ��� ���� � ������� ������� �������������� �� ������.
            // ����� ����, ��� ��� �� ��������� ���� ������� ���-�� ������ ��� ���������� ��� ����� ���-�� �����. ��������, ��� ���������� ���������� � ���������� ����� UTC (� Noda Time ��� �������� ��� Instant)
            var from = new LocalDateTime(2010, 3, 28, 2, 15, 0);
            var to = new LocalDateTime(2010, 3, 28, 2, 15, 0);

            //��� ZonedDateTime - ��� ������ ������ LocalDateTime + DateTimeZone (��������� ����� + ������� ����). ��� �� ���� ���������� ����� ��� ����� �������� (���������� ����������).
            var fromMoscowZoned = GetZonedTime(from, moscowTimeZoneId);
            var toLondonZoned = GetZonedTime(to, londonTimeZoneId);
            return (int)(toLondonZoned - fromMoscowZoned).TotalMinutes;
        }

        private static ZonedDateTime GetZonedTime(LocalDateTime localTime, string timeZoneId)
        {
            // ����� ������������ �� windows-specific ������� ���������������, � ����� "��������" �����������
            var timeZone = TzdbDateTimeZoneSource.Default.ForId(timeZoneId);

            // ������ ��������, ���� ��� ������, ������������ ��������� ����� + ������� ���� � ZonedDateTime: InZoneLeniently � InZoneStrictly. ������ �� �������� �� ������������ ��������� �����, ������ - ������� ����������. ��� ����������� ��������� ����� ������� � ����������� "���������������" �������.
            return localTime.InZoneLeniently(timeZone);
        }

        #endregion

        /// <summary>
        /// ���������, �������� �� ��� �������� � ���� ����.
        /// </summary>
        /// <param name="person1Birthday">���� �������� ������� ��������.</param>
        /// <param name="person2Birthday">���� �������� ������� ��������.</param>
        /// <returns>True - ���� �������� � ���� ����, ����� - false.</returns>
        internal static bool AreEqualBirthdays(DateTime person1Birthday, DateTime person2Birthday)
        {
            return (person1Birthday.ToUniversalTime().Day == person2Birthday.ToUniversalTime().Day &&
                   person1Birthday.ToUniversalTime().Month == person2Birthday.ToUniversalTime().Month);
        }
    }
}