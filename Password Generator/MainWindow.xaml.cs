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
            this.Style = (Style)FindResource(typeof(Window));
        }

        private void CopyBT_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(PasswordTB.Text);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            val = Convert.ToInt32(Slider.Value);
            CharNumberTB.Text = val.ToString();
        }

        private void GenBT_Click(object sender, RoutedEventArgs e)
        {
            RandomPaswwordGen r1 = new RandomPaswwordGen();
            if (UpperCaseCB.IsChecked == true || LowerCaseCB.IsChecked == true || NumbersCB.IsChecked == true || SymbolsCB.IsChecked == true)
            {
                PasswordTB.Text = r1.Generate(val, UpperCaseCB.IsChecked, LowerCaseCB.IsChecked, NumbersCB.IsChecked, SymbolsCB.IsChecked);
            }
            else
            {
                MessageBox.Show("Choose characters for password.");
            }
        }
    }
}
