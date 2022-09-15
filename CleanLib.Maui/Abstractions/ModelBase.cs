using Microsoft.Maui.Controls;
using System.Runtime.CompilerServices;

namespace CleanLib.Maui.Abstractions;

public abstract class ModelBase : BindableObject {
    protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null) {
        if (Equals(storage, value)) return false;

        storage = value;

        base.OnPropertyChanged(propertyName);

        return true;
    }
}
