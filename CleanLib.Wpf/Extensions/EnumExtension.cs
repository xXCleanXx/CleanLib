using CleanLib.Xaml.Extensions.Abstractions;
using System;
using System.Windows.Markup;

namespace CleanLib.Wpf.Extensions;

public class EnumExtension : MarkupExtension {
    private readonly Base _enumExtensionBase;

    public EnumExtension(Type enumType) {
        this._enumExtensionBase = new Base(enumType);
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
        => this._enumExtensionBase.ProvideValue();

    private sealed class Base : EnumExtensionBase {
        internal Base(Type enumType) : base(enumType) { }
    }
}