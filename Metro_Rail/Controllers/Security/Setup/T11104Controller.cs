using Metro_Rail_DAL.DAL.Budget.Setup;
using Metro_Rail_DAL.Shared.Budget.Setup;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Budget.Setup
{
    public class T11104Controller : Controller
    {
        // GET: T11104
        T11104DAL repository = new T11104DAL();

        [HttpPost]
        public ActionResult GetAllData()
        {
            try
            {
                var data = repository.GetAllData();
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
        public ActionResult SaveData(T11104Data model)
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