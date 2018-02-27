using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOSBPM.Models;

namespace DOSBPM.Controllers
{
    public class PropertyOwnerContactController : BaseController
    {
        // GET: PropertyOwnerContact

        DEV_CODES_APPDBEntities appdbEntities = new DEV_CODES_APPDBEntities();

        public ActionResult Index()
        {
           
                var objList = new PropertyOwnerOrganization();
                objList.StatesList = GetStates();
                objList.CountryList = GetCountries();

                objList.CountiesList = GetCounties();

                return View(objList);
            

        }
    }
}