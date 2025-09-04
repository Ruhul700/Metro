using Metro_Rail_DAL.DAL.Budget.Setup;
using Metro_Rail_DAL.Shared.Budget.Setup;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Budget.Setup
{
    public class T12002Controller : Controller
    {
        // GET: T12002
        T12002DAL repository = new T12002DAL();
        
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
        public ActionResult SaveData(T12002Data model)
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