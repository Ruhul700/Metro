using Metro_Rail_DAL.DAL.Security.Transaction;
using Metro_Rail_DAL.Shared.Security.Transaction;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;
namespace Metro_Rail.Controllers.Security.Transaction
{
    public class T11021Controller : Controller
    {
        T11021DAL repository = new T11021DAL();
        // GET: T11021
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
        public ActionResult RollData()
        {
            try
            {
                var data = repository.RollData();
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
        public ActionResult SaveData(T11021Data model)
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
        [HttpPost]
        public ActionResult GetUserDetails()
        {
            try
            {
                var data = repository.GetUserDetails();
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
      