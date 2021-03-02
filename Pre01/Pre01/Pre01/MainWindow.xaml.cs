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

namespace Pre01
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Dock GetCurrentDock()
        {
            Dock dockValue = Dock.Top;
            if (this.dockCombo.SelectedItem==this.dockTop)
            {
                dockValue = Dock.Top;
            }
            else if (this.dockCombo.SelectedItem == this.dockBottom)
            {
                dockValue = Dock.Bottom;
            }
            else if (this.dockCombo.SelectedItem == this.dockLeft)
            {
                dockValue = Dock.Left;
            }
            else if (this.dockCombo.SelectedItem == this.dockRight)
            {
                dockValue = Dock.Right;
            }
            return dockValue;
        }


        private void controlCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem lbi = ((sender as ComboBox).SelectedItem as ComboBoxItem);

            if (lbi==this.button1)
            {
                this.btn.SetValue(DockPanel.DockProperty, GetCurrentDock());
            }
            if (lbi==this.blockText1)
            {
                this.tb.SetValue(DockPanel.DockProperty,GetCurrentDock());
            }
            if (lbi==this.circle)
            {
                this.ellps.SetValue(DockPanel.DockProperty,GetCurrentDock());
            }

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem lbi = ((sender as ComboBox).SelectedItem as ComboBoxItem);

            if (lbi.Name=="LastChildTrue")
            {
                myDP.LastChildFill = true;
            }
            else
            {
                myDP.LastChildFill = false;
            }
        }
    }
}
