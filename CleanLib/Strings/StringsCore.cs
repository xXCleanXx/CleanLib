using System;
using System.Linq;

namespace CleanLib.Strings;

/// <summary>The core class for strings of the CleanLib.</summary>
public static class StringsCore {
    /// <summary>Sets the first <see cref="char"/> of a string to upper-case.</summary>
    /// <param name="str">The specfied <see cref="string"/>.</param>
    /// <returns>The <see cref="string"/> with the first <see cref="char"/> upper-case.</returns>
    public static string FirstToUpper(string str)
        => string.IsNullOrWhiteSpace(str)
            ? str
            : char.ToUpper(str[0]) + str.Substring(1);

    /// <summary>Checks if a <see cref="string"/> is numeric.</summary>
    /// <param name="str">The specified <see cref="string"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="str"/> is numeric; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="str"/> is <see langword="null"/>.</exception>
    public static bool IsNumeric(string str)
        => str is null
            ? throw new ArgumentNullException(nameof(str), "String cannot be null!")
            : !str.Any(x => char.IsLetter(x));
}