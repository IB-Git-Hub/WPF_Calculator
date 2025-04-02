using System.ComponentModel;

namespace Calculator.MVVM.model
{
    public class Property : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        public static void Porpertychanged(string propertyName)
        {
            
        }
    }
}

