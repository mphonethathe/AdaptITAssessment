using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AdaptItAcademy.Web.Entity
{
    public class Delegates
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "Character can not exceed 25")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(25,ErrorMessage ="Character can not exceed 25")]
        public string LastName { get; set; }
        [Required]
       
        [RegularExpression(@"^\+27[0-9]{9}$",ErrorMessage ="Invalid Phone Number eg:+27123456789")]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string DietaryRequirements { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "Character can not exceed 25")]
        public string CompanyName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Character can not exceed 25")]
        public string PhysicalAddress { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "Character can not exceed 25")]
        public string PostalAddress { get; set; }

    }
}
