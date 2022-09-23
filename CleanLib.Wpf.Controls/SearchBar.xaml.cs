using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CleanLib.Wpf.Controls;

/// <summary>Interaction logic for SearchBar.xaml</summary>
public partial class SearchBar : UserControl {
    public static readonly DependencyProperty SearchButtonTitleProperty = DependencyProperty.Register(nameof(SearchButtonTitle), typeof(string), typeof(SearchBar), new PropertyMetadata("Search"));
    public static readonly DependencyProperty SearchTextProperty = DependencyProperty.Register(nameof(SearchText), typeof(string), typeof(SearchBar), new PropertyMetadata(""));
    public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(SearchBar), new UIPropertyMetadata(null));
    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(SearchBar), new PropertyMetadata(new CornerRadius()));

    [DefaultValue("Search")]
    public string? SearchButtonTitle {
        get => (string)base.GetValue(SearchButtonTitleProperty);
        set => base.SetValue(SearchButtonTitleProperty, value);
    }

    [DefaultValue("")]
    public string? SearchText {
        get => (string)base.GetValue(SearchTextProperty);
        set => base.SetValue(SearchTextProperty, value);
    }

    [DefaultValue(null)]
    public ICommand? Command {
        get => (ICommand)base.GetValue(CommandProperty);
        set => base.SetValue(CommandProperty, value);
    }

    public CornerRadius CornerRadius {
        get => (CornerRadius)base.GetValue(CornerRadiusProperty);
        set => base.SetValue(CornerRadiusProperty, value);
    }

    public SearchBar() => this.InitializeComponent();
}