using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using WpfDemo.Models.Entity;
using WpfDemo.ViewModel;

namespace WpfDemo.View.window
{
    public partial class StudentEditWindow : Window
    {
        private bool _isEditMode;
        private StudentViewModel _studentViewModel;
        public StudentEditWindow(Student? student,StudentViewModel studentViewModel,bool isEditMode)
        {
            InitializeComponent();
            _studentViewModel = studentViewModel;
            _studentViewModel.OnRequestClose += OnViewModelRequestClose;
            _isEditMode = isEditMode;
            // 绑定数据
            this.DataContext = _studentViewModel;
            if (student != null && !isEditMode)
            {
                // 编辑模式
                _studentViewModel.Student = student;
                EditButton.Visibility = Visibility.Visible;
                text.Text = "编辑学生信息";
            }
            else
            {
                _studentViewModel.Student = new Student();
                //添加模式
                SaveButton.Visibility = Visibility.Visible;
                text.Text = "添加学生信息";
            }
            Loaded += StudentEditWindow_Loaded;
        }
        private void OnViewModelRequestClose(bool success)
        {
            this.Close();
        }
        private void CloseButton(object sender, RoutedEventArgs e)
        { 
            this.Close();
        }
        private void StudentEditWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // 强制验证所有 TextBox
            ForceValidation(FirstNameText);
            ForceValidation(LastNameText);
        }

        private void ForceValidation(TextBox textBox)
        {
            // 触发验证
            var bindingExpression = textBox.GetBindingExpression(TextBox.TextProperty);
            bindingExpression?.UpdateSource();
        }
    }
}