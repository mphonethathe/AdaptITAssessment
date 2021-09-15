using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AdaptItAcademy.DataAccess.Models
{
    public  class TrainingCourseTotalAmount
    {
        public int Id { get; set; }
        [Required]
        public int TrainingId { get; set; }
        [Required]
        public virtual Training Training { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
