using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportManagement.Models.Entities
{
    public class GetAvailablePlanes
    {
        public string ManufacturerName { get; set; }
        public string RegNo { get; set; }
        public string ModelNo { get; set; }
        public string PlaneName { get; set; }
        public Nullable<int> Capacity { get; set; }
        public Nullable<int> OwnerId { get; set; }
        public string PlaneId { get; set; }
        public Nullable<int> Id { get; set; }
    }
}