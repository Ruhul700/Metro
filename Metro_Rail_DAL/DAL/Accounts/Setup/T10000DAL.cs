using System.Data;

namespace Metro_Rail_DAL.DAL.Accounts.Setup
{
    public class T10000DAL:CommonDAL
    {
        public DataTable Parmision(string formCode, string loginCode)
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT * FROM T10000 WHERE LOGIN_CODE = '{loginCode}' AND FORM_CODE = '{formCode}' ");            
            return sql;
        }
    }
}
