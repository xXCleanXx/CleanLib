using CleanLib.Common.Annotations.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanLib.Xaml.Extensions.Abstractions;

public abstract class EnumExtensionBase
{
    private Type _enumType;

    public Type EnumType
    {
        get => _enumType;
        set
        {
            if (value is null) throw new ArgumentNullException(nameof(EnumType), "Enum cannot be null!");
            if (!value.IsEnum) throw new ArgumentException("Type is not an enum!", nameof(EnumType));

            _enumType = value;
        }
    }

    protected EnumExtensionBase(Type enumType)
    {
        EnumType = enumType;
    }

    public IEnumerable<EnumDescription> ProvideValue()
        => from Enum value in Enum.GetValues(EnumType) select new EnumDescription(value, value.GetEnumDescription());
}