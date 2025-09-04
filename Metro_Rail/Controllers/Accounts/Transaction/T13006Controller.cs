using Metro_Rail_DAL.DAL.Accounts.Transaction;
using Metro_Rail_DAL.Shared.Accounts.Transaction;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Accounts.Transaction
{
    public class T13006Controller : Controller
    {
        // GET: T13006
        T13006DAL repository = new T13006DAL();        
        [HttpPost]
        public ActionResult GetSearchValue(T13006ParamList param)
        {
            try
            {
                var data = repository.GetSearchValue(param);
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
        public ActionResult SaveData(T13006Data model)
        {
            try
            {
                var user = Session["T_EMP_ID"].ToString();
                var data = repository.SaveData(model, user);
                //string JSONString = string.Empty;
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