using Metro_Rail_DAL.Shared.Payroll.Setup;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro_Rail_DAL.DAL.Payroll.Setup
{
  public  class T11111DAL:CommonDAL
    {
        public DataTable LoadData()
        {
            DataTable dt = new DataTable();
            dt = Query("select T_EMP_ID,T_EMP_CODE,T_EMP_NAME,T_EMP_MOBILE,T_EMP_ADDRESS, t11.T_GENDER_CODE, t01.T_GENDER_NAME, t11.T_RELIGION_CODE, t02.T_RELIGION_NAME, t11.T_DESIGNATION_CODE,t11.T_ACCOUNT_NO, t11.T_BANK_NAME,t11.T_ROUTING_NO, t03.T_DESIGNATION_NAME, t11.T_ENTRY_DATE from T11111 t11 JOIN T11101 t01 ON t11.T_GENDER_CODE = t01.T_GENDER_CODE JOIN T11102 t02 ON t11.T_RELIGION_CODE= t02.T_RELIGION_CODE JOIN T11103 t03 ON t11.T_DESIGNATION_CODE =t03.T_DESIGNATION_CODE ORDER BY T_EMP_ID DESC");
            return dt;
        }
        public DataTable GenderData()
        {
            DataTable dt = new DataTable();
            dt = Query("select T_GENDER_CODE, T_GENDER_NAME  from T11101 ");
            return dt;
        }
        public DataTable ReligionData()
        {
            DataTable dt = new DataTable();
            dt = Query("select T_RELIGION_CODE, T_RELIGION_NAME  from T11102 ");
            return dt;

        }
        public DataTable DepartmentData()
        {
            DataTable dt = new DataTable();
            dt = Query("select T_EMP_DEPARTMENT_CODE, T_EMP_DEPARTMENT_NAME  from T19009 ");
            return dt;

        }

        public DataTable DesignationData()
        {
            DataTable dt = new DataTable();
            dt = Query("select T_DESIGNATION_CODE, T_DESIGNATION_NAME  from T11103 ");
            return dt;
        }
        public string SaveData(T11111Data t11111, List<ChildData> list,string entryUser)
        {
            string sms = "";
            var date = DateTime.Now.ToString("dd-MM-yyyy");
            if (t11111.T_EMP_ID == 0)
            {
                var sa = Command($"insert into dbo.T11111 (T_EMP_CODE, T_EMP_NAME, T_EMP_MOBILE, T_GENDER_CODE, T_FATHER_NAME, T_MOTHER_NAME, T_RELIGION_CODE, T_PRESENT_ADDRESS,T_NID, T_PERMANENT_ADDRESS, T_DATE_OF_BIRTH, T_JOINING_DATE, T_PRL_DATE, T_DATE_OF_CONFIRMATION, T_CADRE, T_EMAIL_ADDRESS, T_JOB_PHONE, T_DESIGNATION_CODE, T_DEPARTMENT_CODE, T_JOB_ADDRESS, T_ER_CONTACT_NAME, T_ER_CONTACT_RELATION, T_ER_CONTACT_PHONE, T_ENTRY_USER, T_ENTRY_DATE) values ('{t11111.T_EMP_CODE}','{t11111.T_EMP_NAME}','{t11111.T_EMP_MOBILE}','{t11111.T_GENDER_CODE}','{t11111.T_FATHER_NAME}','{t11111.T_MOTHER_NAME}','{t11111.T_RELIGION_CODE}','{t11111.T_PRESENT_ADDRESS}','{t11111.T_NID}','{t11111.T_PERMANENT_ADDRESS}','{t11111.T_DATE_OF_BIRTH}','{t11111.T_JOINING_DATE}','{t11111.T_PRL_DATE}','{t11111.T_DATE_OF_CONFIRMATION}','{t11111.T_CADRE}','{t11111.T_EMAIL_ADDRESS}','{t11111.T_JOB_PHONE}','{t11111.T_DESIGNATION_CODE}','{t11111.T_EMP_DEPARTMENT_CODE}','{t11111.T_JOB_ADDRESS}','{t11111.T_ER_CONTACT_NAME}','{t11111.T_ER_CONTACT_RELATION}','{t11111.T_ER_CONTACT_PHONE}','{entryUser}','{date}')");
                if (sa == true)
                {
                    sms = "Save Successfully.-1";
                }
                else
                {
                    sms = "Do not Save-0";
                }
            }
            else
            {
                var sa = Command($"UPDATE T11111 SET  T_EMP_NAME='{t11111.T_EMP_NAME}', T_EMP_MOBILE='{t11111.T_EMP_MOBILE}', T_GENDER_CODE='{t11111.T_GENDER_CODE}', T_FATHER_NAME='{t11111.T_FATHER_NAME}', T_MOTHER_NAME='{t11111.T_MOTHER_NAME}', T_RELIGION_CODE='{t11111.T_RELIGION_CODE}', T_PRESENT_ADDRESS='{t11111.T_PRESENT_ADDRESS}',T_NID='{t11111.T_NID}', T_PERMANENT_ADDRESS='{t11111.T_PERMANENT_ADDRESS}', T_DATE_OF_BIRTH='{t11111.T_DATE_OF_BIRTH}', T_JOINING_DATE='{t11111.T_JOINING_DATE}', T_PRL_DATE='{t11111.T_PRL_DATE}', T_DATE_OF_CONFIRMATION='{t11111.T_DATE_OF_CONFIRMATION}', T_CADRE='{t11111.T_CADRE}', T_EMAIL_ADDRESS='{t11111.T_EMAIL_ADDRESS}', T_JOB_PHONE='{t11111.T_JOB_PHONE}', T_DESIGNATION_CODE='{t11111.T_DESIGNATION_CODE}', T_DEPARTMENT_CODE='{t11111.T_EMP_DEPARTMENT_CODE}', T_JOB_ADDRESS='{t11111.T_JOB_ADDRESS}', T_ER_CONTACT_NAME='{t11111.T_ER_CONTACT_NAME}', T_ER_CONTACT_RELATION='{t11111.T_ER_CONTACT_RELATION}', T_ER_CONTACT_PHONE='{t11111.T_ER_CONTACT_PHONE}', T_UPDATE_USER='{entryUser}', T_UPDATE_DATE='{date}' Where T_EMP_ID='{t11111.T_EMP_ID}'");
                if (sa == true)
                {
                    sms = "Update Successfully.-1";
                }
                else
                {
                    sms = "Do not Update-0";
                }
            }
            //else if (t11111.T_ACTIVE_TAB == "Family")
            //{
            //    var sa = Command($"UPDATE T11111 SET T_SPOUSE_NAME='{t11111.T_SPOUSE_NAME}',T_SPOUSE_NATIONALITY='{t11111.T_SPOUSE_NATIONALITY}',T_SPOUSE_NID='{t11111.T_SPOUSE_NID}',T_SPOUSE_CONTACT='{t11111.T_SPOUSE_CONTACT}',T_UPDATE_DATE ='{date}' WHERE T_EMP_CODE ='{t11111.T_EMP_CODE}'");
            //    if (sa == true)
            //    {                    
            //        foreach (var item in list)
            //        {
            //            var insT11112 = Command($"insert into T11112 (T_CHILD_CODE, T_CHILD_NAME, T_EMP_CODE, T_GENDER_CODE, T_SCHOOL_NAME, T_CLASS_NAME, T_BIRTH_DATE, T_CERTIFICATION, T_ENTRY_USER, T_ENTRY_DATE) values ('0023','{item.T_CHILD_NAME}','{t11111.T_EMP_CODE}','{item.T_CHILD_GENDER}','{item.T_CHILD_SCHOOL}','{item.T_CHILD_CLASS}','{item.T_CHILD_DOB}','{item.T_CHILD_CERTIFICATE}','{entryUser}','{date}')");
            //        }
                   
            //        sms = "Save Successfully.-1";
            //    }
            //    else
            //    {
            //        sms = "Do not Save-0";
            //    }
            //}
           

            return sms;
        }
        public string SaveEducationData(EduData data, string entryUser)
        {
            string sms = "";
            var date = DateTime.Now.ToString("dd-MM-yyyy");
            if (data.AcademicList.Count()>0)
            {
                foreach (var i in data.AcademicList)
                {
                    var maxCode = Query($"select case when count(T_EDUCATION_CODE)>0 then  MAX( CAST(T_EDUCATION_CODE  AS INT))+1 else '101' end T_EDUCATION_CODE from T11113").Rows[0]["T_EDUCATION_CODE"].ToString();

                    var sa = Command($"INSERT INTO DBO.T11113 (T_EDUCATION_CODE,T_EMP_CODE,T_INSTITUTION_NAME,T_GROUP_SUBJECT,T_PASSING_YEAR,T_RESULT,T_DISTINCTION, T_EDU_TYPE,T_ENTRY_USER,T_ENTRY_DATE) values ('{maxCode}','{data.T_EMP_CODE}','{i.T_INSTITUTION_NAME}','{i.T_GROUP_SUBJECT}','{i.T_PASSING_YEAR}', '{i.T_RESULT}','{i.T_DISTINCTION}','1','{entryUser}','{date}')");
                    if (sa == true)
                    {
                        sms = "Save Successfully.-1";
                    }
                    else
                    {
                        sms = "Do not Save-0";
                    }
                }
                
            }
            if (data.ProfesList.Count() > 0)
            {
                foreach (var i in data.ProfesList)
                {
                    var maxCode = Query($"select case when count(T_EDUCATION_CODE)>0 then  MAX( CAST(T_EDUCATION_CODE  AS INT))+1 else '101' end T_EDUCATION_CODE from T11113").Rows[0]["T_EDUCATION_CODE"].ToString();

                    var sa = Command($"INSERT INTO DBO.T11113 (T_EDUCATION_CODE,T_EMP_CODE,T_INSTITUTION_NAME,T_GROUP_SUBJECT,T_PASSING_YEAR,T_RESULT,T_DISTINCTION, T_EDU_TYPE,T_ENTRY_USER,T_ENTRY_DATE) values ('{maxCode}','{data.T_EMP_CODE}','{i.T_INSTITUTION_NAME}','{i.T_GROUP_SUBJECT}','{i.T_PASSING_YEAR}','{i.T_RESULT}','{i.T_DISTINCTION}','2','{entryUser}','{date}')");
                    if (sa == true)
                    {
                        sms = "Save Successfully.-1";
                    }
                    else
                    {
                        sms = "Do not Save-0";
                    }
                }


            }
            else
            {
                sms = "Do not Save-0";
            }

            return sms;
        }
        public string SaveFamilyData(Family data, string entryUser)
        {
            string sms = "";
            int count = 0;
            SqlTransaction objTrans = null;
            var date = DateTime.Now.ToString("dd-MM-yyyy");
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString))
            {
                objConn.Open();
                objTrans = objConn.BeginTransaction();
                try
                {
                    var t11111 = data.spouseInfo;
                    var insertSpouse = $"UPDATE T11111 SET T_SPOUSE_NAME='{t11111.T_SPOUSE_NAME}',T_SPOUSE_NATIONALITY='{t11111.T_SPOUSE_NATIONALITY}', T_SPOUSE_NID='{t11111.T_SPOUSE_NID}',T_SPOUSE_CONTACT='{t11111.T_SPOUSE_CONTACT}',T_UPDATE_DATE ='{date}' WHERE T_EMP_CODE ='{data.T_EMP_CODE}'";
                    var insertT11Spouse = command_2(insertSpouse, objConn, objTrans);
                    if (insertT11Spouse)
                    {
                        if (data.ChildList?.Count > 0)
                        {
                            foreach (var item in data.ChildList)
                            {
                                if (item.T_CHILD_ID == 0)
                                {
                                    var insT11112 = $"insert into T11112 (T_CHILD_CODE, T_CHILD_NAME, T_EMP_CODE, T_GENDER_CODE, T_SCHOOL_NAME, T_CLASS_NAME, T_BIRTH_DATE, T_CERTIFICATION, T_ENTRY_USER, T_ENTRY_DATE) values ('{item.T_CHILD_CODE}','{item.T_CHILD_NAME}','{data.T_EMP_CODE}','{item.T_CHILD_GENDER}','{item.T_CHILD_SCHOOL}','{item.T_CHILD_CLASS}','{item.T_CHILD_DOB}','{item.T_CHILD_CERTIFICATE}','{entryUser}','{date}')";
                                    command_2(insT11112, objConn, objTrans); 
                                    count++;
                                }
                                else
                                {
                                    var insT11112 = $"UPDATE T11112 SET T_CHILD_NAME = '{item.T_CHILD_NAME}', T_GENDER_CODE = '{item.T_CHILD_GENDER}', T_SCHOOL_NAME = '{item.T_CHILD_SCHOOL}', T_CLASS_NAME = '{item.T_CHILD_CLASS}', T_BIRTH_DATE = '{item.T_CHILD_DOB}', T_CERTIFICATION = '{item.T_CHILD_CERTIFICATE}', T_UPDATE_USER = '{entryUser}', T_UPDATE_DATE = '{date}' WHERE T_CHILD_ID = '{item.T_CHILD_ID}' AND T_EMP_CODE = '{data.T_EMP_CODE}'";
                                    command_2(insT11112, objConn, objTrans);  
                                    count++;
                                }
                            }
                        }
                        if (data.ChildList.Count()==count && insertT11Spouse)
                        {
                            sms = "Save Successfully-1";
                            objTrans.Commit();
                        }                       
                    }
                    else
                    {
                        objTrans.Rollback();
                    }
                   
                }
                catch (Exception ex)
                {
                    var dd = ex.Message;
                    objTrans.Rollback();
                    sms = "Do not Save-0 ";
                }
                finally
                {
                    objConn.Close();
                }
            }
               
           


            return sms;
        }
        public DataTable T11111_GetEmployeeProfileData(string empCode)
        {
            DataTable dt = new DataTable();
            dt = Query($@"select t11.T_EMP_NAME,t11.T_DESIGNATION_CODE, t11.T_EMP_CODE, t11.T_CADRE, t11.T_JOINING_DATE, t11.T_PRL_DATE, t11.T_DATE_OF_CONFIRMATION,t11.T_EMP_MOBILE,t11.T_EMAIL_ADDRESS,t11.T_NID,t11.T_JOB_ADDRESS,t11.T_FATHER_NAME,t11.T_MOTHER_NAME,t11.T_DATE_OF_BIRTH,t11.T_DEPARTMENT_CODE,t11.T_JOB_PHONE,t11.T_RELIGION_CODE,t11.T_GENDER_CODE,t11.T_ER_CONTACT_NAME,t11.T_ER_CONTACT_RELATION,t11.T_ER_CONTACT_PHONE,t11.T_SPOUSE_NAME,t11.T_SPOUSE_NATIONALITY,t11.T_SPOUSE_NID,t11.T_SPOUSE_CONTACT from T11111 t11 where t11.T_EMP_CODE = '9632'");
            return dt;
        }

    }
}
