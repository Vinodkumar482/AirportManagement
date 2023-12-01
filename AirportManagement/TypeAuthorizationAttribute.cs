using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirportManagement
{
    public class TypeAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        private readonly string _requiredType;





        public TypeAuthorizationAttribute(string requiredType)
        {
            _requiredType = requiredType;
        }





        public void OnAuthorization(AuthorizationContext filterContext)
        {
            string userType = (string)filterContext.HttpContext.Session["type"];
            if (userType != _requiredType)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}