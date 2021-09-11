using System;
using System.Collections.Generic;

#nullable disable

namespace AdaptItAcademy.DataAccess.Models
{
    public partial class Delegates
    {
        public Delegates()
        {
            TrainingRegistrations = new HashSet<TrainingRegistration>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DietaryRequirements { get; set; }
        public string CompanyName { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }

        public virtual ICollection<TrainingRegistration> TrainingRegistrations { get; set; }
    }
}
