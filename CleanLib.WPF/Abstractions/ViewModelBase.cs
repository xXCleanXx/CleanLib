using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CleanLib.Wpf.Abstractions;

public abstract class ViewModelBase : INotifyPropertyChanged {
    public event PropertyChangedEventHandler PropertyChanged;

    protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null) {
        if (Equals(storage, value)) return false;

        storage = value;

        this.OnPropertyChanged(propertyName);

        return true;
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        => this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
}