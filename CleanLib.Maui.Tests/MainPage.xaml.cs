using CleanLib.Maui.Extensions;
using CleanLib.Xaml.Extensions;
using System.Diagnostics;

namespace CleanLib.Maui.Tests;

public partial class MainPage : ContentPage {
    public MainPage() {
        InitializeComponent();

        EnumExtension ee = new EnumExtension();
        ee.EnumType = typeof(EnumTest);

        IEnumerable<EnumDescription> descriptions = ee.ProvideValue();

        foreach (string item in descriptions.Select(x => x.Description)) {
            Debug.Print(item);
        }
    }
}