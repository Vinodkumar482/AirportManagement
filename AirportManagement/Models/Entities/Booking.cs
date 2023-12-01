using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportManagement.Models.Entities
{
    public class Booking
    {
        public string HangerId { get; set; }
        public string PlaneId { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
    }
}