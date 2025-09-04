using Metro_Rail_DAL.Shared.Payroll.Setup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro_Rail_DAL.DAL.Payroll.Setup
{
    public class T19007DAL : CommonDAL
    {

        public DataTable LoadData()
        {
            DataTable dt = new DataTable();
            dt = Query("select T_DEDUCTION_ID,T_DEDUCTION_CODE, T_DEDUCTION_NAME,T_DEDUCTION_AMOUNT from t19007 ORDER BY T_DEDUCTION_ID DESC");
            return dt;
        }
        public string SaveData(T19007Data t19007)
        {
            string sms = "";
            if (t19007.T_DEDUCTION_ID == 0)
            {
                //var maxCode = Query($"select (CASE WHEN (Select count(*) from t19007)>0 THEN (select MAX( cast( T_DEDUCTION_CODE as int)+1)T_DEDUCTION_CODE from t19007 ) ELSE '101' END) T_DEDUCTION_CODE").Rows[0]["T_DEDUCTION_CODE"].ToString();
                var sa = Command($"INSERT INTO t19007 (T_DEDUCTION_CODE,T_DEDUCTION_NAME,T_DEDUCTION_AMOUNT) VALUES('{t19007.T_DEDUCTION_CODE}',N'{t19007.T_DEDUCTION_NAME}','{t19007.T_DEDUCTION_AMOUNT}')");
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
                var sa = Command($"UPDATE t19007 SET T_DEDUCTION_CODE='{t19007.T_DEDUCTION_CODE}', T_DEDUCTION_NAME=N'{t19007.T_DEDUCTION_NAME}',T_DEDUCTION_AMOUNT='{t19007.T_DEDUCTION_AMOUNT}'  WHERE T_DEDUCTION_ID ='{t19007.T_DEDUCTION_ID}'");
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