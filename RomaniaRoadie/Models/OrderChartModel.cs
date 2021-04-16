using System;
using System.ComponentModel.DataAnnotations;

namespace RomaniaRoadie.Models
{
    public class OrderChartModel
    {
        public Guid IDOrderChart { get; set; }
        public Guid IDCustomerOrder { get; set; }
        public Guid IDProduct { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public decimal Price { get; set; }
    }
}