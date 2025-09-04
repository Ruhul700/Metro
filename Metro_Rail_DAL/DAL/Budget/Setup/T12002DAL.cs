using Metro_Rail_DAL.Shared.Budget.Setup;
using System.Data;

namespace Metro_Rail_DAL.DAL.Budget.Setup
{
    public class T12002DAL:CommonDAL
    {
        public DataTable GetAllData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT T_PERIOD_ID, T_PERIOD_CODE,T_PERIOD_NAME,T_UM FROM T12002 ORDER BY T_PERIOD_ID DESC ");
            return sql;
        }
        public string SaveData(T12002Data data)
        {
            string mgs = "";
            if (data.T_PERIOD_ID == 0)
            {
                var codeNo = Query($"select MAX(CAST( T_PERIOD_CODE AS numeric))+1 T_PERIOD_CODE FROM T12002").Rows[0]["T_PERIOD_CODE"].ToString();
                var save = Command($"INSERT INTO T12002 (T_PERIOD_CODE,T_PERIOD_NAME,T_UM)VALUES('{codeNo}', '{data.T_PERIOD_NAME}', '{data.T_UM}')");
                if (save) { mgs = "Save Successfully-1"; } else { mgs = " Do not Save-0"; }
            }
            else
            {
                var save = Command($"UPDATE T12002 SET T_PERIOD_NAME ='{data.T_PERIOD_NAME}',T_UM='{data.T_UM}' WHERE T_PERIOD_ID='{data.T_PERIOD_ID}'");
                if (save) { mgs = "Update Successfully-1"; } else { mgs = " Do not Update-0"; }
            }
            return mgs;
        }
    }
}
