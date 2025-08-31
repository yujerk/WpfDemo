using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Windows;
using System.Windows.Controls;
using WpfDemo.Models.Entity;
using WpfDemo.Services;
using WpfDemo.View.window;
using WpfDemo.ViewModel;

namespace WpfDemo.View.page
{
    /// <summary>
    /// StudentView.xaml 的交互逻辑
    /// </summary>
    public partial class StudentView : Page
    {
        private StudentViewModel _viewModel;
        public StudentView(StudentViewModel? studentViewModel)
        {
            InitializeComponent();
            _viewModel = studentViewModel;
            DataContext = _viewModel;
            this.Loaded += StudentView_Loaded;
        }

        private void StudentView_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.LoadStudentsCommand.Execute(null);
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
        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new StudentEditWindow(null,_viewModel,true);
            
            editWindow.Closed += (s, e) =>
            {
                _viewModel.LoadStudentsCommand.Execute(null);
            };
            var result = editWindow.ShowDialog();

            // 可以根据需要处理返回结果
        }

        private void EditStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedStudent != null)
            {
                var editWindow = new StudentEditWindow(_viewModel.SelectedStudent,_viewModel,false);
                editWindow.Closed += (s, e) =>
                {
                    _viewModel.LoadStudentsCommand.Execute(null);
                };
                var result = editWindow.ShowDialog();
                // 可以根据需要处理返回结果
            }
            else
            {
                MessageBox.Show("请先选择一个学生进行编辑", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
