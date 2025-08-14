using System.ComponentModel.DataAnnotations;

namespace WpfDemo.Models.Entity
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreateTime { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 成绩
        /// </summary>
        public int? Grade { get; set; }
        /// <summary>
        /// 导航属性
        /// </summary>
        public Course Course { get; set; }
        public Student? Student { get; set; }
    }
}