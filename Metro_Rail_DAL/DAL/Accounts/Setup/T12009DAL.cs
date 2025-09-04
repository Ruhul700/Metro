using Metro_Rail_DAL.Shared.Accounts.Setup;
using System.Data;

namespace Metro_Rail_DAL.DAL.Accounts.Setup
{
    public class T12009DAL:CommonDAL
    {
        public DataTable GetAllData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT PARTY_CODE, T12009.PARTY_TYPE_CODE,PARTY_NAME ,T12008.PARTY_TYPE_NAME FROM T12009 JOIN T12008 ON T12009.PARTY_TYPE_CODE =T12008.PARTY_TYPE_CODE  ORDER BY PARTY_ID DESC");
            return sql;
        }
        public DataTable GetPartyTypeData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT PARTY_TYPE_CODE,PARTY_TYPE_NAME FROM T12008");
            return sql;
        }
        public string SaveData(T12009Data data)
        {
            string mgs = "";
            if (data.PARTY_CODE == "0")
            {
                var codeNo = Query($"select MAX(CAST( PARTY_CODE AS numeric))+1 PARTY_CODE FROM T12009").Rows[0]["PARTY_CODE"].ToString();
                var save = Command($"INSERT INTO T12009 (PARTY_CODE, PARTY_NAME,PARTY_TYPE_CODE)VALUES('{codeNo}', '{data.PARTY_NAME}','{data.PARTY_TYPE_CODE}')");
                if (save) { mgs = "Save Successfully-1"; } else { mgs = " Do not Save-0"; }
            }
            else
            {
                var save = Command($"UPDATE T12009 SET PARTY_NAME= '{data.PARTY_NAME}',PARTY_TYPE_CODE='{data.PARTY_TYPE_CODE}' WHERE PARTY_CODE='{data.PARTY_CODE}'");
                if (save) { mgs = "Update Successfully-1"; } else { mgs = " Do not Update-0"; }
            }
            return mgs;
        }
    }
}
