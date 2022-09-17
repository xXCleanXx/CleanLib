using System;

namespace CleanLib.Wpf.Controls;

public class Command<T> : Command {
    public Command(Action<T> execute) : base(param => execute((T)param)) { }

    public Command(Action<T> execute, Func<T, bool> canExecute) : base(param => execute((T)param), param => canExecute((T)param)) {
    }
}