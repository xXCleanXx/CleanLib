using CleanLib.Common.Annotations.Extensions;
using System;
using System.Linq;
using System.Windows.Markup;

namespace CleanLib.Wpf.Extensions;

public class EnumExtension : MarkupExtension {
    private Type _enumType;

    public Type EnumType {
        get => this._enumType;
        set {
            if (value is null) throw new ArgumentNullException(nameof(this.EnumType), "Enum cannot be null!");
            if (!value.IsEnum) throw new ArgumentException("Type is not an enum!", nameof(this.EnumType));

            this._enumType = value;
        }
    }

    public EnumExtension(Type enumType) {
        this.EnumType = enumType;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
        => from Enum value in Enum.GetValues(this.EnumType) select value.GetEnumDescription();

    public class EnumValue {
        public Enum Value { get; }
        public string Description { get; }

        public EnumValue(Enum value, string description) {
            this.Value = value;
            this.Description = description;
        }
    }
}