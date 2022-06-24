namespace CleanLib.Common.Strings.Extensions;

public static class StringsExtensions {
    public static bool IsNumeric(this string str) => StringsCore.IsNumeric(str);

    public static string FirstToUpper(this string str) => StringsCore.FirstToUpper(str);

    public static string Embrace(this string str, char embraceChar = '\'') => embraceChar + str + embraceChar;
}