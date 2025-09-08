using Metro_Rail_DAL.DAL.Payroll.Setup;
using Metro_Rail_DAL.Shared.Payroll.Setup;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
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
        public ActionResult ChildsData(string param)
        {
            try
            {
                var data = repository.ChildsData(param);
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
        [HttpPost]
        public ActionResult SaveTrainingData(TrainingData model)
        {
            try
            {
                var data = repository.SaveTrainingData(model, Session["T_EMP_ID"].ToString());
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Insert(T11111_Img_Ins t11111, HttpPostedFileBase attachment)
        {
            string base64String = "";
            string mesg = "";
            string fname = "";
            var path = "";
            var user = Session["T_EMP_ID"].ToString();
           // var per = repository.permission(Session["T_ROLE"].ToString(), "T14003", t11111.T_EMP_ID == 0 ? "INS" : "UPD");
           // if (!per) { return Json("Have no permission-0", JsonRequestBehavior.AllowGet); }
            try
            {
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        var inputStream = fileContent.InputStream;
                        var fileName = Path.GetFileName(fileContent.FileName);
                        t11111.T_PROFILE_IMAGE = fileName;
                        path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                        using (var fileStream = System.IO.File.Create(path))
                        {
                            inputStream.CopyTo(fileStream);
                        }
                    }
                }
                mesg = repository.SaveImage(t11111, user);
            }
            catch (Exception ex)
            {
                mesg = ex.Message;
            }
            return Json(mesg, JsonRequestBehavior.AllowGet);
        }
        public ActionResult T11111_GetEmployeeProfileData(string empCode)
        {
            var empDetails = repository.T11111_GetEmployeeProfileData(empCode);
            var empChildDetails = repository.T11111_GetEmployeeChildData(empCode);

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
            ReportDataSource rddetails1 = new ReportDataSource("EmployeeChild", empChildDetails);

            // Salary Payable dataset
            //ReportDataSource rdSalaryPayable = new ReportDataSource("T19010_GetEmpPayable", salaryPayableDetails);

            //// Salary Deduction dataset
            //ReportDataSource rdSalaryDeduction = new ReportDataSource("T19010_GetEmpDeduction", salaryDeductionDetails);

            // Add them to report
            rv.LocalReport.DataSources.Add(rddetails);
            rv.LocalReport.DataSources.Add(rddetails1);
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