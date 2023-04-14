using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Password_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int val;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {
            RandomPaswwordGen r1 = new RandomPaswwordGen();
            if(UpperCaseCB.IsChecked == true || LowerCaseCB.IsChecked == true || NumbersCB.IsChecked == true || SymbolsCB.IsChecked == true)
            {
                TB1.Text = r1.Generate(val, UpperCaseCB.IsChecked, LowerCaseCB.IsChecked, NumbersCB.IsChecked, SymbolsCB.IsChecked);
            }
            else
            {
                MessageBox.Show("Choose characters for password.");
            }
        }

        private void B2_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(TB1.Text);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            val = Convert.ToInt32(S1.Value);
            TB2.Text = val.ToString();
        }
    }

    class RandomPaswwordGen
    {
        
        public string Generate(int length, bool? cb1, bool? cb2, bool? cb3, bool? cb4)
        {
            Random rnd = new Random();
            string symbols = "~`!@#$%^&*()_-+={[}]|\\:;\"'<,>.?/";
            string password = "";

            for(int i = 0; i < length; i++)
            {
                int random = rnd.Next(4);
                if (random == 0)
                {
                    if(cb1 == true)
                    {
                        char letter = Convert.ToChar(rnd.Next('A', 'Z' + 1));
                        password += letter;
                    }
                    else
                    {
                        i--;
                    }
                }
                else if(random == 1)
                {
                    if (cb2 == true)
                    {
                        char letter = Convert.ToChar(rnd.Next('a', 'z' + 1));
                        password += letter;
                    }
                    else
                    {
                        i--;
                    }
                }
                else if (random == 2)
                {
                    if (cb3 == true)
                    {
                        string number = rnd.Next(10).ToString();
                        password += number;
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    if (cb4 == true)
                    {
                        char symbol = Convert.ToChar(symbols[rnd.Next(symbols.Length)]);
                        password += symbol;
                    }
                    else
                    {
                        i--;
                    }
                }
            }
            return password;
        }
    }
}
