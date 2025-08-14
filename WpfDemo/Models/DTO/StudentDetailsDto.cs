namespace WpfDemo.Models.DTO
{
    public class StudentDetailsDto
    {
        /// <summary>
        /// 学生ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set;}
        /// <summary>
        /// 选课表时间
        /// </summary>

        public List<EnrollmentCourseDto> Enrollments { get; set; }
        

    }
}
