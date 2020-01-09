using System;
using System.Collections.Generic;

namespace Cinema.DAL.Models
{
    public partial class TblCustomer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public int? SeatNumber { get; set; }
        public string SecretKey { get; set; }
    }
}

