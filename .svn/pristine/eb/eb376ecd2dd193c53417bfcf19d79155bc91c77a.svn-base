using Metro_Rail_DAL.DAL.Accounts.Setup;
using Metro_Rail_DAL.Shared.Accounts.Setup;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Accounts.Setup
{
    public class T12010MController : Controller
    {
        // GET: AS12010M
        T12010MDAL repository = new T12010MDAL();
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
        public ActionResult GetAccountType()
        {
            try
            {
                var data = repository.GetAccountType();
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
        public ActionResult SaveData(T12010MData model)
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