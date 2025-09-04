using Metro_Rail_DAL.DAL.Security.Transaction;
using Metro_Rail_DAL.Shared.Security.Transaction;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Security.Transaction
{
    public class T11022Controller : Controller
    {
        T11022DAL repository = new T11022DAL();
        // GET: T11022
        [HttpPost]
        public ActionResult LoadData(T14022Parm paramList)
        {
            try
            {
                var data = repository.LoadData(paramList.T_TYPE, paramList.T_ROLL);
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
        public ActionResult SaveData(string model, List<T11022Data> list)
        {
            try
            {
                var data = repository.SaveData(model, list);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        
    }
}