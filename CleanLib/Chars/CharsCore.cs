#pragma warning disable S3358 // Ternary operators should not be nested

using System;

namespace CleanLib.Common.Chars;

public static class CharsCore {
    /// <summary>Returns a character by its digit from 1-24.</summary>
    /// <param name="digit">Specified digit between 1 and 24.</param>
    /// <param name="upperCase">Determines if the output should be uppercase or not.</param>
    /// <returns>The character by its specified digit.</returns>
    /// <exception cref="ArgumentOutOfRangeException">If <paramref name="digit"/> is smaller than 1 or greater than 24.</exception>
    public static char DigitToChar(int digit, bool upperCase = false)
        => digit is < 1 or > 24
            ? throw new ArgumentOutOfRangeException(nameof(digit), "Digit must be in range of 1 to 24!")
            : upperCase
            ? char.ToUpper("abcdefghijklmnopqrstuvwxyz"[digit])
            : "abcdefghijklmnopqrstuvwxyz"[digit];
}