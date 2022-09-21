#pragma warning disable S3358 // Ternary operators should not be nested

using System;

namespace CleanLib.Dates.Extensions;

public static class DatesExtensions {
    public static string ToGermanFormat(this DateTime dateTime, bool onlyDate = true)
        => dateTime.ToString(onlyDate ? "dd.MM.yyyy" : "dd.MM.yyyy HH:mm:ss");

    public static string ToGermanFormat(this DateTime? dateTime, bool onlyDate = true)
        => dateTime is null
            ? throw new ArgumentNullException(nameof(dateTime), "DateTime cannot be null!")
            : ((DateTime)dateTime).ToGermanFormat(onlyDate);

    public static string ToMySQLFormat(this DateTime dateTime, bool onlyDate = true, bool h24 = true)
        => dateTime.ToString(onlyDate ? "yyyy-MM-dd" : $"yyyy-MM-dd {(h24 ? "HH" : "hh")}:mm:ss");

    public static string ToMySQLFormat(this DateTime? dateTime, bool onlyDate = true, bool h24 = true)
        => dateTime is null
            ? throw new ArgumentNullException(nameof(dateTime), "DateTime cannot be null!")
            : ((DateTime)dateTime).ToMySQLFormat(onlyDate, h24);
}