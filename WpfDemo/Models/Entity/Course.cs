using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfDemo.Models.Entity
{
    public class Course
    {
        public int CourseId { get; set; }//命名？？？
        [Required]
        public string Title { get; set; }
        [Required]
        public int Credits { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }=new List<Enrollment>();
    }
}