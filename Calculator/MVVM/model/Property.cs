﻿using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Calculator.MVVM.model
{
    public class Property : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
