using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using P11_1.models;


namespace P11_1
{
    /// <summary>
    /// CarDetailView.xaml 的交互逻辑
    /// </summary>
    public partial class CarDetailView : UserControl
    {
        public CarDetailView()
        {
            InitializeComponent();
        }


        private Car car;

        public Car Car
        {
            get { return car; }
            set
            {
                car = value;
                this.textBlockAutomaker.Text = car.Automaker;
                this.textBlockName.Text = car.Name;
                this.textBlockYear.Text = car.Year;
                this.textBlockTopSpeed.Text = car.TopSpeed;
                string uriStr = string.Format(@"Resources/Images/{0}.jpg", Car.Automaker);
                this.imagePhoto.Source = new BitmapImage(new Uri(uriStr, UriKind.Relative));
            }
        }
    }
}
