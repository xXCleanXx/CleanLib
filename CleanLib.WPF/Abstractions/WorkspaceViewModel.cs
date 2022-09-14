using CleanLib.Wpf.Controls;
using CleanLib.XAML.Interfaces;

namespace CleanLib.Wpf.Abstractions;

public abstract class WorkspaceViewModel : ViewModelBase {
    public Command<ICloseable> CloseCommand { get; }

    protected WorkspaceViewModel()
        => this.CloseCommand = new Command<ICloseable>(this.OnCloseCommand);

    public virtual void OnCloseCommand(ICloseable closeable) => closeable.Close();
}