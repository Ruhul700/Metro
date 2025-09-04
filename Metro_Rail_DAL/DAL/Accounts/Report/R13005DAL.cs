using System.Data;

namespace Metro_Rail_DAL.DAL.Accounts.Report
{
    public class R13005DAL: CommonDAL
    {
        public DataTable GetLoadHeaderData()
        {
            DataTable sql = new DataTable();
            sql = Query($@"select ACCOUNT_HEADER_CODE,ACCOUNT_HEADER_NAME from T12010 where ACCOUNT_HEADER_CODE IN('101', '108')");
            return sql;
        }
        public DataTable GetDepartmentData()
        {
            DataTable sql = new DataTable();
            sql = Query($@"select DEPARTMENT_CODE,DEPARTMENT_NAME from T12011");
            return sql;
        }
        public DataTable Balance_Flow_Statment(string headCode, string fromDate, string toDate)
        {
            DataTable sql = new DataTable();
            sql = Query($@";with Table_Tamp as ( SELECT a.VOUCHER_DETAILS_ID, t1.VOUCHER_DATE, t1.ENTRY_DATE, a.VOUCHER_NO, a.ACCOUNT_HEADER_CODE, t10.ACCOUNT_HEADER_NAME ACCOUNT_HEADER_NAME, a.VOU_DESCRIPTION, t5.CENTER_NAME, a.DEBIT , a.CREDIT, (a.DEBIT - CREDIT ) BALANCE FROM AT13002 a JOIN AT13001 t1 ON a.VOUCHER_NO =t1.VOUCHER_NO JOIN T12005 t5 ON t1.CENTER_CODE =t5.CENTER_CODE JOIN T12010 t10 ON a.ACCOUNT_HEADER_CODE =t10.ACCOUNT_HEADER_CODE WHERE a.ACCOUNT_HEADER_CODE ='{headCode}' ) select 00 RowNumber, 00 VOUCHER_DETAILS_ID, VOUCHER_DATE, ENTRY_DATE, '00' ACCOUNT_HEADER_CODE, 'An Opening' ACCOUNT_HEADER_NAME, 'Opening balance' VOU_DESCRIPTION, '00' DEBIT, '00'CREDIT, (Balance-DEBIT)+CREDIT AS BALANCE from ( SELECT ROW_NUMBER() OVER (Order by t2.VOUCHER_DETAILS_ID) AS RowNumber, t2.VOUCHER_DETAILS_ID, t2.VOUCHER_DATE,t2.ENTRY_DATE, t2.ACCOUNT_HEADER_CODE, t2.ACCOUNT_HEADER_NAME, t2.VOU_DESCRIPTION, t2.DEBIT, t2.CREDIT, SUM(t1.BALANCE) AS Balance FROM Table_Tamp t1 INNER JOIN Table_Tamp t2 ON t1.VOUCHER_DETAILS_ID <= t2.VOUCHER_DETAILS_ID WHERE CONVERT(date, t2.ENTRY_DATE ,104) BETWEEN CONVERT(date, '{fromDate}' ,104) AND CONVERT(date, '{toDate}' ,104) GROUP BY t2.VOUCHER_DETAILS_ID,t2.VOUCHER_NO,t2.VOUCHER_DATE,t2.ENTRY_DATE, t2.VOU_DESCRIPTION, t2.CREDIT,t2.ACCOUNT_HEADER_CODE, t2.ACCOUNT_HEADER_NAME, t2.DEBIT )t_3 where RowNumber=1 UNION select ROW_NUMBER() OVER (Order by t2.VOUCHER_DETAILS_ID) AS RowNumber, t2.VOUCHER_DETAILS_ID, t2.VOUCHER_DATE, t2.ENTRY_DATE, t2.ACCOUNT_HEADER_CODE, t2.ACCOUNT_HEADER_NAME, t2.VOU_DESCRIPTION, t2.DEBIT, t2.CREDIT, SUM(t1.BALANCE) AS Balance from Table_Tamp t1 INNER JOIN Table_Tamp t2 ON t1.VOUCHER_DETAILS_ID <= t2.VOUCHER_DETAILS_ID WHERE CONVERT(date, t2.ENTRY_DATE ,104) BETWEEN CONVERT(date, '{fromDate}' ,104) AND CONVERT(date, '{toDate}' ,104) GROUP BY t2.VOUCHER_DETAILS_ID,t2.VOUCHER_NO,t2.VOUCHER_DATE,t2.ENTRY_DATE, t2.VOU_DESCRIPTION, t2.CREDIT,t2.ACCOUNT_HEADER_CODE, t2.ACCOUNT_HEADER_NAME, t2.DEBIT");
            return sql;
        }
        
    }
}
