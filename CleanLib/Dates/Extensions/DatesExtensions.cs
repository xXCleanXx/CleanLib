using System;

namespace CleanLib.Common.Dates.Extensions {
    public static class DatesExtensions {
        public static string ToGermanFormat(this DateTime dateTime, bool date = true) => dateTime.ToString(date ? "dd.MM.yyyy" : "dd.MM.yyyy hh:mm:ss");
        public static string ToGermanFormat(this DateTime? dateTime) => dateTime is null
            ? throw new ArgumentNullException(nameof(dateTime), "DateTime cannot be null!")
            : ((DateTime)dateTime).ToGermanFormat();

        public static string ToMySQLFormat(this DateTime dateTime, bool date = true) => dateTime.ToString(date ? "yyyy-MM-dd" : "yyyy-MM-dd hh:mm:ss");
        public static string ToMySQLFormat(this DateTime? dateTime) => dateTime is null
            ? throw new ArgumentNullException(nameof(dateTime), "DateTime cannot be null!")
            : ((DateTime)dateTime).ToMySQLFormat();
    }
}