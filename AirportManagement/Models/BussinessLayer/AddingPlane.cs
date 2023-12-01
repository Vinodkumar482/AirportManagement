using AirportManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportManagement.Models.BussinessLayer
{
    public class AddingPlane
    {
        public AddPlane trim(AddPlane p)
        {
            AddPlane addPlane = new AddPlane();
            addPlane.ManufacturerName = p.ManufacturerName.Trim();
            addPlane.RegistrationNo = p.RegistrationNo;
            addPlane.OwnerName = p.OwnerName.Trim();
            addPlane.ModelNo = p.ModelNo.Trim();
            addPlane.PlaneName = p.PlaneName.Trim();
            addPlane.Capacity = p.Capacity;
            addPlane.Email = p.Email;
            addPlane.HouseNo = p.HouseNo.Trim();
            addPlane.City = p.City.Trim().ToUpper();
            addPlane.State = p.State.Trim().ToUpper();
            addPlane.Country = p.Country.Trim().ToUpper();
            addPlane.PinNo = p.PinNo.Trim();
            addPlane.AddressLine = p.AddressLine.Trim();
            return addPlane;
        }
    }
}