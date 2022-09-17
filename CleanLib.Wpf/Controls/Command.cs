using System;
using System.Windows.Input;

namespace CleanLib.Wpf.Controls;

public class Command : ICommand {
    public event EventHandler CanExecuteChanged;

    private Action<object> _execute;
    private readonly Func<object, bool> _canExecute;

    public Command(Action<object> execute) : this(execute, null) { }

    public Command(Action execute) : this(execute, null) { }

    public Command(Action<object> execute, Func<object, bool> canExecute) {
        this._execute = execute ?? throw new ArgumentNullException(nameof(execute), "Execute cannot be null!");
        this._canExecute = canExecute;
    }

    public Command(Action execute, Func<bool> canExecute) {
        this.SetExecute(execute);
        this._canExecute = canExecute != null ? new Func<object, bool>(param => canExecute()) : this._canExecute;
    }

    private void SetExecute(Action execute) {
        if (execute == null) throw new ArgumentNullException(nameof(execute), "Execute cannot be null!");

        this._execute = new(param => execute());
    }

    public void ChangeCanExecute() {
        this.CanExecuteChanged?.Invoke(nameof(ChangeCanExecute), EventArgs.Empty);
    }

    public bool CanExecute(object parameter)
        => this._canExecute == null || this._canExecute(parameter);

    public void Execute(object parameter) => this._execute(parameter);
}