using System;
using System.Collections.Generic;

namespace Cinema.DAL.Models
{
    public partial class TblBookingSeat
    {
        public int Id { get; set; }
        public int? SeatNumber { get; set; }
        public bool? BookingStatus { get; set; }
        public int? CustomerId { get; set; }
    }
}
