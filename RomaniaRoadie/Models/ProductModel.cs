using System;
using System.ComponentModel.DataAnnotations;

namespace RomaniaRoadie.Models
{
    public class ProductModel
    {
        public Guid IDProduct { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max 250 chars)")]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max 250 chars)")]
        public string Model { get; set; }

        public decimal Price { get; set;  }

        public string Description { get; set; }
    }
}