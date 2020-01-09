using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaUnitTest.Models
{
    public class ModelTest
    {
        public List<SecretModel> SecretModel { get; set; }
    }
    public class SecretModel
    {
        public string SecretCode { get; set; }
        public int SeatNumber { get; set; }

    }

    public class UnBookTest
    {
        public List<UnBookModel> UnBookModel { get; set; }
    }

    public class UnBookModel
    {
        public int SeatNumber { get; set; }
    }


}
