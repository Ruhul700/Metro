using Metro_Rail_DAL.Shared.Payroll.Setup;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Metro_Rail_DAL.DAL.Payroll.Setup
{
    public class T19025DAL : CommonDAL
    {
        public DataTable LoadGridData(string infoCode)
        {
            DataTable dt = new DataTable();
            dt = Query($@"SELECT K.T_EMP_CODE,M.T_EMP_NAME, T.T_SALARY_INFO_CODE, X.T_SALARY_INFO_NAME, K.T_SALARY_SET_ID, K.T_SALARY_SET_CODE, K.T_TOTAL_PAYMENT, T.T_SALARY_SET_TOTAL, T.T_SALARY_SET_TOTAL T_SALARY_PAYABLE FROM T19010 K JOIN T19011 T ON K.T_SALARY_SET_CODE = T.T_SALARY_SET_CODE AND T.T_SALARY_INFO_CODE = '{infoCode}' JOIN T11111 M ON K.T_EMP_CODE = M.T_EMP_CODE JOIN T19005 X ON T.T_SALARY_INFO_CODE = X.T_SALARY_INFO_CODE");
            return dt;
        }
        public DataTable LoadSalaryPivot()
        {
            DataTable dt = new DataTable();
            dt = ExecuteSelectWithoutParam("proc_Salary_Summary_Dynamic");
            return dt;
        }
        public DataTable GetLeaveTypeList()
        {
            DataTable dt = new DataTable();
            dt = Query("SELECT D.T_LEAVE_CODE,D.T_LEAVE_NAME,D.T_LEAVE_DAY FROM T19013 D");
            return dt;
        }
        public DataTable GetBonusList()
        {
            DataTable dt = new DataTable();
            dt = Query("SELECT T_SALARY_INFO_CODE,T_SALARY_INFO_NAME,T_BASE_CODE FROM T19005 T5  WHERE T5.T_BASE_CODE = '103'");
            return dt;
        }   

        public string SaveData(T19025Data model,List<T19025Data> list, string EntryUser)
        {
            var sms = "";
            var date = DateTime.Now.ToString("dd-MM-yyyy");
            SqlTransaction objTrans = null;
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString))
            {
                try
                {
                    objConn.Open();
                    objTrans = objConn.BeginTransaction();

                    var chk = Query_2($"SELECT COUNT(*) T_COUNT FROM T19020 WHERE T_SALARY_INFO_CODE='{model.T_SALARY_INFO_CODE}' AND T_YEAR='{DateTime.Now.Year.ToString()}' AND T_BASE_CODE='103'", objConn, objTrans).Rows[0]["T_COUNT"].ToString();
                    if (Convert.ToInt32(chk)>0)
                    {
                        sms = "Already Generated-0";
                    }
                    else
                    {
                        var MaxSalaryCode = Query_2($"SELECT CASE WHEN COUNT(*)>0 THEN  MAX(T_SALARY_CODE)+1 ELSE 1 END T_SALARY_CODE FROM T19020", objConn, objTrans).Rows[0]["T_SALARY_CODE"].ToString();
                        var MaxSalaryId = Query_2($"SELECT CASE WHEN COUNT(*)>0 THEN  MAX(T_SALARY_ID)+1 ELSE 1 END T_SALARY_ID FROM T19020", objConn, objTrans).Rows[0]["T_SALARY_ID"].ToString();
                        var save20 = $@" INSERT INTO T19020 (T_SALARY_ID,T_SALARY_CODE,T_BASE_CODE, T_MONTH_CODE,T_YEAR,T_SALARY_INFO_CODE, T_ENTRY_USER, T_ENTRY_DATE) VALUES ('{MaxSalaryId}','{MaxSalaryCode}', '103','{DateTime.Now.Month.ToString()}','{DateTime.Now.Year.ToString()}','{model.T_SALARY_INFO_CODE}', '{EntryUser}', '{date}' )";
                        command_2(save20, objConn, objTrans);
                        foreach (var item in list)
                        {
                            var gross = string.IsNullOrEmpty(item.T_TOTAL_PAYMENT?.ToString()) ? "0" : item.T_TOTAL_PAYMENT.ToString();
                            var payment = string.IsNullOrEmpty(item.T_TOTAL_PAYMENT?.ToString()) ? "0" : item.T_TOTAL_PAYMENT.ToString();
                            var payable = string.IsNullOrEmpty(item.T_SALARY_PAYABLE?.ToString()) ? "0" : item.T_SALARY_PAYABLE.ToString();

                            int MaxSalaryDetailId = Convert.ToInt32(Query_2("SELECT ISNULL(MAX(T_SALARY_DTL_ID), 0)+1 FROM T19021", objConn, objTrans).Rows[0][0]);

                            var save02 = $@"INSERT INTO T19021(T_SALARY_DTL_ID, T_SALARY_CODE, T_EMP_CODE, T_SALARY_GROSS, T_SALARY_PAYMENT,T_SALARY_PAYABLE, T_ENTRY_USER, T_ENTRY_DATE)
                            VALUES ({MaxSalaryDetailId}, '{MaxSalaryCode}', '{item.T_EMP_CODE}',{gross}, {payment}, {payable},'{EntryUser}', CAST(GETDATE() AS DATE))";
                            command_2(save02, objConn, objTrans);
                        }
                        objTrans.Commit();
                        sms = "Save Successfully-1";
                    }
                   
                }
                catch (Exception ex)
                {
                    var kk = ex.Message;
                    sms = "Do not Save-0";
                    objTrans.Rollback();
                }

            }
            return sms;

        }
    }
}
