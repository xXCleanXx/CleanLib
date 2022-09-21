using CleanLib.Xaml.Extensions;
using CleanLib.Xaml.Extensions.Abstractions;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Collections.Generic;

namespace CleanLib.Maui.Extensions;

[ContentProperty("EnumType")]
public class EnumExtension : EnumExtensionBase, IMarkupExtension<IEnumerable<EnumDescription>> {
    public IEnumerable<EnumDescription> ProvideValue(IServiceProvider serviceProvider) => base.ProvideValue();
    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => base.ProvideValue();
}