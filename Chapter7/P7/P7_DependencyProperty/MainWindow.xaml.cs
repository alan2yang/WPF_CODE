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
    public partial class MainWindow : Window
    {
        Student student;
        public MainWindow()
        {
            InitializeComponent();

            student = new Student();
            Binding binding = new Binding("Text") { Source = textbox1 };
            //BindingOperations.SetBinding(student, Student.nameProperty, binding);  //每个控件实现SetBinding()方法，但其实其内部也是使用的BindingOperations.SetBinding()方法
            student.SetBinding(Student.nameProperty, binding);

        }


        /// <summary>
        /// 设置依赖属性和获取依赖属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var stu = new Student();
            stu.Name = this.source.Text;
            this.target.Text = stu.Name;

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

        //为依赖属性添加一个CLR属性外包装
        public string Name
        {
            get { return (string)GetValue(nameProperty); }
            set { SetValue(nameProperty,value); }
        }

        // 给Student添加SetBinding方法，使其与控件一致
        public BindingExpressionBase SetBinding(DependencyProperty dp,BindingBase binding)
        {
            return BindingOperations.SetBinding(this, dp, binding);
        }



    }


}
