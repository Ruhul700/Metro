using Metro_Rail_DAL.DAL.Accounts.Report;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Reports
{
    public class R13003Controller : Controller
    {
        R13003DAL repository = new R13003DAL();
        // GET: R13003
        
        public ActionResult CompanyDetailsReport(string partyType)
        {
            var summary = repository.CompanyDetails(partyType);
        
            ReportViewer rv = new ReportViewer();
            rv.LocalReport.ReportPath = "Reports/RDLC/CompanyDetails.rdlc";
            rv.LocalReport.EnableExternalImages = true;
            // for setting parameter 
            List<ReportParameter> param1 = new List<ReportParameter>();
            param1.Add(new ReportParameter("fdate","02-02-2023"));
           // param1.Add(new ReportParameter("tdate", toDate));

            ReportDataSource rddetails = new ReportDataSource();
            rddetails.Name = "CompanyDetails";//This refers to the dataset name in the RDLC file
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
        public ActionResult SupplierStatement(string party)
        {
            var Supplier = repository.SupplierStatement(party);
           // var supplier = repository.SupplierUnderProject(partyType);
            // var liab = repository.Liability(center, fromDate, toDate);
            ReportViewer rv = new ReportViewer();
            rv.LocalReport.ReportPath = "Reports/RDLC/SupplierStatement.rdlc";
            rv.LocalReport.EnableExternalImages = true;
            // for setting parameter 
            List<ReportParameter> param1 = new List<ReportParameter>();
            param1.Add(new ReportParameter("fdate", "02-02-2023"));
            // param1.Add(new ReportParameter("tdate", toDate));

            ReportDataSource rddetails = new ReportDataSource();
            rddetails.Name = "SupplierStatement";//This refers to the dataset name in the RDLC file
            rddetails.Value = Supplier;
            //---------------------
            //ReportDataSource depr = new ReportDataSource();
            //depr.Name = "SupplierUnderProject";//This refers to the dataset name in the RDLC file
            //depr.Value = supplier;
            //---------------------
            //ReportDataSource liability = new ReportDataSource();
            //liability.Name = "Liability";//This refers to the dataset name in the RDLC file
            //liability.Value = liab;

            rv.ProcessingMode = ProcessingMode.Local;
            rv.LocalReport.DataSources.Add(rddetails);
           // rv.LocalReport.DataSources.Add(depr);
            // rv.LocalReport.DataSources.Add(liability);
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
        public ActionResult AllCompanySummary()
        {
            var Supplier = repository.AllCompanySummary();
            // var supplier = repository.SupplierUnderProject(partyType);
            // var liab = repository.Liability(center, fromDate, toDate);
            ReportViewer rv = new ReportViewer();
            rv.LocalReport.ReportPath = "Reports/RDLC/AllCompanySummary.rdlc";
            rv.LocalReport.EnableExternalImages = true;
            // for setting parameter 
            List<ReportParameter> param1 = new List<ReportParameter>();
            param1.Add(new ReportParameter("fdate", "02-02-2023"));
            // param1.Add(new ReportParameter("tdate", toDate));

            ReportDataSource rddetails = new ReportDataSource();
            rddetails.Name = "AllCompanySummary";//This refers to the dataset name in the RDLC file
            rddetails.Value = Supplier;
            //---------------------
            //ReportDataSource depr = new ReportDataSource();
            //depr.Name = "SupplierUnderProject";//This refers to the dataset name in the RDLC file
            //depr.Value = supplier;
            //---------------------
            //ReportDataSource liability = new ReportDataSource();
            //liability.Name = "Liability";//This refers to the dataset name in the RDLC file
            //liability.Value = liab;

            rv.ProcessingMode = ProcessingMode.Local;
            rv.LocalReport.DataSources.Add(rddetails);
            // rv.LocalReport.DataSources.Add(depr);
            // rv.LocalReport.DataSources.Add(liability);
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
        public ActionResult IndividualSuprDetlsUnderProj(string partyType, string party)
        {
            var Supplier = repository.IndividualSuprDetlsUnderProj(partyType, party);
            // var supplier = repository.SupplierUnderProject(partyType);
            // var liab = repository.Liability(center, fromDate, toDate);
            ReportViewer rv = new ReportViewer();
            rv.LocalReport.ReportPath = "Reports/RDLC/IndividualSuprDetlsUnderProj.rdlc";
            rv.LocalReport.EnableExternalImages = true;
            // for setting parameter 
            List<ReportParameter> param1 = new List<ReportParameter>();
            param1.Add(new ReportParameter("fdate", "02-02-2023"));
            // param1.Add(new ReportParameter("tdate", toDate));

            ReportDataSource rddetails = new ReportDataSource();
            rddetails.Name = "IndividualSuprDetlsUnderProj";//This refers to the dataset name in the RDLC file
            rddetails.Value = Supplier;
            //---------------------
            //ReportDataSource depr = new ReportDataSource();
            //depr.Name = "SupplierUnderProject";//This refers to the dataset name in the RDLC file
            //depr.Value = supplier;
            //---------------------
            //ReportDataSource liability = new ReportDataSource();
            //liability.Name = "Liability";//This refers to the dataset name in the RDLC file
            //liability.Value = liab;

            rv.ProcessingMode = ProcessingMode.Local;
            rv.LocalReport.DataSources.Add(rddetails);
            // rv.LocalReport.DataSources.Add(depr);
            // rv.LocalReport.DataSources.Add(liability);
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
        public ActionResult IndividualSuprAllProjSummary( string party)
        {
            var Supplier = repository.IndividualSuprAllProjSummary( party);
            // var supplier = repository.SupplierUnderProject(partyType);
            // var liab = repository.Liability(center, fromDate, toDate);
            ReportViewer rv = new ReportViewer();
            rv.LocalReport.ReportPath = "Reports/RDLC/IndividualSuprAllProjSummary.rdlc";
            rv.LocalReport.EnableExternalImages = true;
            // for setting parameter 
            List<ReportParameter> param1 = new List<ReportParameter>();
            param1.Add(new ReportParameter("fdate", "02-02-2023"));
            // param1.Add(new ReportParameter("tdate", toDate));

            ReportDataSource rddetails = new ReportDataSource();
            rddetails.Name = "IndividualSuprAllProjSummary";//This refers to the dataset name in the RDLC file
            rddetails.Value = Supplier;
            //---------------------
            //ReportDataSource depr = new ReportDataSource();
            //depr.Name = "SupplierUnderProject";//This refers to the dataset name in the RDLC file
            //depr.Value = supplier;
            //---------------------
            //ReportDataSource liability = new ReportDataSource();
            //liability.Name = "Liability";//This refers to the dataset name in the RDLC file
            //liability.Value = liab;

            rv.ProcessingMode = ProcessingMode.Local;
            rv.LocalReport.DataSources.Add(rddetails);
            // rv.LocalReport.DataSources.Add(depr);
            // rv.LocalReport.DataSources.Add(liability);
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
        public ActionResult CompanyCashFlowReport(string partyType,string fDate, string tDate)
        {
            var summary = repository.CompanyCashFlowReport(partyType, fDate, tDate);

            ReportViewer rv = new ReportViewer();
            rv.LocalReport.ReportPath = "Reports/RDLC/CompanyCashFlowReport.rdlc";
            rv.LocalReport.EnableExternalImages = true;
            // for setting parameter 
            List<ReportParameter> param1 = new List<ReportParameter>();
            param1.Add(new ReportParameter("fdate", fDate));
            param1.Add(new ReportParameter("tdate", tDate));

            ReportDataSource rddetails = new ReportDataSource();
            rddetails.Name = "CompanyCashFlowReport";//This refers to the dataset name in the RDLC file
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

    }
}