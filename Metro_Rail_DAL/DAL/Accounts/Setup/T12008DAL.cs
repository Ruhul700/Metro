using Metro_Rail_DAL.Shared.Accounts.Setup;
using System.Data;

namespace Metro_Rail_DAL.DAL.Accounts.Setup
{
    public class T12008DAL:CommonDAL
    {
        public DataTable GetAllData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT PARTY_TYPE_CODE,PARTY_TYPE_NAME FROM T12008 ORDER BY PARTY_TYPE_ID DESC");
            return sql;
        }

        public string SaveData(T12008Data data)
        {
            string mgs = "";
            if (data.PARTY_TYPE_CODE == "0")
            {
                var codeNo = Query($"select MAX(CAST( PARTY_TYPE_CODE AS numeric))+1 PARTY_TYPE_CODE FROM T12008").Rows[0]["PARTY_TYPE_CODE"].ToString();
                var save = Command($"INSERT INTO T12008 (PARTY_TYPE_CODE, PARTY_TYPE_NAME)VALUES('{codeNo}', '{data.PARTY_TYPE_NAME}')");
                if (save) { mgs = "Save Successfully-1"; } else { mgs = " Do not Save-0"; }
            }
            else
            {
                var save = Command($"UPDATE T12008 SET PARTY_TYPE_NAME= '{data.PARTY_TYPE_NAME}' WHERE PARTY_TYPE_CODE='{data.PARTY_TYPE_CODE}'");
                if (save) { mgs = "Update Successfully-1"; } else { mgs = " Do not Update-0"; }
            }
            return mgs;
        }
    }
}
