using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOSBPM.Models;
using Newtonsoft.Json;


namespace DOSBPM.Controllers
{
	public class QualifyingInfoController : Controller
	{
		// GET: QualifyingInfo
		public ActionResult Index()
		{
			//Log.Info("Qualifying Info Controller Started");
			BuildingApplication buildApp = new BuildingApplication();
			QualifyingInfo qualifyingInfo = new QualifyingInfo();

			string jsonData = string.Empty;

			dbEntities db = new dbEntities();
			tempBPM objtempBPM = db.tempBPMs.FirstOrDefault(a => a.appid == "1" && a.userid == "1");
			 if (objtempBPM != null)
			{
				 jsonData = objtempBPM.jsonData;
			}

			if (Session["BuildingApplication"] != null)

			{
			  var data = (string)Session["BuildingApplication"];
				BuildingApplication buildAppObj = JsonConvert.DeserializeObject<BuildingApplication>(jsonData);

				//buildApp  = (BuildingApplication)buildAppObj;
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
			BuildingApplication buildApp = null;
			if (Session["BuildingApplication"] != null)
			{
				buildApp = (BuildingApplication)Session["BuildingApplication"];
			}
			else
			{
				buildApp = new BuildingApplication();
			}
			buildApp.QualifyingInfoData = qualifyingInfo;
			Session["BuildingApplication"] = buildApp;

			string buildAppString = JsonConvert.SerializeObject(buildApp);
			//object buildObj = JsonConvert.DeserializeObject(buildAppString);

			dbEntities db = new dbEntities();
			tempBPM objtempBPM = new tempBPM();
			objtempBPM.appid = "1";
			objtempBPM.userid = "1";
			objtempBPM.jsonData = buildAppString;
			db.tempBPMs.Add(objtempBPM);
			db.SaveChanges();

			return RedirectToAction("Index", "PropertyOwnerIndividual");
		}
	}
}