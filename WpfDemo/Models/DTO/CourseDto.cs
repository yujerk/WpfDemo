using System.ComponentModel.DataAnnotations;

namespace WpfDemo.Models.DTO
{
    public class CourseDto
    {
        /// <summary>
        /// 课程标题
        /// </summary>
        [Required]
        public string Title { get; set; }
        // <summary>
        /// 学分
        /// </summary>
        [Required]
        public int Credits { get; set; }
    }
}
