using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AdaptItAcademy.DataAccess.Models
{
    public partial class Delegates
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string DietaryRequirements { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string PhysicalAddress { get; set; }
        [Required]
        public string PostalAddress { get; set; }

    }
}
