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

namespace P9_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeCommand();
        }

        private RoutedCommand clearCommand = new RoutedCommand("Clear",typeof(MainWindow));

        private void InitializeCommand()
        {
            this.button1.Command = this.clearCommand;
            this.clearCommand.InputGestures.Add(new KeyGesture(Key.C,ModifierKeys.Alt));  //设置快捷键

            this.button1.CommandTarget = this.textbox1;

            CommandBinding cb = new CommandBinding();
            cb.Command = this.clearCommand;
            cb.CanExecute += new CanExecuteRoutedEventHandler(cb_CanExecute);
            cb.Executed += new ExecutedRoutedEventHandler(cb_Executed);
            this.stackPanel.CommandBindings.Add(cb);
        }

        /// <summary>
        /// 执行频率比较高
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cb_CanExecute(object sender,CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.textbox1.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        void cb_Executed(object sender,ExecutedRoutedEventArgs e)
        {
            this.textbox1.Clear();
            e.Handled = true;  //避免继续向上传递
        }


    }
}
