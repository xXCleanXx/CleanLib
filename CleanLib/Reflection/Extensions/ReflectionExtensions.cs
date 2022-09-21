using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace CleanLib.Reflection.Extensions;

/// <summary>Extensions for Reflections</summary>
public static class ReflectionExtensions {
    /// <summary>Gets the description of an enum constant.</summary>
    /// <param name="value">The specified <see cref="Enum"/>.</param>
    /// <returns>Tries to get the description of the specified <see cref="Enum"/> constant; otherwise <see langword="null"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is <see langword="null"/>.</exception>
    public static string GetEnumDescription(this Enum value)
        => value is null
            ? throw new ArgumentNullException(nameof(value), "Value cannot be null!")
            : value.GetType().GetField(value.ToString())?.GetCustomAttributes<DescriptionAttribute>()?.FirstOrDefault()?.Description;
}