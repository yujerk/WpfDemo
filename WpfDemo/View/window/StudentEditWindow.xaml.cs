using System.Windows;
using WpfDemo.Models.Entity;
using WpfDemo.ViewModel;

namespace WpfDemo.View.window
{
    public partial class StudentEditWindow : Window
    {
       
        private bool _isEditMode;
        private StudentViewModel _studentViewModel;
        private Student? _student;
        public StudentEditWindow(Student? student)
        {
            InitializeComponent();
            _studentViewModel = new StudentViewModel();
            _studentViewModel.OnRequestClose += OnViewModelRequestClose;
            // 绑定数据
            this.DataContext = _studentViewModel;
            if (student != null)
            {
                // 编辑模式
                _studentViewModel.Student = student;
                _isEditMode = true;
                EditButton.Visibility = Visibility.Visible;
                text.Text = "添加学生信息";
            }
            else
            {
                //添加模式
                _isEditMode = false;
                SaveButton.Visibility = Visibility.Visible;
                text.Text = "编辑学生信息";
                
            }
        }
        private void OnViewModelRequestClose(bool success)
        {
            this.Close();
        }
    }
}