using System;
using System.Collections.Generic;

#nullable disable

namespace AdaptItAcademy.DataAccess.Models
{
    public partial class Course
    {
        public Course()
        {
            Training = new HashSet<Training>();
        }

        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }

        public virtual ICollection<Training> Training { get; set; }
    }
}
