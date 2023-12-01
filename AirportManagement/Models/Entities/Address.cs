using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportManagement.Models.Entities
{
    public class Address
    {
        public string HouseNo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinNo { get; set; }
        public Nullable<int> Id { get; set; }

        public string OwnerName { get; set; }
        public string AddressLine { get; set; }
    }
}