using Metro_Rail_DAL.DAL.Payroll.Setup;
using Metro_Rail_DAL.DAL.Payroll.Transaction;
using Metro_Rail_DAL.Shared.Payroll.Transaction;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Payroll.Setup
{
    public class T19023Controller : Controller
    {
        T19023DAL repository = new T19023DAL();

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

        public ActionResult ChalanReport(string T_EMP_CODE)
        {
            var details = repository.ChalanDetails(T_EMP_CODE);
            // var dueTotal = repository.GetDueTotal(fdate, tdate);
            ReportViewer rv = new ReportViewer();
            rv.LocalReport.ReportPath = "Reports/RDLC/ChalanReport.rdlc";
            rv.LocalReport.EnableExternalImages = true;
            // for setting parameter 
            //List<ReportParameter> param1 = new List<ReportParameter>();
            //param1.Add(new ReportParameter("fdate", fromDate));
            //param1.Add(new ReportParameter("tdate", toDate));

            ReportDataSource rddetails = new ReportDataSource();
            rddetails.Name = "ChalanReportDetails";//This refers to the dataset name in the RDLC file
            rddetails.Value = details;

            rv.ProcessingMode = ProcessingMode.Local;
            rv.LocalReport.DataSources.Add(rddetails);
            rv.LocalReport.EnableHyperlinks = true;
            //rv.LocalReport.SetParameters(param1);
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