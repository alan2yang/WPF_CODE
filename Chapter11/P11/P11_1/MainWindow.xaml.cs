using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using P11_1.models;


namespace P11_1
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
            };
            foreach (Car car in carList)
            {
                CarListItemView view = new CarListItemView();
                view.Car = car;
                this.listBoxCars.Items.Add(view);
            }
        }

        private void listBoxCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarListItemView view = e.AddedItems[0] as CarListItemView;
            if (view!=null)
            {
                this.detailView.Car = view.Car;
            }
        }
    }
}
