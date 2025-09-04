using Metro_Rail_DAL.DAL.Security.Setup;
using Metro_Rail_DAL.Shared.Security.Setup;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Security.Setup
{
    public class T11102Controller : Controller
    {
        T11102DAL repository = new T11102DAL();
        // GET: T11102
        [HttpPost]
        public ActionResult SaveData(T11102Data model)
        {
            try
            {
                var data = repository.SaveData(model);
                //string JSONString = string.Empty;
                // JSONString = JsonConvert.SerializeObject(data);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
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
    }
}