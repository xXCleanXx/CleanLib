using CleanLib.Xaml.Extensions;
using CleanLib.Xaml.Extensions.Abstractions;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Collections.Generic;

namespace CleanLib.Maui.Extensions;
public class EnumExtension : IMarkupExtension<IEnumerable<EnumDescription>> {
    private readonly Base _enumExtensionBase;

    public EnumExtension(Type enumType) {
        this._enumExtensionBase = new(enumType);
    }

    public IEnumerable<EnumDescription> ProvideValue(IServiceProvider serviceProvider)
        => this.ProvideValue(serviceProvider);

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        => this._enumExtensionBase.ProvideValue();

    private sealed class Base : EnumExtensionBase {
        internal Base(Type enumType) : base(enumType) { }
    }
}