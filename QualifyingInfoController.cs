using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOSBPM.Models;


namespace DOSBPM.Controllers
{
    public class QualifyingInfoController : Controller
    {
        // GET: QualifyingInfo
        public ActionResult Index()
        {
            Log.Info("Qualifying Info Controller Started");

            QualifyingInfo qualifyingInfo = new QualifyingInfo();

			if (Session["QualifyingInfo"] != null)
			{
				qualifyingInfo = (QualifyingInfo)Session["QualifyingInfo"];
			}
			 

			ViewBag.Infos = new List<SelectListItem> {
									 new SelectListItem { Value="1", Text="Building Permit Application" ,Selected=(qualifyingInfo.TransactionType=="1")},
									 new SelectListItem { Value ="2", Text="Demoloition Permit Application" ,Selected=(qualifyingInfo.TransactionType=="2")}
								  };

			return View(qualifyingInfo);
        }

		[HttpPost]
		public ActionResult Index(QualifyingInfo qualifyingInfo)
		{
			//store in Session 
			Session["QualifyingInfo"] = qualifyingInfo;
			return RedirectToAction("Index", "PropertyOwnerIndividual");
		}
    }
}