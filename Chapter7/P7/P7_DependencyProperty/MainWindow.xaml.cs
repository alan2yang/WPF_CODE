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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var stu = new Student();
            School.SetNum(stu, "001");
            string num = School.GetNum(stu);
            MessageBox.Show(num);
        }
    }

    public class Student : DependencyObject
    {
        public static readonly DependencyProperty nameProperty = DependencyProperty.Register("Name", typeof(String), typeof(Student));

        //为依赖属性添加一个CLR属性外包装
        public string Name
        {
            get { return (string)GetValue(nameProperty);}
            set { SetValue(nameProperty,value); }
        }

        // 给Student添加SetBinding方法，使其与控件一致
        public BindingExpressionBase SetBinding(DependencyProperty dp,BindingBase binding)
        {
            return BindingOperations.SetBinding(this, dp, binding);
        }
    }


    public class School : DependencyObject
    {
        //被学校添加附加属性的对象也要是依赖对象
        //学校获取学生对象的属性
        public static string GetNum(DependencyObject obj)
        {
            return (string)obj.GetValue(NumProperty);
        }

        //给进入学校的学生对象添加属性
        public static void SetNum(DependencyObject obj, string value)
        {
            obj.SetValue(NumProperty, value);
        }

        //附加属性：学号   PropertyMetadata("")指定默认值
        public static readonly DependencyProperty NumProperty =DependencyProperty.RegisterAttached("Num", typeof(string), typeof(School), new PropertyMetadata(""));

    }

}
