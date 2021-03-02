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

namespace P7_DependencyProperty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Student student;
        public MainWindow()
        {
            InitializeComponent();

            student = new Student();
            Binding binding = new Binding("Text") { Source = textbox1 };
            BindingOperations.SetBinding(student, Student.nameProperty, binding);  //控件实现SetBinding()方法，但其实其内部也是使用的BindingOperations.SetBinding()方法
            
        }


        /// <summary>
        /// 设置依赖属性和获取依赖属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var stu = new Student();
            stu.SetValue(Student.nameProperty, this.source.Text);
            this.target.Text = (string)stu.GetValue(Student.nameProperty);

        }

        /// <summary>
        /// 通过依赖属性进行数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           MessageBox.Show(student.GetValue(Student.nameProperty).ToString());
        }
    }

    public class Student : DependencyObject
    {
        public static readonly DependencyProperty nameProperty = DependencyProperty.Register("Name", typeof(String), typeof(Student));



    }


}
