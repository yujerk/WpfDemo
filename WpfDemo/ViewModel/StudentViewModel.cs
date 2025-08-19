using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfDemo.Models.DTO;
using WpfDemo.Models.Entity;
using WpfDemo.Services;

namespace WpfDemo.ViewModel
{
    public class StudentViewModel : ObservableObject
    {
        private readonly StudentService studentService;

        public ObservableCollection<Student> students { get; }

        private Student? _selectedStudent;

        public Student student{ get; set; }
        


        public ICommand LoadStudentsCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand AddStudentCommand { get; }
        public ICommand EditStudentCommand { get; }
        public ICommand DeleteStudentCommand { get; }
        public ICommand ViewDetailsCommand { get; }
        // 更新构造函数中的命令初始化
        public StudentViewModel()
        {
            studentService = new StudentService();
            students = new ObservableCollection<Student>();
            student=new Student();

            LoadStudentsCommand = new RelayCommand(async () => await LoadStudents());
            SearchCommand = new RelayCommand<string>(FilterStudents);
            AddStudentCommand = new RelayCommand<Student>(AddStudent);
            EditStudentCommand = new RelayCommand<Student>(EditStudent);
            DeleteStudentCommand = new RelayCommand<int>(DeleteStudent);
            //ViewDetailsCommand = new RelayCommand(() => ViewDetails(), () => CanViewDetails);
        }
        public Student? SelectedStudent
        {
            get => _selectedStudent;
            set => SetProperty(ref _selectedStudent, value);
        }

        private async Task LoadStudents()
        {
            MessageBox.Show("加载学生数据");

           
            try
            {
                var _students = await studentService.GetStudentsAsync();
                students.Clear();
                foreach (var student in _students)
                {
                    students.Add(student);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载学生数据失败: {ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private string filterText = string.Empty;

        public string FilterText { get => filterText; set => SetProperty(ref filterText, value); }
        // 修改 FilterStudents 方法以接受 string? 类型参数，确保与 RelayCommand<string> 的委托类型匹配
        private async void FilterStudents(string? id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("请输入有效的学生ID。", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!int.TryParse(id, out int idInt))
            {
                MessageBox.Show("学生ID格式不正确。", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show($"筛选学生数据: {idInt}");
            try
            {
                var filteredStudents = await studentService.GetStudentAsync(idInt);
                if (filteredStudents == null)
                {
                    return;
                }
                students.Clear();
                students.Add(filteredStudents);
                MessageBox.Show($"筛选学生数据: {filteredStudents.LastName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"筛选学生数据失败: {ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void DeleteStudent(int id)
        {
            try
            {
                var result = await studentService.DeleteStudentAsync(id);
                if (result)
                {
                    students.Clear();
                    await LoadStudents();
                    MessageBox.Show("删除学生成功");
                }
                else
                {
                    MessageBox.Show("删除学生失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"删除学生失败: {ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void EditStudent(Student student)
        {
            if (student == null)
            {
                MessageBox.Show("请选择要编辑的学生。", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            MessageBox.Show($"编辑学生信息: {student.LastName}");
            try
            {
                var result = await studentService.UpdateStudentAsync(student);
                if (result)
                {
                    MessageBox.Show("学生信息更新成功");
                    await LoadStudents();
                }
                else
                {
                    MessageBox.Show("学生信息更新失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"更新学生信息失败: {ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async void AddStudent(Student student)
        {
            if (student.FirstMidName == null || student.LastName == null)
            {
                MessageBox.Show("请填写完整的学生信息。", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try 
            {
                var result = await studentService.AddStudentAsync(student);
                if (result)
                {
                    MessageBox.Show("学生添加成功");
                    await LoadStudents();
                }
                else
                {
                    MessageBox.Show("学生添加失败");
                }
            }catch(Exception ex)
            {
                MessageBox.Show($"添加学生失败: {ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
    }
}
