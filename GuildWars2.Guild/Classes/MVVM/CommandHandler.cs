using System;
using System.Windows.Input;

namespace GuildWars2Guild.Classes.MVVM
{
    public class CommandHandler : ICommand
    {
        private Action _action;

        public CommandHandler(Action action) {
            _action = action;
        }
        
#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) {
            _action();
        }
    }

    public class PaletteCommandHandler : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public PaletteCommandHandler(Action<object> execute) : this(execute, null) {
        }

        public PaletteCommandHandler(Action<object> execute, Func<object, bool> canExecute) {
            if(execute == null)
                throw new ArgumentNullException(nameof(execute));

            _execute = execute;
            _canExecute = canExecute ?? (x => true);
        }

        public bool CanExecute(object parameter) => _canExecute(parameter);

        public void Execute(object parameter) {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Refresh() {
            CommandManager.InvalidateRequerySuggested();
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _handler;

        public RelayCommand(Action<object> handler) {
            _handler = handler;
        }

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) {
            _handler(parameter);
        }
    }
}
