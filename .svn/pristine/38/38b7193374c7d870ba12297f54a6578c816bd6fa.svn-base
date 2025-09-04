using Metro_Rail_DAL.Shared.Accounts.Setup;
using System.Data;

namespace Metro_Rail_DAL.DAL.Accounts.Setup
{
    public class T12006DAL: CommonDAL
    {
        public DataTable GetAllData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT VAUCHER_TYPE_CODE,VAUCHER_TYPE_NAME FROM T12006 ORDER BY VAUCHER_TYPE_ID DESC ");
            return sql;
        }

        public string SaveData(T12006Data data)
        {
            string mgs = "";
            if (data.VAUCHER_TYPE_CODE == "0")
            {
                var codeNo = Query($"select MAX(CAST( VAUCHER_TYPE_CODE AS numeric))+1 VAUCHER_TYPE_CODE FROM T12006").Rows[0]["VAUCHER_TYPE_CODE"].ToString();
                var save = Command($"INSERT INTO T12006 (VAUCHER_TYPE_CODE, VAUCHER_TYPE_NAME)VALUES('{codeNo}', '{data.VAUCHER_TYPE_NAME}')");
                if (save) { mgs = "Save Successfully-1"; } else { mgs = " Do not Save-0"; }
            }
            else
            {
                var save = Command($"UPDATE T12006 SET VAUCHER_TYPE_NAME= '{data.VAUCHER_TYPE_NAME}' WHERE VAUCHER_TYPE_CODE='{data.VAUCHER_TYPE_CODE}'");
                if (save) { mgs = "Update Successfully-1"; } else { mgs = " Do not Update-0"; }
            }
            return mgs;
        }
    }
}
