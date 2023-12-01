using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirportManagement.Models.Entities
{
    public class GetHangers
    {
        [Required(ErrorMessage="Required")]
        public DateTime FromDate { get; set; }
        [Required(ErrorMessage = "Required")]
        public DateTime ToDate { get; set; }
    }
}