using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace P6_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.SetMultiBinding();
        }

        void SetMultiBinding()
        {
            var b1 = new Binding("Text") { Source = this.textBox1 };
            var b2 = new Binding("Text") { Source = this.textBox2 };
            var b3 = new Binding("Text") { Source = this.textBox3 };
            var b4 = new Binding("Text") { Source = this.textBox4 };

            var mb = new MultiBinding() { Mode = BindingMode.OneWay };
            mb.Bindings.Add(b1);
            mb.Bindings.Add(b2);
            mb.Bindings.Add(b3);
            mb.Bindings.Add(b4);
            mb.Converter = new LogonMultiBindingConverter();

            this.button1.SetBinding(Button.IsEnabledProperty, mb);
        }
    }

    public class LogonMultiBindingConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!values.Cast<string>().Any(text=>string.IsNullOrEmpty(text))&&values[0].ToString()==values[1].ToString()&& values[2].ToString() == values[3].ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
