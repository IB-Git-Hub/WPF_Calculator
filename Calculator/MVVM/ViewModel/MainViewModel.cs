using Calculator.MVVM.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                _showpanel = value;
                Porpertychanged(_showpanel);
            } 
        }
    }
}
