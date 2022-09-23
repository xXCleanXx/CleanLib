using CleanLib.Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanLib.Xaml.Extensions.Abstractions;

/// <summary>The base class of the EnumExtension class which is implemented in the libraries CleanLib.Maui and CleanLib.Wpf.</summary>
public abstract class EnumExtensionBase
{
    private Type _enumType;

    /// <summary>The specified <see cref="Type"/> of the <see cref="Enum"/>.</summary>
    /// <exception cref="ArgumentNullException">If the <see cref="Enum"/> <see cref="Type"/> is <see langword="null"/>.</exception>
    public Type EnumType
    {
        get => this._enumType;
        set
        {
            if (value is null) throw new ArgumentNullException(nameof(this.EnumType), "Enum cannot be null!");
            if (!value.IsEnum) throw new ArgumentException("Type is not an enum!", nameof(this.EnumType));

            this._enumType = value;
        }
    }

    /// <summary>Implements a new instance of the <see cref="EnumExtensionBase"/>.</summary>
    /// <param name="enumType">The specified enum <see cref="Type"/>.</param>
    protected EnumExtensionBase(Type enumType) => this.EnumType = enumType;

    /// <summary>Implements a new instance of the <see cref="EnumExtensionBase"/>.</summary>
    protected EnumExtensionBase() { }

    /// <summary>Gets an <see cref="IEnumerable{T}"/> of the descriptions of an <see cref="Enum"/>.</summary>
    /// <returns>The <see cref="IEnumerable{T}"/> of the descriptions of the <see cref="Enum"/>.</returns>
    public IEnumerable<EnumDescription> ProvideValue() {
        IEnumerable<EnumDescription> descriptions = from Enum value in Enum.GetValues(this.EnumType) select new EnumDescription(value, value.GetEnumDescription());

        return descriptions;
    }
}