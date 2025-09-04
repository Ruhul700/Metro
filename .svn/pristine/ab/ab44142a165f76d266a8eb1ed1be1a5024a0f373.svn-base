using Metro_Rail_DAL.Common;
using Metro_Rail_DAL.DAL.Accounts.Transaction;
using Metro_Rail_DAL.Shared.Accounts.Transaction;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Accounts.Transaction
{
    public class T13003Controller : Controller
    {
        T13003DAL repository = new T13003DAL();
        // GET: AT13003
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetVoucherList(ParamList paramList)
        {
            try
            {
                var data = repository.GetVoucherList(paramList.CENTER, paramList.FROM_DATE, paramList.TO_DATE);
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
        public ActionResult PostingData(List<T13001Data> model)
        {
            try
            {
                var user = Session["T_EMP_ID"].ToString();
                var data = repository.PostingData(model, user);
               // string JSONString = string.Empty;
                //JSONString = JsonConvert.SerializeObject(data);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}