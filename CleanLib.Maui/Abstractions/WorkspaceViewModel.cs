using CleanLib.Xaml.Interfaces;
using Microsoft.Maui.Controls;

namespace CleanLib.Maui.Abstractions;

public abstract class WorkspaceViewModel {
    public Command<ICloseable> CloseCommand { get; }


    protected WorkspaceViewModel()
        => this.CloseCommand = new Command<ICloseable>(this.OnCloseCommand);

    public virtual void OnCloseCommand(ICloseable closeable) => closeable.Close();
}