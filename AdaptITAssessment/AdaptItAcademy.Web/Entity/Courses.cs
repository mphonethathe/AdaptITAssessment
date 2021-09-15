using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AdaptItAcademy.Web.Entity
{
    public class Courses
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="character can not exceed 50")]
        public string CourseCode { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "character can not exceed 50")]
        public string CourseName { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "character can not exceed 250")]
        public string CourseDescription { get; set; }

        public virtual ICollection<Trainings> Training { get; set; }
    }
}
