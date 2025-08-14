namespace WpfDemo.Models.DTO
{
    public class EnrollmentStudentDto
    {
        /// <summary>
        /// 学生ID
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// 学生名称
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 成绩
        /// </summary>
        public int? Grade { get; set; }
    }
}