using demo.Models.Entity;
using System.Windows;
using WpfDemo.Model;
using WpfDemo.ViewModel;

namespace WpfDemo.View
{
    public partial class StudentEditWindow : Window
    {
        private StudentViewModel _viewModel;
        private Student _student;
        private bool _isEditMode;

        public StudentEditWindow(StudentViewModel viewModel, Student student = null)
        {
            InitializeComponent();
            _viewModel = viewModel;
            
            if (student != null)
            {
                // 编辑模式
                _student = student;
                _isEditMode = true;
                Title = "编辑学生信息";
            }
            else
            {
                // 添加模式
                _student = new Student();
                _isEditMode = false;
                Title = "添加学生信息";
            }

            // 绑定数据
            DataContext = _student;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // 简单验证
            if (string.IsNullOrWhiteSpace(_student.Name))
            {
                MessageBox.Show("请输入学生姓名", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(_student.StudentId))
            {
                MessageBox.Show("请输入学号", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_isEditMode)
            {
                // 编辑模式 - 更新学生信息
                var result = _viewModel.UpdateStudent(_student);
                if (result)
                {
                    MessageBox.Show("学生信息更新成功", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("学生信息更新失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                // 添加模式 - 添加新学生
                var result = _viewModel.AddStudent(_student);
                if (result)
                {
                    MessageBox.Show("学生添加成功", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("学生添加失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="student">要添加的学生</param>
        /// <returns>是否添加成功</returns>
        public bool AddStudent(Student student)
        {
            try
            {
                Students.Add(student);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 更新学生信息
        /// </summary>
        /// <param name="updatedStudent">更新后的学生信息</param>
        /// <returns>是否更新成功</returns>
        public bool UpdateStudent(Student updatedStudent)
        {
            try
            {
                var existingStudent = Students.FirstOrDefault(s => s.Id == updatedStudent.Id);
                if (existingStudent != null)
                {
                    // 更新学生信息
                    existingStudent.Name = updatedStudent.Name;
                    existingStudent.Age = updatedStudent.Age;
                    existingStudent.StudentId = updatedStudent.StudentId;
                    existingStudent.Major = updatedStudent.Major;
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}