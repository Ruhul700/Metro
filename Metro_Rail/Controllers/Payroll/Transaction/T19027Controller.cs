using Metro_Rail_DAL.DAL.Payroll.Setup;
using Metro_Rail_DAL.DAL.Payroll.Transaction;
using Metro_Rail_DAL.Shared.Payroll.Transaction;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Payroll.Setup
{
    public class T19027Controller : Controller
    {
        T19027DAL repository = new T19027DAL();
        [HttpPost]
        public ActionResult SaveData(T19027Data model, List<T19027Data> list)
        {
            try
            {
                var per = repository.permission(Session["T_ROLE"].ToString(), "T19027", model.T_SALARY_ID == 0 ? "INS" : "UPD");
                if (!per) { return Json("Have no permission-0", JsonRequestBehavior.AllowGet); }
                var data = repository.SaveData(list, Session["T_EMP_ID"].ToString());
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult LoadGridData()
        {
            try
            {
                var data = repository.LoadGridData();
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