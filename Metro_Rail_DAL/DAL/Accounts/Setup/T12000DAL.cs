using System.Data;

namespace Metro_Rail_DAL.DAL.Accounts.Setup
{
    public class T12000DAL:CommonDAL
    {
        public DataTable GetData(string userId, string pass)
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT * FROM T12001 WHERE LOGIN_NAME ='{userId}' AND LOGIN_PASS ='{pass}'");
            return sql;
        }
    }
}
