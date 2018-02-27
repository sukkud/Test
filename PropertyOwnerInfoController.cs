using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Configuration;
using System.Data.SqlClient;
using DOSBPM.Models;
using Newtonsoft.Json;

namespace DOSBPM.Controllers
{
    public class PropertyOwnerInfoController : BaseController
    {
        // GET: PropertyOwnerInfo
        DEV_CODES_APPDBEntities db = new DEV_CODES_APPDBEntities();

        public ActionResult Index()
        {
            BuildingApplication buildApp = new BuildingApplication();
             PropertyOwnerInfo propertyOwnerInfo = new PropertyOwnerInfo();

             if (Session["BuildingApplication"] != null)
            {
                buildApp = (BuildingApplication)Session["BuildingApplication"];
            }
            else
            {
                string jsonData = string.Empty;
                temp_BPMData objtemp_BPMData = db.temp_BPMData.FirstOrDefault(x => x.AppID == "1" && x.UserID == "1");
                if(objtemp_BPMData!=null)
                {
                    jsonData = objtemp_BPMData.JsonData;
                }
                buildApp = JsonConvert.DeserializeObject<BuildingApplication>(jsonData);
            }
             if(buildApp == null)
            {
                buildApp = new BuildingApplication();
            }

            ViewBag.info = new List<SelectListItem> {
                                                        new SelectListItem {Value="Property Owner Organization", Text="Property Owner Organization", Selected=(buildApp.PropertyOwnerInfoData?.PropertyOwnerType=="Property Owner Organization")},
                                                        new SelectListItem {Value="Property Owner Organization", Text="Property Owner Individual", Selected=(buildApp.PropertyOwnerInfoData?.PropertyOwnerType=="Property Owner Individual")}

                                                    };

            ViewBag.StatesList = GetStates();
            ViewBag.CountryList = GetCountries();
            ViewBag.CountiesList = GetCounties();

          //  buildApp.PropertyOwnerInfoData = ;

            return View(buildApp.PropertyOwnerInfoData);

            
        }
        [HttpPost]
        public ActionResult Index(PropertyOwnerInfo propertyOwnerInfo)
        {
            BuildingApplication buildApp = null;
            if(Session["BuildingApplication"]!= null)
            {
                buildApp = (BuildingApplication)Session["BuildingApplication"];
            }
            else
            {
                buildApp = new BuildingApplication();
            }

            buildApp.PropertyOwnerInfoData = propertyOwnerInfo;
            Session["BuildingApplication"] = buildApp;

            string buildAppString = JsonConvert.SerializeObject(buildApp);

            temp_BPMData objtemp_BPMData = db.temp_BPMData.FirstOrDefault(x => x.AppID == "1" && x.UserID == "1");
            if (objtemp_BPMData != null)
            {
                objtemp_BPMData.AppID = "1";
                objtemp_BPMData.UserID = "1";
                objtemp_BPMData.JsonData = buildAppString;
                db.SaveChanges();
            }
            else
            {
                temp_BPMData objtempBPM = new temp_BPMData();
                objtempBPM.AppID = "1";
                objtempBPM.UserID = "1";

                objtempBPM.JsonData = buildAppString;
                db.temp_BPMData.Add(objtempBPM);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "PropertyOwnerContact");
        }
    }
}