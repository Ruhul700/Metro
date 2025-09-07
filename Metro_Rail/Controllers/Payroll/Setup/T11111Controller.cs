using Metro_Rail_DAL.DAL.Payroll.Setup;
using Metro_Rail_DAL.Shared.Payroll.Setup;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace Metro_Rail.Controllers.Payroll.Setup
{
    public class T11111Controller : Controller
    {
        T11111DAL repository = new T11111DAL();
        // GET: T11111
        [HttpPost]
        public ActionResult LoadData()
        {
            try
            {
                var data = repository.LoadData();
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
        public ActionResult GenderData()
        {
            try
            {
                var data = repository.GenderData();
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
        public ActionResult ReligionData()
        {
            try
            {
                var data = repository.ReligionData();
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
        public ActionResult DepartmentData()
        {
            try
            {
                var data = repository.DepartmentData();
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
        public ActionResult DesignationData()
        {
            try
            {
                var data = repository.DesignationData();
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
        public ActionResult SaveData(T11111Data model, List<ChildData> list)
        {
            try
            {
                var data = repository.SaveData(model,list, Session["T_EMP_ID"].ToString());                
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult SaveFamilyData(Family model)
        {
            try
            {
                var data = repository.SaveFamilyData(model, Session["T_EMP_ID"].ToString());
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult SaveEducationData(EduData model)
        {
            try
            {
                var data = repository.SaveEducationData(model, Session["T_EMP_ID"].ToString());
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult T11111_GetEmployeeProfileData(string empCode)
        {
            var empDetails = repository.T11111_GetEmployeeProfileData(empCode);

            //// দ্বিতীয় dataset (ধরি Salary History)
            //var salaryPayableDetails = repository.T19010_GetSalaryPayment(empCode);

            //// তৃতীয় dataset (ধরি Leave History)
            //var salaryDeductionDetails = repository.T19010_GetSalaryDeduction(empCode);

            ReportViewer rv = new ReportViewer();
            rv.LocalReport.ReportPath = "Reports/RDLC/EmployeeProfile.rdlc";
            rv.LocalReport.EnableExternalImages = true;
            rv.ProcessingMode = ProcessingMode.Local;


            // Employee Info dataset
            ReportDataSource rddetails = new ReportDataSource("EmployeeProfile", empDetails);

            // Salary Payable dataset
            //ReportDataSource rdSalaryPayable = new ReportDataSource("T19010_GetEmpPayable", salaryPayableDetails);

            //// Salary Deduction dataset
            //ReportDataSource rdSalaryDeduction = new ReportDataSource("T19010_GetEmpDeduction", salaryDeductionDetails);

            // Add them to report
            rv.LocalReport.DataSources.Add(rddetails);
            //rv.LocalReport.DataSources.Add(rdSalaryPayable);
            //rv.LocalReport.DataSources.Add(rdSalaryDeduction);


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