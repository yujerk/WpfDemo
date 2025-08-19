
using System.Windows;
using WpfDemo.Models.Entity;
using WpfDemo.ViewModel;

namespace WpfDemo.View.window
{
    public partial class StudentEditWindow : Window
    {
        private bool _isEditMode;

        public StudentEditWindow(Student? student)
        {
            InitializeComponent();
            // 绑定数据
            this.DataContext = new StudentViewModel();
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        { 
            var student = DataContext as StudentViewModel;
            MessageBox.Show($"保存成功{student.student.FirstMidName}");
        }
    }
}