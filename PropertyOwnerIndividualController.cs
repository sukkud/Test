using DOSBPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOSBPM.Controllers
{
    public class PropertyOwnerIndividualController : Controller
    {
        // GET: PropertyOwnerIndividual
        public ActionResult Index()
        {
            Log.Info("Property Owner Individual Controller Started");
            var objCounty = new PropertyOwnerIndividual();
            objCounty.Counties = new[]
            {
                    new SelectListItem { Value = "1", Text = "Saratoga" },
                    new SelectListItem { Value = "2", Text = "Albany" },
                    new SelectListItem { Value = "3", Text = "Rensselaer" },
                    new SelectListItem { Value = "4", Text = "Troy" },
                    new SelectListItem { Value = "5", Text = "GreenBush" },
            };
            return View(objCounty);
        }
    }
}