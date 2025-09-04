using Metro_Rail_DAL.DAL.Budget.Transaction;
using Metro_Rail_DAL.Shared.Budget.Transaction;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Budget.Transaction
{
    public class T12023Controller : Controller
    {
        // GET: T12023
        T12023DAL repository = new T12023DAL();
        [HttpPost]
        public ActionResult GetAllProjectData()
        {
            try
            {
                var data = repository.GetAllProjectData();
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
        public ActionResult GetHeaderData()
        {
            try
            {
                var data = repository.GetHeaderData();
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
        public ActionResult GetAllData(string param)
        {
            try
            {
                var data = repository.GetAllData(param);
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
        public ActionResult SaveData(T12023Data model)
        {
            try
            {
                if (string.IsNullOrEmpty(Session["T_EMP_ID"] as string)) { return Json("1111-0", ""); }
                //var per = repository.permission(Session["T_ROLE"].ToString(), "T12020", model.T_BUDGET_ID == 0 ? "INS" : "UPD");
                //if (!per) { return Json("Have no permission-0", JsonRequestBehavior.AllowGet); }
                var data = repository.SaveData(model, Session["T_EMP_ID"].ToString());
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}