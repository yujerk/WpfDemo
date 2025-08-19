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
using WpfNavigationTutorial.Model;

namespace WpfDemo
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

        // 页面缓存
        private static readonly Dictionary<Type, Page> bufferedPages =
            new Dictionary<Type, Page>();

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        // 导航菜单项选择事件处理程序
        private void NavMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 如果选择项不是 FrameworkElement, 则返回
            if (navMenu.SelectedItem is not NavigationItem item)
                return;

            Type type =
                item.TargetPageType;

            // 如果页面缓存中找不到页面, 则创建一个新的页面并存入
            if (!bufferedPages.TryGetValue(type, out Page? page))
                page = bufferedPages[type] =
                    Activator.CreateInstance(type) as Page ?? throw new Exception("this would never happen");

            appFrame.Navigate(page);
        }
    }
}