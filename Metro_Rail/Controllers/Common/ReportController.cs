using Metro_Rail_DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Common
{
    public class ReportController : Controller
    {
        // GET: Report
        T10000DAL repository = new T10000DAL();
        //=========Accounts=========
        public ActionResult R13001()
        {
            if (!string.IsNullOrEmpty(Session["T_ROLE"] as string))
            {
                var loginCode = Session["T_ROLE"].ToString();
                var data = repository.Parmision("R13001", loginCode);
                if (data.Rows.Count > 0)
                {
                    return View();
                }
                else
                {
                    Session.Clear();
                    return RedirectToAction("Login", "Login");
                }
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Login", "Login");
            }

        }
        public ActionResult R13002()
        {
            if (!string.IsNullOrEmpty(Session["T_ROLE"] as string))
            {
                var loginCode = Session["T_ROLE"].ToString();
                var data = repository.Parmision("R13002", loginCode);
                if (data.Rows.Count > 0)
                {
                    return View();
                }
                else
                {
                    Session.Clear();
                    return RedirectToAction("Login", "Login");
                }
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Login", "Login");
            }
        }
        public ActionResult R13003()
        {
            if (!string.IsNullOrEmpty(Session["T_ROLE"] as string))
            {
                var loginCode = Session["T_ROLE"].ToString();
                var data = repository.Parmision("R13003", loginCode);
                if (data.Rows.Count > 0)
                {
                    return View();
                }
                else
                {
                    Session.Clear();
                    return RedirectToAction("Login", "Login");
                }
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Login", "Login");
            }
        }
        public ActionResult R13004()
        {
            if (!string.IsNullOrEmpty(Session["T_ROLE"] as string))
            {
                var loginCode = Session["T_ROLE"].ToString();
                var data = repository.Parmision("R13004", loginCode);
                if (data.Rows.Count > 0)
                {
                    return View();
                }
                else
                {
                    Session.Clear();
                    return RedirectToAction("Login", "Login");
                }
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Login", "Login");
            }
        }
        public ActionResult R13005()
        {
            if (!string.IsNullOrEmpty(Session["T_ROLE"] as string))
            {
                var loginCode = Session["T_ROLE"].ToString();
                var data = repository.Parmision("R13005", loginCode);
                if (data.Rows.Count > 0)
                {
                    return View();
                }
                else
                {
                    Session.Clear();
                    return RedirectToAction("Login", "Login");
                }
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Login", "Login");
            }
        }
        //==========================
        public ActionResult R12020()
        {
            if (!string.IsNullOrEmpty(Session["T_ROLE"] as string))
            {
                var loginCode = Session["T_ROLE"].ToString();
                var data = repository.Parmision("R12020", loginCode);
                if (data.Rows.Count > 0)
                {
                    return View();
                }
                else
                {
                    Session.Clear();
                    return RedirectToAction("Login", "Login");
                }
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Login", "Login");
            }
        }
        public ActionResult R11111()
        {
            if (!string.IsNullOrEmpty(Session["T_ROLE"] as string))
            {
                var loginCode = Session["T_ROLE"].ToString();
                var data = repository.Parmision("R11111", loginCode);
                if (data.Rows.Count > 0)
                {
                    return View();
                }
                else
                {
                    Session.Clear();
                    return RedirectToAction("Login", "Login");
                }
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Login", "Login");
            }
        }
    }
}