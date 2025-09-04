using Metro_Rail_DAL.DAL.Accounts.Report;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Reports
{
    public class R13004Controller : Controller
    {
        // GET: R13004
        R13004DAL repository = new R13004DAL();
        [HttpPost]
        public ActionResult GetAllCustomer()
        {
            try
            {
                var data = repository.GetAllCustomer();
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult AllCustormerSummary()
        {
            var summary = repository.AllCustormerSummary();

            ReportViewer rv = new ReportViewer();
            rv.LocalReport.ReportPath = "Reports/RDLC/AllCustomerSummary.rdlc";
            rv.LocalReport.EnableExternalImages = true;
            // for setting parameter 
            List<ReportParameter> param1 = new List<ReportParameter>();
            param1.Add(new ReportParameter("fdate", "02-02-2023"));
            // param1.Add(new ReportParameter("tdate", toDate));

            ReportDataSource rddetails = new ReportDataSource();
            rddetails.Name = "AllCustomerSummary";//This refers to the dataset name in the RDLC file
            rddetails.Value = summary;
            //---------------------

            //ReportDataSource liability = new ReportDataSource();
            //liability.Name = "Liability";//This refers to the dataset name in the RDLC file
            //liability.Value = liab;

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
        public ActionResult IndividualCustomer(string custId, string fDate, string tDate)
        {
            var summary = repository.IndividualCustomer(custId, fDate, tDate);

            ReportViewer rv = new ReportViewer();
            rv.LocalReport.ReportPath = "Reports/RDLC/IndividualCustStatment.rdlc";
            rv.LocalReport.EnableExternalImages = true;
            // for setting parameter 
            List<ReportParameter> param1 = new List<ReportParameter>();
            param1.Add(new ReportParameter("fdate", fDate));
            param1.Add(new ReportParameter("tdate", tDate));

            ReportDataSource rddetails = new ReportDataSource();
            rddetails.Name = "IndividualCustStatment";//This refers to the dataset name in the RDLC file
            rddetails.Value = summary;
            //---------------------

            //ReportDataSource liability = new ReportDataSource();
            //liability.Name = "Liability";//This refers to the dataset name in the RDLC file
            //liability.Value = liab;

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

           // streamBytes = rv.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
            var deviceInfo = @"<DeviceInfo><EmbedFonts>None</EmbedFonts></DeviceInfo>";
            streamBytes = rv.LocalReport.Render("PDF", deviceInfo);
            return File(streamBytes, "application/pdf");
        }
    }
}