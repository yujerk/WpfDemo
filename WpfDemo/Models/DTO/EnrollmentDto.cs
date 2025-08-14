using System.ComponentModel.DataAnnotations;

namespace WpfDemo.Models.DTO
{
    public class EnrollmentDto
    {
        public int CourseID { get; set; }
        public string CourseTitle { get; set; }
        public int? Grade { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreateTime { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdateTime { get; set; }
    }
}