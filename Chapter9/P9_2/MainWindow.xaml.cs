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

namespace P9_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.nameTextBox.Text))
            {
                e.CanExecute= false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string name = this.nameTextBox.Text;

            if (e.Parameter.ToString()=="Teacher")
            {
                this.listBoxNewItems.Items.Add($"New Teacher:{name}!");
            }
            if (e.Parameter.ToString()=="Student")
            {
                this.listBoxNewItems.Items.Add($"New Student:{name}");
            }
            e.Handled = true;
        }
    }
}
