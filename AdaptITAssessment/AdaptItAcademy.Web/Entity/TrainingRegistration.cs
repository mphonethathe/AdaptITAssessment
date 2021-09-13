using System;
using System.Collections.Generic;

#nullable disable

namespace AdaptItAcademy.Web.Entity
{
    public partial class TrainingRegistration
    {
        public int Id { get; set; }
        public DateTime? RegistrationClosingDate { get; set; }
        public int? TrainingId { get; set; }
        public int? DelegateId { get; set; }

        public virtual Delegates Delegate { get; set; }
        public virtual Training Training { get; set; }
    }
}
