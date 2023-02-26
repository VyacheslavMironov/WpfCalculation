using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[]? DataButton { get; set; } = new string[2] { "", "" };
        public string Operator { get; set; } = "";
        public string TextField { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = TextField;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (Convert.ToString(btn.Content) == "+" || Convert.ToString(btn.Content) == "-" || Convert.ToString(btn.Content) == "*" || Convert.ToString(btn.Content) == "/")
            {
                this.ButtonOperatorValidate(sender, e);
            }
            else if (this.DataButton[0].Length > 0 && this.Operator.Length == 0 && this.DataButton[1].Length == 0)
            {
                this.DataButton[0] += Convert.ToString(btn.Content).Split("+")[0];
                inputField.Text += Convert.ToString(btn.Content);
            }
            else if (this.DataButton[1].Length > 1 && this.Operator.Length > 0 && this.DataButton[0].Length != 0)
            {
                this.DataButton[1] += Convert.ToString(btn.Content);
                inputField.Text += Convert.ToString(btn.Content);
            }
            else if (this.DataButton[0].Length == 0)
            {
                this.DataButton[0] = Convert.ToString(btn.Content);
                inputField.Text += this.DataButton[0];
            }
            else
            {
                this.DataButton[1] = Convert.ToString(btn.Content);
                inputField.Text += this.DataButton[1];
            }
            
        }

        private void ButtonOperatorValidate(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            this.Operator = Convert.ToString(btn.Content);
            inputField.Text += this.Operator;
        }

        public void Equals(object sender, RoutedEventArgs e)
        {
            string Result = "";
            switch (this.Operator)
            {
                case "+":
                    Result = Convert.ToString(Convert.ToInt32(this.DataButton[0]) + Convert.ToInt32(this.DataButton[1]));
                    break;

                case "-":
                    Result = Convert.ToString(Convert.ToInt32(this.DataButton[0]) - Convert.ToInt32(this.DataButton[1]));
                    break;

                case "*":
                    Result = Convert.ToString(Convert.ToInt32(this.DataButton[0]) * Convert.ToInt32(this.DataButton[1]));
                    break;

                case "/":
                    if (Convert.ToInt32(this.DataButton[0]) == 0 || Convert.ToInt32(this.DataButton[1]) == 0)
                    {
                        MessageBox.Show("На ноль делить нельзя!");
                    }
                    else
                    {
                        Result = Convert.ToString(Convert.ToInt32(this.DataButton[0]) / Convert.ToInt32(this.DataButton[1]));
                    }
                    
                    break;
            }
            inputField.Text = Result;
            // Запись в первый слот для дальнейшего взаимодействия
            this.DataButton[0] = Result;
            this.DataButton[1] = "";
            // Очистка оператора
            this.Operator="";
        }

        public void Clear(object sender, RoutedEventArgs e)
        {
            // Очистка всего
            this.DataButton[0] = "";
            this.DataButton[1] = "";
            this.Operator = "";
            inputField.Text = "";
        }
    }
}
