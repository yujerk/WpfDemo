using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDemo.Models;
using WpfDemo.View.page;
using WpfDemo.ViewModel;

namespace WpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly StudentViewModel _studentViewModel;
        private readonly MainWindowModel _mainWindowModel;
        public MainWindow(StudentViewModel studentViewModel, MainWindowModel mainWindowModel)
        {
            _studentViewModel= studentViewModel;
            _mainWindowModel = mainWindowModel;
            InitializeComponent();
        }

        // 页面缓存
        private static readonly Dictionary<Type, Page> bufferedPages =
            new Dictionary<Type, Page>();

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        // 导航菜单项选择事件处理程序
        private void NavMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 如果选择项不是 NavigationItem, 则返回
            if (navMenu.SelectedItem is not NavigationItem item)
                return;

            Type type = item.TargetPageType;

            Page page;

            // 检查页面缓存
            if (!bufferedPages.TryGetValue(type, out page))
            {
                // 使用反射检查构造函数
                var constructors = type.GetConstructors();
                var defaultConstructor = constructors.FirstOrDefault(c => c.GetParameters().Length == 0);

                if (defaultConstructor != null)
                {
                    // 有无参数构造函数
                    page = Activator.CreateInstance(type) as Page ??
                           throw new Exception("无法创建页面实例");
                }
                else
                {
                    // 没有无参数构造函数，需要特殊处理
                    if (type == typeof(StudentView))
                    {
                        page = Activator.CreateInstance(type, _studentViewModel) as Page ??
                           throw new Exception("无法创建页面实例");
                    }
                    else
                    {
                        throw new InvalidOperationException($"页面 {type.Name} 没有无参数构造函数且未在导航逻辑中特殊处理");
                    }
                }

                // 缓存页面
                bufferedPages[type] = page;
            }

            appFrame.Navigate(page);
        }
    }
}