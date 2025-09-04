using Metro_Rail_DAL.DAL.Accounts.Setup;
using Metro_Rail_DAL.DAL.Payroll.Setup;
using Metro_Rail_DAL.Shared.Accounts.Setup;
using Metro_Rail_DAL.Shared.Payroll.Setup;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Accounts.Setup
{
    public class T13010Controller : Controller
    {
        T13010DAL repository = new T13010DAL();
        // GET: T13010
        [HttpPost]
        public ActionResult LoadData()
        {
            try
            {
                var data = repository.LoadData();
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }       

        [HttpPost]
        public ActionResult SaveData(T13010Data model)
        {
            try
            {
                var data = repository.SaveData(model);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}