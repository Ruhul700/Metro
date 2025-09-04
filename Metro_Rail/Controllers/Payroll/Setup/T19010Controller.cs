using Metro_Rail_DAL.DAL.Payroll.Setup;
using Metro_Rail_DAL.Shared.Payroll.Setup;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Metro_Rail.Controllers.Payroll.Setup
{
    public class T19010Controller : Controller
    {
        // GET: T19010
        T19010DAL repository = new T19010DAL();
        [HttpPost]
        public ActionResult LoadPaymentData()
        {
            try
            {
                var data = repository.LoadPaymentData();
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
        public ActionResult GetGradeItem()
        {
            try
            {
                var data = repository.GetItem();
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
        public ActionResult GetDesignationItem()
        {
            try
            {
                var data = repository.GetDesignationItem();
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
        public ActionResult GetEmpList()
        {
            try
            {
                var data = repository.GetEmpList();
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
        public ActionResult LoadDeductionData()
        {
            try
            {
                var data = repository.LoadDeductionData();
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
        public ActionResult SaveData(T19010SaveModel model)
        {
            try
            {
                var per = repository.permission(Session["T_ROLE"].ToString(), "T19010", model.T19010.T_EMP_ID == 0 ? "INS" : "UPD");
                if (!per) { return Json("Have no permission-0", JsonRequestBehavior.AllowGet); }
                var data = repository.SaveData(model.T19010, model.PaymentList, model.DeductionList, Session["T_EMP_ID"].ToString());
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult T19010_GetEmpInfoWithSalary(string empCode)
        {
            var empDetails = repository.T19010_GetEmpInfoWithSalary(empCode);
            // দ্বিতীয় dataset (ধরি Salary History)
            var salaryPayableDetails = repository.T19010_GetSalaryPayment(empCode);
            // তৃতীয় dataset (ধরি Leave History)
            var salaryDeductionDetails = repository.T19010_GetSalaryDeduction(empCode);
            ReportViewer rv = new ReportViewer();
            rv.LocalReport.ReportPath = "Reports/RDLC/T19010_Report.rdlc";
            rv.LocalReport.EnableExternalImages = true;
            rv.ProcessingMode = ProcessingMode.Local;
            // Employee Info dataset
            ReportDataSource rddetails = new ReportDataSource("T19010_GetEmpDetails", empDetails);
            // Salary Payable dataset
            ReportDataSource rdSalaryPayable = new ReportDataSource("T19010_GetEmpPayable", salaryPayableDetails);
            // Salary Deduction dataset
            ReportDataSource rdSalaryDeduction = new ReportDataSource("T19010_GetEmpDeduction", salaryDeductionDetails);
            // Add them to report
            rv.LocalReport.DataSources.Add(rddetails);
            rv.LocalReport.DataSources.Add(rdSalaryPayable);
            rv.LocalReport.DataSources.Add(rdSalaryDeduction);
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