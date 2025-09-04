using Metro_Rail_DAL.Shared.Accounts.Setup;
using System.Data;

namespace Metro_Rail_DAL.DAL.Accounts.Setup
{
    public class T12011DAL:CommonDAL
    {
        public DataTable GetAllData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT DEPARTMENT_CODE,DEPARTMENT_NAME FROM T12011 ORDER BY DEPARTMENT_ID DESC");
            return sql;
        }

        public string SaveData(T12011Data data)
        {
            string mgs = "";
            if (data.DEPARTMENT_CODE == "0")
            {
                var codeNo = Query($"select MAX(CAST( DEPARTMENT_CODE AS numeric))+1 DEPARTMENT_CODE FROM T12011").Rows[0]["DEPARTMENT_CODE"].ToString();
                var save = Command($"INSERT INTO T12011 (DEPARTMENT_CODE, DEPARTMENT_NAME)VALUES('{codeNo}', '{data.DEPARTMENT_NAME}')");
                if (save) { mgs = "Save Successfully-1"; } else { mgs = " Do not Save-0"; }
            }
            else
            {
                var save = Command($"UPDATE T12011 SET DEPARTMENT_NAME= '{data.DEPARTMENT_NAME}' WHERE DEPARTMENT_CODE='{data.DEPARTMENT_CODE}'");
                if (save) { mgs = "Update Successfully-1"; } else { mgs = " Do not Update-0"; }
            }
            return mgs;
        }
    }
}
