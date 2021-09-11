using System;
using System.Collections.Generic;

#nullable disable

namespace AdaptItAcademy.DataAccess.Models
{
    public partial class training
    {
        public training()
        {
            TrainingRegistrations = new HashSet<TrainingRegistration>();
        }

        public int Id { get; set; }
        public DateTime? TrainingDate { get; set; }
        public string TrainingVenue { get; set; }
        public int? NumberOfSeats { get; set; }
        public decimal? TrainingCost { get; set; }
        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<TrainingRegistration> TrainingRegistrations { get; set; }
    }
}
