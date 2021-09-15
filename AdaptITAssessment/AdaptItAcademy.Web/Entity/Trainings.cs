using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AdaptItAcademy.Web.Entity
{
    public partial class Trainings
    {
        public Trainings()
        {
            TrainingRegistrations = new HashSet<TrainingRegistration>();
        }

        public int Id { get; set; }
        [Required]
        public DateTime TrainingDate { get; set; }
        [Required]
        public DateTime RegistrationClosingDate { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "character can not exceed 50")]
        public string TrainingVenue { get; set; }
        [Required]
        public int? NumberOfSeats { get; set; }
        [Required]
        public decimal TrainingCost { get; set; }
        [Required]
        public Boolean PaymentRequired { get; set; }
        [Required]
        public int? CourseId { get; set; }
        public virtual Courses Course { get; set; }
        public virtual ICollection<TrainingRegistration> TrainingRegistrations { get; set; }
    }
}
