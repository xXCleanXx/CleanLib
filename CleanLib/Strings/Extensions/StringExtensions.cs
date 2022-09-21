namespace CleanLib.Strings.Extensions;

/// <summary>Extensions for the <see cref="string"/>.</summary>
public static class StringExtensions {
    /// <summary>Checks if a <see cref="string"/> is numeric.</summary>
    /// <param name="str">The specified <see cref="string"/> instance.</param>
    /// <returns><see langword="true"/> if <paramref name="str"/> is numeric; otherwise <see langword="false"/>.</returns>
    /// <exception cref="System.ArgumentNullException">If <paramref name="str"/> is <see langword="null"/>.</exception>
    public static bool IsNumeric(this string str) => StringsCore.IsNumeric(str);

    /// <summary>Sets the first <see cref="char"/> of a string to upper-case.</summary>
    /// <param name="str">The specfied <see cref="string"/> instance.</param>
    /// <returns>The <see cref="string"/> with the first <see cref="char"/> upper-case.</returns>
    public static string FirstToUpper(this string str) => StringsCore.FirstToUpper(str);

    /// <summary>Embraces a <see cref="string"/> with a specified <see cref="char"/>.</summary>
    /// <param name="str">The specified <see cref="string"/> instance.</param>
    /// <param name="embraceChar">The specified <see cref="char"/> to embrace a <see cref="string"/>.</param>
    /// <returns>The <see cref="string"/> which is embraced with the specified <see cref="char"/>.</returns>
    public static string Embrace(this string str, char embraceChar = '\'') => $"{embraceChar}{str}{embraceChar}";
}