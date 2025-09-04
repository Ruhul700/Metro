using Metro_Rail_DAL.DAL.Payroll.Setup;
using Metro_Rail_DAL.DAL.Payroll.Transaction;
using Metro_Rail_DAL.Shared.Payroll.Transaction;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Payroll.Setup
{
    public class T19021Controller : Controller
    {
        T19021DAL repository = new T19021DAL();

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

        [HttpPost]
        public ActionResult LoadGridData(T19021Input param)
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
        public ActionResult GetSalarySummeryMonthWise(string fromDate, string toDate)
        {
            var summeryDetails = repository.GetSalarySummeryMonthWise(Convert.ToInt32(fromDate), Convert.ToInt32(toDate));
            ReportViewer rv = new ReportViewer();
            rv.LocalReport.ReportPath = "Reports/RDLC/T19021_SalarySummeryByMonth.rdlc";
            rv.LocalReport.EnableExternalImages = true;
            ReportDataSource rddetails = new ReportDataSource();
            rddetails.Name = "SalarySummeryByMonth";//This refers to the dataset name in the RDLC file
            rddetails.Value = summeryDetails;
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