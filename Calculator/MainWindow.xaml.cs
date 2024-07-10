using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private string current_input = string.Empty;
        private string operation = string.Empty;
        private double f_numb = 0, s_numb = 0, result_numb = 0;
        
        public MainWindow()
        {
            InitializeComponent();
            text_result.Text = "0";
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
        }

        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            // Check if the key pressed is a number
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                int number = (int)e.Key - (int)Key.D0;
                numbering(number.ToString());
            }
            // Check if the key pressed is a number from the number pad
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                int number = (int)e.Key - (int)Key.NumPad0;
                numbering(number.ToString());
            }
            // Handle other keys like operations, Enter, Backspace, etc.
            else if (e.Key == Key.Add)
            {
                //Display.Text += "+";
                operation_function("+");
            }
            else if (e.Key == Key.Subtract)
            {
                operation_function("-");
            }
            else if (e.Key == Key.Multiply)
            {
                operation_function("X");
            }
            else if (e.Key == Key.Divide)
            {
                operation_function("/");
            }
            else if (e.Key == Key.Enter)
            {
                equal_result();
            }
            else if (e.Key == Key.Back)
            {
                delete();

            }
        }

        private void OnScreenKeyDown(object sender, RoutedEventArgs e)
        {
            String Key_screen = (sender as Button).Content.ToString();

            if (IsNumberBetween0And9(Key_screen))
            {
                numbering(Key_screen);
            }
            else if(Key_screen == "C")
            {
                clear();
            }
            else if(Key_screen == "<-")
            {
                delete();
            }
            else if(Key_screen == ".")
            {
                dot_point();
            }
            else if(Key_screen == "=")
            {
                equal_result();
            }
            else
            {
                operation_function(Key_screen);
            }
        }

        private void numbering(string number)
        {

            if (text_result.Text != "0" || number != "0")
            {
                current_input += number;
                text_result.Text = current_input;
            }

        }
        private void operation_function(string op)
        {
            
            bool c_state = string.IsNullOrEmpty(current_input);
            if (f_numb == 0 && !c_state)
            {

                f_numb = double.Parse(current_input);
                current_input = string.Empty;

                operation = op;

            }
            else if (f_numb != 0 && !c_state)
                {
                    s_numb = double.Parse(current_input);
                    switch (operation)
                    {
                        case "+":
                            {
                                f_numb += s_numb;
                                break;
                            }
                        case "-":
                            {
                                f_numb -= s_numb;
                                break;
                            }
                        case "X":
                            {
                                f_numb *= s_numb;
                                break;
                            }
                        case "/":
                            {
                                f_numb /= s_numb;
                                break;
                            }
                    }

                    operation = op;
                    current_input = string.Empty;
                    text_result.Text = f_numb.ToString();
                }
            else if (f_numb != 0 && c_state)
            {
                operation = op;
            }


        }

        

        private void clear()
        {
            current_input = string.Empty;
            operation = string.Empty;
            f_numb = 0;
            s_numb = 0;
            text_result.Text = string.Empty;
        }
        private void delete() 
        {
            if (text_result.Text.Length == 1)
            {
                text_result.Text = "0";
                current_input = string.Empty;
            }
            else
            {
                current_input = text_result.Text.Remove(text_result.Text.Length - 1);
                text_result.Text = current_input;
            }
        }

        private void dot_point()
        {
            if (!text_result.Text.Contains("."))
            {
                current_input = text_result.Text + ".";

                text_result.Text = current_input;
            }
        }

        private void equal_result()
        {
            bool c_state = string.IsNullOrEmpty(current_input);

            if (f_numb != 0 && c_state)
            {
                result_numb = f_numb;

                text_result.Text = result_numb.ToString();
                f_numb = 0; s_numb = 0; current_input = text_result.Text;
                operation = string.Empty;
            }
            else
            {
                if (f_numb != 0 && !c_state)
                {
                    s_numb = double.Parse(current_input);
                    switch (operation)
                    {
                        case "+":
                            {
                                f_numb += s_numb;
                                break;
                            }
                        case "-":
                            {
                                f_numb -= s_numb;
                                break;
                            }
                        case "X":
                            {
                                f_numb *= s_numb;
                                break;
                            }
                        case "/":
                            {
                                f_numb /= s_numb;
                                break;
                            }
                    }

                    operation = string.Empty;
                    result_numb = f_numb;
                    text_result.Text = result_numb.ToString();
                    f_numb = 0; s_numb = 0; current_input = text_result.Text;
                }
            }
        }

        bool IsNumberBetween0And9(string input)
        {
            // Try to parse the string as an integer
            if (int.TryParse(input, out int number))
            {
                // Check if the number is between 0 and 9
                if (number >= 0 && number <= 9)
                {
                    return true;
                }
            }
            return false;
        }
    }
}