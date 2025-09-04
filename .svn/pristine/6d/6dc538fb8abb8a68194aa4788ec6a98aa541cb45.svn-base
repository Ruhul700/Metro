using Metro_Rail_DAL.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Common
{
    public class MenuController : Controller
    {
        MenuDAL menu = new MenuDAL();
        // GET: Menu
        [HttpPost]
        public ActionResult GetAllLinkData()
        {
            try
            {
                if (string.IsNullOrEmpty(Session["T_EMP_ID"] as string)) { return Json("1111-0", ""); }
                var role = Session["T_ROLE"].ToString();
                var module = Session["module"].ToString();
                var data = menu.GetAllLinkData(role, module);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);

            }
            catch (Exception exc)
            {
                return Json(exc.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}