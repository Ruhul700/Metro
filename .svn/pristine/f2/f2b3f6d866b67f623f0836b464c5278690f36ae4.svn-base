using Metro_Rail_DAL.Shared.Payroll.Setup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro_Rail_DAL.DAL.Payroll.Setup
{
    public class T19008DAL : CommonDAL
    {

        public DataTable LoadData()
        {
            DataTable dt = new DataTable();
            dt = Query("select T_GRADE_ID,T_GRADE_CODE, T_GRADE_NAME from t19008 ORDER BY T_GRADE_ID DESC");
            return dt;
        }
        public string SaveData(T19008Data t19008)
        {
            string sms = "";
            if (t19008.T_GRADE_ID == 0)
            {
                //var maxCode = Query($"select (CASE WHEN (Select count(*) from t19008)>0 THEN (select MAX( cast( T_DEDUCTION_CODE as int)+1)T_DEDUCTION_CODE from t19008 ) ELSE '101' END) T_DEDUCTION_CODE").Rows[0]["T_DEDUCTION_CODE"].ToString();
                var sa = Command($"INSERT INTO t19008 (T_GRADE_CODE,T_GRADE_NAME) VALUES('{t19008.T_GRADE_CODE}',N'{t19008.T_GRADE_NAME}',)");
                if (sa == true)
                {
                    sms = "Save Successfully-1";
                }
                else
                {
                    sms = "Do not Save-0";
                }
            }
            else
            {
                var sa = Command($"UPDATE t19008 SET T_GRADE_CODE='{t19008.T_GRADE_CODE}', T_GRADE_NAME=N'{t19008.T_GRADE_NAME}'  WHERE T_GRADE_ID ='{t19008.T_GRADE_ID}'");
                if (sa == true)
                {
                    sms = "Update Successfully-1";
                }
                else
                {
                    sms = "Do not Update-0";
                }
            }

            return sms;
        }
    }
}
