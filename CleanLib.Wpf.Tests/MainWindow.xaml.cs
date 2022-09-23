using CleanLib.Wpf.Controls;
using System.Diagnostics;
using System.Windows;

namespace CleanLib.Wpf.Tests;

/// <summary>Interaction logic for MainWindow.xaml</summary>
public partial class MainWindow : Window {
    public Command SearchCommand { get; } = new Command(() => Debug.Print("Search successful!"));

    public MainWindow() {
        InitializeComponent();

        this.DataContext = this;
    }
}