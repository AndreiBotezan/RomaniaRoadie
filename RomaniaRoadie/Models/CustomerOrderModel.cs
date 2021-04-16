using System;
using System.ComponentModel.DataAnnotations;

namespace RomaniaRoadie.Models
{
    public class CustomerOrderModel
    {
        public Guid IDCustomerOrder { get; set; }
        public Guid IDCustomer { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(1000, ErrorMessage = "String too long (max 1000 chars)")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max 250 chars)")]
        public string City { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(100, ErrorMessage = "String too long (max 100 chars)")]
        public string State { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(100, ErrorMessage = "String too long (max 100 chars)")]
        public string Phone { get; set; }

        [StringLength(1000, ErrorMessage = "String too long (max 1000 chars)")]
        public string Details { get; set; }
        public DateTime DateCreated { get; set; }
    }
}