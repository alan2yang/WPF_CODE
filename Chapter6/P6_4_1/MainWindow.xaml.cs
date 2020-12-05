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

namespace P6_4_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Binding binding = new Binding("Value") { Source = this.slider1 };
            var rvr = new RangeValidationRule();
            //binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            rvr.ValidatesOnTargetUpdated = true;  //也校验数据从target到source
            binding.ValidationRules.Add(rvr);
            binding.NotifyOnValidationError = true;  //发布验证失败异常消息
            this.textBox1.SetBinding(TextBox.TextProperty, binding);

            this.textBox1.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(this.ValidationErrorHandler));  //添加异常消息处理函数
        }

        void ValidationErrorHandler(object sender,RoutedEventArgs e)
        {
            if (Validation.GetErrors(this.textBox1).Count>0)
            {
                this.textBox1.ToolTip = Validation.GetErrors(this.textBox1)[0].ErrorContent.ToString();
            }
        }
    }

    /// <summary>
    /// 自定义validationrule
    /// </summary>
    public class RangeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double d = 0;
            if (double.TryParse(value.ToString(),out d))
            {
                if (d>=0&&d<=100)
                {
                    return new ValidationResult(true, null);
                }
            }
            return new ValidationResult(false, "validation failed!");
        }
    }
}
