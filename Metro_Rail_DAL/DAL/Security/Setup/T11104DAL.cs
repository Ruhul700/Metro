using Metro_Rail_DAL.Shared.Budget.Setup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro_Rail_DAL.DAL.Budget.Setup
{
    public class T11104DAL : CommonDAL
    {
        public DataTable GetAllData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT T_ROLL_ID, T_ROLL_CODE,T_ROLL_NAME FROM T11104 ORDER BY T_ROLL_ID DESC ");
            return sql;
        }
        public string SaveData(T11104Data data)
        {
            string mgs = "";
            if (data.T_ROLL_ID == 0)
            {
                var codeNo = Query($"select MAX(CAST( T_ROLL_CODE AS numeric))+1 T_ROLL_CODE FROM T11104").Rows[0]["T_ROLL_CODE"].ToString();
                var save = Command($"INSERT INTO T11104 (T_ROLL_CODE,T_ROLL_NAME)VALUES('{codeNo}', '{data.T_ROLL_NAME}')");
                if (save) { mgs = "Save Successfully-1"; } else { mgs = " Do not Save-0"; }
            }
            else
            {
                var save = Command($"UPDATE T11104 SET T_ROLL_NAME ='{data.T_ROLL_NAME}' WHERE T_ROLL_ID='{data.T_ROLL_ID}'");
                if (save) { mgs = "Update Successfully-1"; } else { mgs = " Do not Update-0"; }
            }
            return mgs;
        }
    }
}
