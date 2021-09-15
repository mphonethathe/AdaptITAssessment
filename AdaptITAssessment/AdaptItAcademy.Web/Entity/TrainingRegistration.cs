using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AdaptItAcademy.Web.Entity
{
    public partial class TrainingRegistration
    {
        public int Id { get; set; }
        [Required]
        public int TrainingId { get; set; }
        [Required]
        public int DelegateId { get; set; }
        public virtual Delegates Delegate { get; set; }
        public virtual Trainings Training { get; set; }
    }
}
