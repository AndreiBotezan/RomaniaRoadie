using System;
using System.ComponentModel.DataAnnotations;

namespace RomaniaRoadie.Models
{
    public class CustomerModel
    {
        public Guid IDCustomer { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(100, ErrorMessage = "String too long (max 100 chars)")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max 250 chars)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(100, ErrorMessage = "String too long (max 100 chars)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(100, ErrorMessage = "String too long (max 100 chars)")]
        public string LastName { get; set; }
    }
}