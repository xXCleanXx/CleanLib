using System.Linq;

namespace CleanLib.Common.Strings;

public static class StringsCore {
    public static string FirstToUpper(string str)
        => string.IsNullOrWhiteSpace(str)
            ? str
            : char.ToUpper(str[0]) + str.Substring(1);

    public static bool IsNumeric(string str)
        => !str.Any(x => char.IsLetter(x));
}