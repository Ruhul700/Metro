using Metro_Rail_DAL.DAL.Payroll.Setup;
using Metro_Rail_DAL.Shared.Payroll.Setup;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Payroll.Setup
{
    public class T19025Controller : Controller
    {
        // GET: T19020
        T19025DAL repository = new T19025DAL();
        [HttpPost]
        public ActionResult SaveData(T19025Data model, List<T19025Data> list)
        {
            try
            {
                var per = repository.permission(Session["T_ROLE"].ToString(), "T19025", model.T_SALARY_ID == 0 ? "INS" : "UPD");
                if (!per) { return Json("Have no permission-0", JsonRequestBehavior.AllowGet); }
                var data = repository.SaveData(model,list, Session["T_EMP_ID"].ToString());
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }    

        [HttpPost]
        public ActionResult GetBonusList()
        {
            try
            {
                var data = repository.GetBonusList();
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
        public ActionResult LoadGridData(string param)
        {
            try
            {
                var data = repository.LoadGridData(param);
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