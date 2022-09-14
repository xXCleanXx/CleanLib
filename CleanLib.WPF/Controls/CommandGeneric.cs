using System;
using System.Windows.Input;

namespace CleanLib.Wpf.Controls;

public sealed class Command<T> : ICommand {
    public event EventHandler CanExecuteChanged;

    private Action<T> _execute;
    private readonly Func<T, bool> _canExecute;

    public Command(Action<T> execute) : this(execute, null) { }

    public Command(Action execute) : this(execute, null) { }

    public Command(Action<T> execute, Func<T, bool> canExecute) {
        this._execute = execute ?? throw new ArgumentNullException(nameof(execute), "Execute cannot be null!");
        this._canExecute = canExecute;
    }

    public Command(Action execute, Func<bool> canExecute) {
        this.SetExecute(execute);
        this._canExecute = canExecute != null ? new Func<T, bool>((param) => canExecute()) : this._canExecute;
    }

    private void SetExecute(Action execute) {
        if (execute == null) throw new ArgumentNullException(nameof(execute), "Execute cannot be null!");

        this._execute = new((param) => execute());
    }

    public bool CanExecute(object parameter)
        => this._canExecute == null || this._canExecute((T)parameter);

    public void Execute(object parameter) => this._execute((T)parameter);
}