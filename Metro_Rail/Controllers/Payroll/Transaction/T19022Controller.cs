using Metro_Rail_DAL.DAL.Payroll.Setup;
using Metro_Rail_DAL.DAL.Payroll.Transaction;
using Metro_Rail_DAL.Shared.Payroll.Transaction;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Payroll.Setup
{
    public class T19022Controller : Controller
    {
        T19022DAL repository = new T19022DAL();
        [HttpPost]
        public ActionResult SaveData(T19022Data model, List<T19022Data> list)
        {
            try
            {
                var per = repository.permission(Session["T_ROLE"].ToString(), "T19022", model.T_SALARY_ID == 0 ? "INS" : "UPD");
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

        [HttpPost]
        public ActionResult GetMonthList()
        {
            try
            {
                var data = repository.GetMonthList();
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