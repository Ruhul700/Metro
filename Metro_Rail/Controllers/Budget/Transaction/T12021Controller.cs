using Metro_Rail_DAL.DAL.Budget.Transaction;
using Metro_Rail_DAL.Shared.Budget.Transaction;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Budget.Transaction
{
    public class T12021Controller : Controller
    {
        // GET: T12021
        T12021DAL repository = new T12021DAL();
        [HttpPost]
        public ActionResult GetAllData()
        {
            try
            {
                var data = repository.GetAllData();
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
        public ActionResult SaveData(List<T12021Data> model)
        {
            try
            {
                if (string.IsNullOrEmpty(Session["T_EMP_ID"] as string)) { return Json("1111-0", ""); }
                var per = repository.permission(Session["T_ROLE"].ToString(), "T12021", model[0].T_BUDGET_ID == 0 ? "INS" : "UPD");
                if (!per) { return Json("Have no permission-0", JsonRequestBehavior.AllowGet); }
                var data = repository.SaveData(model, Session["T_EMP_ID"].ToString());
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetSetBudgetReport(string projectCode, string projectName)
        {
            var details = repository.GetSetBudgetReport();
            // var dueTotal = repository.GetDueTotal(fdate, tdate);
            ReportViewer rv = new ReportViewer();
            rv.LocalReport.ReportPath = "Reports/RDLC/R12021_Budget.rdlc";
            rv.LocalReport.EnableExternalImages = true;
            // for setting parameter 
            List<ReportParameter> param1 = new List<ReportParameter>();
            param1.Add(new ReportParameter("projectName", projectName));

            ReportDataSource rddetails = new ReportDataSource();
            rddetails.Name = "R12021_Budget";//This refers to the dataset name in the RDLC file
            rddetails.Value = details;

            rv.ProcessingMode = ProcessingMode.Local;
            rv.LocalReport.DataSources.Add(rddetails);
            rv.LocalReport.EnableHyperlinks = true;
            rv.LocalReport.SetParameters(param1);
            rv.LocalReport.Refresh();

            byte[] streamBytes = null;
            string mimeType = "";
            string encoding = "";
            string filenameExtension = "";
            string[] streamids = null;
            Warning[] warnings = null;

            streamBytes = rv.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
            return File(streamBytes, "application/pdf");
        }

    }
}