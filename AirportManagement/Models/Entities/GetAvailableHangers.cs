using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportManagement.Models.Entities
{
    public class GetAvailableHangers
    {
        public string HangerId { get; set; }
        public string HangerLocation { get; set; }
        public Nullable<int> HangerCapacity { get; set; }
        public string ManagerName { get; set; }
        public string SSNo { get; set; }
    }
}