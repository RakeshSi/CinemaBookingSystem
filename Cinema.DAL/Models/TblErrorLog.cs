using System;
using System.Collections.Generic;

namespace Cinema.DAL.Models
{
    public partial class TblErrorLog
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Message { get; set; }
        public string Method { get; set; }
        public string Controller { get; set; }
    }
}
