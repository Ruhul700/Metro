using Metro_Rail_DAL.Shared.Payroll.Setup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro_Rail_DAL.DAL.Payroll.Setup
{
    public class T19013DAL : CommonDAL
    {

        public DataTable LoadData()
        {
            DataTable dt = new DataTable();
            dt = Query("select T_LEAVE_ID,T_LEAVE_CODE, T_LEAVE_NAME,T_LEAVE_DAY from T19013 ORDER BY T_LEAVE_ID DESC");
            return dt;
        }
        public string SaveData(T19013Data t19013)
        {
            string sms = "";
            if (t19013.T_LEAVE_ID == 0)
            {
                var maxCode = Query($"select (CASE WHEN (Select count(*) from t19013)>0 THEN (select MAX( cast( T_LEAVE_CODE as int)+1)T_LEAVE_CODE from T19013 ) ELSE '101' END) T_LEAVE_CODE").Rows[0]["T_LEAVE_CODE"].ToString();
                var sa = Command($"INSERT INTO T19013 (T_LEAVE_CODE,T_LEAVE_NAME,T_LEAVE_DAY) VALUES('{maxCode}','{t19013.T_LEAVE_NAME}','{t19013.T_LEAVE_DAY}')");
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
                var sa = Command($"UPDATE t19013 SET T_LEAVE_NAME='{t19013.T_LEAVE_NAME}',T_LEAVE_DAY='{t19013.T_LEAVE_DAY}'  WHERE T_LEAVE_ID ='{t19013.T_LEAVE_ID}'");
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
