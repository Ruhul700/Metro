using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Common
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult H00001()
        {
            if (!string.IsNullOrEmpty(Session["T_ROLE"] as string))
            {
                //var role = Session["T_ROLE"].ToString();
                //var data = repository.Parmision("H00001", role);
                //if (data.Rows.Count > 0)
                //{
                return View();
                //}
                //else
                //{
                //    Session.Clear();
                //    return RedirectToAction("Login", "Login");
                //}
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Login", "Login");
            }
        }
    }
}