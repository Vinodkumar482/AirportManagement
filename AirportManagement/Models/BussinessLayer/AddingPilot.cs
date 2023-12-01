using AirportManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportManagement.Models.BussinessLayer
{
    public class AddingPilot
    {
        public AddPilot trim(AddPilot p)
        {
            AddPilot a = new AddPilot();
            a.PilotName = p.PilotName.Trim();
            a.LicenseNo = p.LicenseNo.Trim();
            a.SocialSecurityNo = p.SocialSecurityNo.Trim();
            a.DateOfBirth = p.DateOfBirth;
            a.Gender = p.Gender;
            a.MobileNo = p.MobileNo.Trim();
            a.EmailAddress = p.EmailAddress.Trim();
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