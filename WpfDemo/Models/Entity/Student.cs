using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo.Models.Entity
{
    public class Student
    {
        /// <summary>
        /// 学生id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 姓
        /// </summary>
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        /// <summary>
        /// 名
        /// </summary>
        [Required]
        [StringLength(50)]
        [Column("FirstName")]
        public string FirstMidName { get; set; }
        /// <summary>
        /// 选课时间
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ?EnrollmentDate { get; set; }
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }
        /// <summary>
        /// 选课记录 导航属性
        /// </summary>
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}