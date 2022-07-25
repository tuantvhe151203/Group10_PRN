using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectGroup10.Models
{
    public partial class Product
    {
        public Product()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string PriceNew { get; set; }
        public int? UserId { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public string Detail { get; set; }
        public int Status { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
