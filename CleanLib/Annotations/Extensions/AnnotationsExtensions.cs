using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace CleanLib.Common.Annotations.Extensions;

public static class AnnotationsExtensions {
    public static string GetEnumDescription(this Enum value)
        => value is null
            ? throw new ArgumentNullException(nameof(value), "Value cannot be null!")
            : value.GetType().GetField(value.ToString())?.GetCustomAttributes<DescriptionAttribute>()?.FirstOrDefault()?.Description;
}