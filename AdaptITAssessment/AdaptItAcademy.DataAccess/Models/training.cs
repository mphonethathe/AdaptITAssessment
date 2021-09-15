using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AdaptItAcademy.DataAccess.Models
{
    public  class Training
    {

        public int Id { get; set; }
        [Required]
        public DateTime TrainingDate { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "character can not exceed 50")]
        public string TrainingVenue { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
        [Required]
        public decimal TrainingCost { get; set; }
        [Required]
        public decimal TotalTrainingCostPaid { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public DateTime RegistrationClosingDate { get; set; }
        public Boolean PaymentRequired { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<TrainingRegistration> TrainingRegistrations { get; set; }
    }
}
