using Metro_Rail_DAL.DAL.Accounts.Setup;
using Metro_Rail_DAL.Shared.Accounts.Setup;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Accounts.Setup
{
    public class T12011Controller : Controller
    {
        // GET: AS12011
        T12011DAL repository = new T12011DAL();
        public ActionResult Index()
        {
            return View();
        }
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
        public ActionResult SaveData(T12011Data model)
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