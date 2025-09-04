using Metro_Rail_DAL.Shared.Payroll.Setup;
using System.Data;

namespace Metro_Rail_DAL.DAL.Payroll.Setup
{
    public class T11011DAL : CommonDAL
    {     

        public DataTable LoadData()
        {
            DataTable dt = new DataTable();
            dt = Query("select T_MONTH_ID,T_MONTH_CODE, T_MONTH_NAME from T11011 ORDER BY T_MONTH_ID DESC");
            return dt;
        }        
        public string SaveData(T11011Data t11011)
        {
            string sms = "";
            if (t11011.T_MONTH_ID == 0)
            {
                var maxCode = Query($"select (CASE WHEN (Select count(*) from T11011)>0 THEN (select MAX( cast( T_MONTH_CODE as int)+1)T_MONTH_CODE from T11011 ) ELSE '101' END) T_MONTH_CODE").Rows[0]["T_MONTH_CODE"].ToString();
                var sa = Command($"INSERT INTO T11011 (T_MONTH_CODE,T_MONTH_NAME) VALUES('{maxCode}','{t11011.T_MONTH_NAME}')");
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
                var sa = Command($"UPDATE T11011 SET T_MONTH_NAME='{t11011.T_MONTH_NAME}'WHERE T_MONTH_ID ='{t11011.T_MONTH_ID}'");
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
