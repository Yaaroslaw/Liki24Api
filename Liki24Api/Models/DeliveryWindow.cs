using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Liki24Api.Models
{
    public class DeliveryWindow
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public int HourStart { get; set; }
        public int HouFinish { get; set; }
        public int AvailableBefore { get; set; }
        public Decimal Price { get; set; }
        public string Type { get; set; }
        public bool Available { get; set; }
        public int Id { get; set; }
    }
}