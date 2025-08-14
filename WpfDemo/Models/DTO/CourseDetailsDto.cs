namespace WpfDemo.Models.DTO
{
    public class CourseDetailsDto
    {
        /// <summary>
        /// 课程ID
        /// </summary>
        public int CourseId { get; set; }
        /// <summary>
        /// 课程标题
        /// </summary>
        public string CourseTitle { get; set; }

        /// <summary>
        /// 课程学分
        /// </summary>
        public int Credits { get; set; }
        /// <summary>
        /// 选课表
        /// </summary>
        public List<EnrollmentStudentDto> Enrollments { get; set; } 
    }
}
