using demo.Models.Entity;
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

namespace WpfDemo.View
{
    /// <summary>
    /// StudentView.xaml 的交互逻辑
    /// </summary>
    public partial class StudentView : Page
    {
        public StudentView()
        {
            InitializeComponent();
        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                if (list.SelectedItem is Student selectedStudent)
                {
                    // 获取学生的基本信息
                    string studentInfo = $"姓名: {selectedStudent.FullName}\n" +
                                       $"学号: {selectedStudent.Id}\n" +
                                       $"注册日期: {selectedStudent.EnrollmentDate?.ToString("yyyy-MM-dd") ?? "未注册"}";

                    MessageBox.Show(studentInfo);
                }
                else
                {
                    // 如果不是Student类型，显示默认信息
                    MessageBox.Show($"选中项: {list.SelectedItem.ToString()}");
                }
            }
            else
            {
                MessageBox.Show("未选择任何项");
            }
        }
    }
}
