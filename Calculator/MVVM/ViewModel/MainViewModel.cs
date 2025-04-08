using Calculator.MVVM.model;
using System.ComponentModel;
using System.Windows.Input;

namespace Calculator.MVVM
{
    class MainViewModel : Property
    {
        private string _showpanel;
        public string Showpanel
        {  
            get { return _showpanel; } 
            set 
            {
                if (_showpanel != value)
                {
                    _showpanel = value;
                    OnPropertyChanged(nameof(Showpanel));
                }
            } 
        }

        public ICommand key {  get;}

        public MainViewModel()
        {
            key = new RelayCommand(ButtonClick);
        }

        private void ButtonClick()
        {

        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool> _canExecute;

        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute ?? (_ => true);
        }

        public bool CanExecute(object? parameter) => _canExecute(parameter);

        public void Execute(object? parameter) => _execute(parameter);

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}