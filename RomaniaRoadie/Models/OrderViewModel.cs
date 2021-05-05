using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RomaniaRoadie.Models
{
    public class OrderViewModel
    {
        public Guid IdOrderChart { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}