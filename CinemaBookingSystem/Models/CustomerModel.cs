using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Models
{
    public class CustomermodelList
    {
        public CustomerModel[] CustomerModel { get; set; }
    }
    public class CustomerModel
    {    
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<int> SeatNumber { get; set; }
    }
}
