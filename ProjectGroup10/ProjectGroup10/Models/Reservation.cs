using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectGroup10.Models
{
    public partial class Reservation
    {
        public int ReservationId { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? Time { get; set; }
        public double? NewPrice { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
