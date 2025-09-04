using Metro_Rail_DAL.Shared.Payroll.Transaction;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro_Rail_DAL.DAL.Payroll.Transaction
{   
        public class T19030DAL : CommonDAL
        {

            public DataTable LoadData()
            {
                DataTable dt = new DataTable();
                dt = Query("SELECT T_EMP_CODE,T_EMP_NAME FROM T11111 WHERE T_ACTIVE_FLAG='1' ORDER BY T_EMP_ID ASC");
                return dt;
            }
            public DataTable LoadDataByMonth(string monthCode)
            {
                DataTable dt = new DataTable();
                dt = Query($"select T19030.T_ATTENDENCE_CODE, T19030.T_WORKING_DAY, T_ATNDC_DETL_ID, T19031.T_ATTENDENCE_CODE, T19031.T_EMP_CODE, T11111.T_EMP_NAME, T_TOTAL_PRESENT, T_TOTAL_LATE, T_TOTAL_ABSENT from T19031 JOIN T19030 ON T19031.T_ATTENDENCE_CODE =T19030.T_ATTENDENCE_CODE JOIN T11111 ON T19031.T_EMP_CODE= T11111.T_EMP_CODE WHERE T19030.T_MONTH_CODE='{monthCode}'");
                return dt;
            }
            public DataTable GetMonthData()
            {
                DataTable dt = new DataTable();
                dt = Query("SELECT T_MONTH_CODE,T_MONTH_NAME FROM T11011  ORDER BY T_MONTH_ID ASC");
                return dt;
            }
            public string SaveData(Insert data)
            {
                string sms = "";
                int count = 0;
                SqlTransaction objTrans = null;
                using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString))
                {
                    try
                    {
                        objConn.Open();
                        objTrans = objConn.BeginTransaction();

                        var isExist = Query($"select count(*) T_COUNT from T19030 where T_MONTH_CODE='{data.T30Single.T_MONTH_CODE}'").Rows[0]["T_COUNT"].ToString();
                        if (isExist == "0")
                        {
                            var maxCode = Query($"select (CASE WHEN (Select count(*) from t19030)>0 THEN (select MAX( cast( T_ATTENDENCE_CODE as int)+1)T_ATTENDENCE_CODE from t19030 ) ELSE '1' END) T_ATTENDENCE_CODE").Rows[0]["T_ATTENDENCE_CODE"].ToString();
                            var query30 = $"INSERT INTO t19030 (T_ATTENDENCE_CODE,T_MONTH_CODE,T_WORKING_DAY) VALUES('{maxCode}','{data.T30Single.T_MONTH_CODE}','{data.T30Single.T_WORKING_DAY}')";
                            command_2(query30, objConn, objTrans);
                            foreach (var i in data.T31List)
                            {
                                // var maxCode = Query($"select (CASE WHEN (Select count(*) from t19030)>0 THEN (select MAX( cast( T_ATTENDENCE_CODE as int)+1)T_ATTENDENCE_CODE from t19030 ) ELSE '101' END) 

                                var query31 = $"INSERT INTO t19031 (T_ATTENDENCE_CODE,T_EMP_CODE,T_TOTAL_PRESENT, T_TOTAL_LATE, T_TOTAL_ABSENT) VALUES('{maxCode}','{i.T_EMP_CODE}','{i.T_TOTAL_PRESENT}', '{i.T_TOTAL_LATE}','{i.T_TOTAL_ABSENT}')";
                                command_2(query31, objConn, objTrans);
                                count++;
                            }
                            if (data.T31List.Count() == count)
                            {
                                objTrans.Commit();
                                sms = "Save Successfully-1";
                            }
                            else
                            {
                                sms = "Do not Save-0";
                                objTrans.Rollback();
                            }
                        }
                        else
                        {
                            var query30 = $@"UPDATE t19030 SET T_WORKING_DAY ='{data.T30Single.T_WORKING_DAY}' WHERE T_ATTENDENCE_CODE ='{data.T30Single.T_ATTENDENCE_CODE}'";
                            command_2(query30, objConn, objTrans);
                            foreach (var i in data.T31List)
                            {
                                var query31 = $"UPDATE  t19031  SET T_TOTAL_PRESENT ='{i.T_TOTAL_PRESENT}', T_TOTAL_LATE='{i.T_TOTAL_LATE}', T_TOTAL_ABSENT='{i.T_TOTAL_ABSENT}' WHERE T_ATTENDENCE_CODE ='{i.T_ATTENDENCE_CODE}' AND  T_EMP_CODE='{i.T_EMP_CODE}' ";
                                command_2(query31, objConn, objTrans);
                                count++;
                            }
                            if (data.T31List.Count() == count)
                            {
                                objTrans.Commit();
                                sms = "Update Successfully-1";
                            }
                            else
                            {
                                sms = "Do not Update-0";
                                objTrans.Rollback();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var kk = ex.Message;
                        sms = "Do not Save-0";
                        objTrans.Rollback();
                    }
                    finally
                    {
                        objConn.Close();
                    }
                }
                return sms;
            }
        }
  
}
