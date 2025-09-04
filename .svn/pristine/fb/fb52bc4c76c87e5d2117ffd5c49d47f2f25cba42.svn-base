using Metro_Rail_DAL.Shared.Budget.Setup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro_Rail_DAL.DAL.Budget.Setup
{
    public class T12001DAL : CommonDAL
    {        
        public DataTable GetAllData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT T_BUDGET_YEAR_ID, T_BUDGET_YEAR_CODE,T_BUDGET_YEAR_NAME FROM T12001 ORDER BY T_BUDGET_YEAR_ID DESC ");
            return sql;
        }
        public string SaveData(T12001Data data)
        {
            string mgs = "";
            if (data.T_BUDGET_YEAR_ID == 0)
            {
                var codeNo = Query($"select MAX(CAST( T_BUDGET_YEAR_CODE AS numeric))+1 T_BUDGET_YEAR_CODE FROM T12001").Rows[0]["T_BUDGET_YEAR_CODE"].ToString();
                var save = Command($"INSERT INTO T12001 (T_BUDGET_YEAR_CODE,T_BUDGET_YEAR_NAME)VALUES('{codeNo}', '{data.T_BUDGET_YEAR_NAME}')");
                if (save) { mgs = "Save Successfully-1"; } else { mgs = " Do not Save-0"; }
            }
            else
            {
                var save = Command($"UPDATE T12001 SET T_BUDGET_YEAR_NAME ='{data.T_BUDGET_YEAR_NAME}' WHERE T_BUDGET_YEAR_ID='{data.T_BUDGET_YEAR_ID}'");
                if (save) { mgs = "Update Successfully-1"; } else { mgs = " Do not Update-0"; }
            }
            return mgs;
        }
    }
}
