using Metro_Rail_DAL.Shared.Payroll.Setup;
using System.Data;

namespace Metro_Rail_DAL.DAL.Payroll.Setup
{
   public class T19005DAL:CommonDAL
    {
        public DataTable LoadData()
        {
            DataTable dt = new DataTable();
            dt = Query("SELECT T_SALARY_INFO_ID,T_SALARY_INFO_CODE,T_SALARY_INFO_NAME,T19005.T_BASE_CODE,T19006.T_BASE_NAME,T_SALARY_INFO_RATIO FROM T19005 JOIN T19006 ON T19005.T_BASE_CODE = T19006.T_BASE_CODE ORDER BY T_SALARY_INFO_ID");
            return dt;
        }
        public DataTable GetBaseData()
        {
            DataTable dt = new DataTable();
            dt = Query("SELECT T_BASE_CODE,T_BASE_NAME FROM T19006");
            return dt;
        }
        public string SaveData(T19005Data t19005)
        {
            string sms = "";
            if (t19005.T_SALARY_INFO_ID == 0)
            {
                var sa = Command($"INSERT INTO T19005 (T_SALARY_INFO_CODE,T_SALARY_INFO_NAME,T_BASE_CODE,T_SALARY_INFO_RATIO) VALUES('{t19005.T_SALARY_INFO_CODE}',N'{t19005.T_SALARY_INFO_NAME}','{t19005.T_BASE_CODE}','{t19005.T_SALARY_INFO_RATIO}')");
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
                var sa = Command($"UPDATE T19005 SET T_SALARY_INFO_CODE='{t19005.T_SALARY_INFO_CODE}', T_SALARY_INFO_NAME=N'{t19005.T_SALARY_INFO_NAME}',T_BASE_CODE='{t19005.T_BASE_CODE}',T_SALARY_INFO_RATIO='{t19005.T_SALARY_INFO_RATIO}'WHERE T_SALARY_INFO_ID ='{t19005.T_SALARY_INFO_ID}'");
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
