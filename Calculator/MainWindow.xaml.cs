using System.ComponentModel;
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
        private bool op_state = false;
        public MainWindow()
        {
            InitializeComponent();
            text_result.Text = "0";
        }

        private void click_number(object sender , RoutedEventArgs e)
        {
            
            string digit = (sender as Button).Content.ToString();
            if (text_result.Text != "0" || digit != "0")
            {
                current_input += digit;
                text_result.Text = current_input;
            }
            
        }

        private void click_opiration(object sender, RoutedEventArgs e)
        {
            
            bool c_state = string.IsNullOrEmpty(current_input);
            
            
            if (f_numb == 0 && !c_state)
            {
               
                f_numb = double.Parse(current_input);
                current_input = string.Empty;
                string op = (sender as Button).Content.ToString();
                operation = op;
                
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
                    }
                    string op = (sender as Button).Content.ToString();
                    operation = op;
                    current_input = string.Empty;
                    test_text.Text = f_numb.ToString();
                    text_result.Text = f_numb.ToString();
                }
            }
            
        }

        private void equal_Click(object sender, RoutedEventArgs e)
        {
            bool c_state = string.IsNullOrEmpty(current_input);

            if(f_numb != 0 && c_state)
            {
                result_numb = f_numb;

                text_result.Text = result_numb.ToString();
                f_numb = 0; s_numb = 0; current_input = text_result.Text;
                operation = string.Empty;
            }else
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
                    }
                    
                    operation = string.Empty;
                    result_numb = f_numb;
                    text_result.Text = result_numb.ToString() ;
                    test_text.Text = result_numb.ToString();
                    f_numb = 0; s_numb = 0; current_input = text_result.Text;
                }
            }
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            if(text_result.Text.Length == 1)
            {
                text_result.Text = "0";
            }else
            {
                string temp_s =  text_result.Text.Remove(text_result.Text.Length - 1);
                text_result.Text = temp_s;
            }
        }

        private void dot_Click(object sender, RoutedEventArgs e)
        {
            if(!text_result.Text.Contains("."))
            {
                current_input = text_result.Text + ".";
                
                text_result.Text = current_input;
            }
            
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            current_input = string.Empty;
            operation = string.Empty;
            f_numb = 0;
            s_numb = 0;
            text_result.Text = string.Empty;
        }
    }
}