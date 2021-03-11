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

namespace P8_2
{
   /// <summary>
   /// 自定义路由事件
   /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
    }


    class TimeButton : Button
    {
        //声明路由事件并注册,指定事件处理函数的参数类型
        public static readonly RoutedEvent ReportTimeEvent = EventManager.RegisterRoutedEvent("ReportTime",RoutingStrategy.Bubble,typeof(EventHandler<ReportTimeEventArgs>),typeof(TimeButton));


        //将路由事件包装为CLR事件
        public event RoutedEventHandler ReportTime
        {
            add { this.AddHandler(ReportTimeEvent,value); }
            remove { this.RemoveHandler(ReportTimeEvent,value); }
        }


        //???
        protected override void OnClick()
        {
            base.OnClick();

            ReportTimeEventArgs args = new ReportTimeEventArgs(ReportTimeEvent,this);
            args.clickTime = DateTime.Now;
            this.RaiseEvent(args);
        }

    }


    class ReportTimeEventArgs : RoutedEventArgs
    {
        public DateTime clickTime { get; set; }
        public ReportTimeEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {

        }
    }
}
