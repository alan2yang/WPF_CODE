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
using P11_2.models;

namespace P11_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitiaCarList();
        }


        private void InitiaCarList()
        {
            List<Car> carList = new List<Car>()
            {
                new Car(){Automaker="1",Name="Diablo",Year="1990",TopSpeed="340"},
                new Car(){Automaker="2",Name="Murcielago",Year="2001",TopSpeed="353"},
                new Car(){Automaker="3",Name="Gallaro",Year="2003",TopSpeed="326"},
                new Car(){Automaker="4",Name="Reventon",Year="2008",TopSpeed="345"},
                new Car(){Automaker="5",Name="Rev",Year="2018",TopSpeed="450"},
            };
            this.listBoxCars.ItemsSource = carList;
        }

    }

    public class PhotoPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string uriStr = string.Format(@"/Resources/Images/{0}.jpg", (string)value);
            return new BitmapImage(new Uri(uriStr,UriKind.Relative));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
