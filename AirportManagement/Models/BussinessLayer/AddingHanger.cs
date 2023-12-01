using AirportManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportManagement.Models.BussinessLayer
{
    public class AddingHanger
    {
        public AddHanger trim(AddHanger p)
        {
            AddHanger a = new AddHanger();
            a.HangerLocation = p.HangerLocation.Trim();
            a.HangerCapacity = p.HangerCapacity;
            a.ManagerName = p.ManagerName.Trim();
            a.SocialSecuirtyNo = p.SocialSecuirtyNo;
            a.Dob = p.Dob;
            a.Gender = p.Gender;
            a.MobileNo = p.MobileNo;
            a.Email = p.Email.Trim();
            a.HouseNo = p.HouseNo.Trim();
            a.City = p.City.Trim().ToUpper();
            a.State = p.State.Trim().ToUpper();
            a.Country = p.Country.Trim().ToUpper();
            a.PinNo = p.PinNo.Trim();
            a.AddressLine = p.AddressLine.Trim();
            return a;
        }
    }
}