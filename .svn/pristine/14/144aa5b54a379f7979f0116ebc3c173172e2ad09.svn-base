using System.Data;

namespace Metro_Rail_DAL.DAL.Accounts.Report
{
    public class R13001DAL : CommonDAL
    {
        public DataTable GetLegerReport(string center, string fromDate, string toDate, string header, string partyType, string party, string department, string purpuse, string trans)
        {
            DataTable sql = new DataTable();
            var condition = "";
            if (center == "0")
            { condition = $" CONVERT(date, t1.VOUCHER_DATE ,104) BETWEEN CONVERT(date, '{fromDate}' ,104) AND CONVERT(date, '{toDate}' ,104)"; }
            else { condition = $" a.ACCOUNT_HEADER_CODE in({header}) AND  t1.CENTER_CODE ='{center}' AND CONVERT(date, t1.VOUCHER_DATE ,104) BETWEEN CONVERT(date, '{fromDate}' ,104) AND CONVERT(date, '{toDate}' ,104)"; }

            sql = Query($"SELECT a.VOUCHER_DETAILS_ID,t1.VOUCHER_DATE ENTRY_DATE, a.VOUCHER_NO,a.ACCOUNT_HEADER_CODE,a.VOU_DESCRIPTION,t5.CENTER_NAME, t10.ACCOUNT_HEADER_NAME, a.DEBIT , a.CREDIT, a.DEBIT - CREDIT 'BALANCE' FROM AT13002 a JOIN AT13001 t1 ON a.VOUCHER_NO =t1.VOUCHER_NO JOIN T12005 t5 ON t1.CENTER_CODE =t5.CENTER_CODE JOIN T12010 t10 ON a.ACCOUNT_HEADER_CODE =t10.ACCOUNT_HEADER_CODE WHERE {condition}");
            return sql;
            //sql = Query($"WITH tempDebitCredit AS ( SELECT a.VOUCHER_DETAILS_ID, a.VOUCHER_NO,a.ACCOUNT_HEADER_CODE,a.VOU_DESCRIPTION,t5.CENTER_NAME,t10.ACCOUNT_HEADER_NAME, a.DEBIT , a.CREDIT, a.DEBIT - CREDIT 'BALANCE' FROM AT13002 a JOIN AT13001 t1 ON a.VOUCHER_NO =t1.VOUCHER_NO JOIN T12005 t5 ON t1.CENTER_CODE =t5.CENTER_CODE JOIN T12010 t10 ON a.ACCOUNT_HEADER_CODE =t10.ACCOUNT_HEADER_CODE  WHERE {condition} ) SELECT a.VOUCHER_DETAILS_ID,a.VOUCHER_NO, a.ACCOUNT_HEADER_CODE,a.VOU_DESCRIPTION,a.CENTER_NAME, a.ACCOUNT_HEADER_NAME, a.DEBIT, a.CREDIT, SUM(b.BALANCE) 'BALANCE' FROM tempDebitCredit a, tempDebitCredit b WHERE b.VOUCHER_DETAILS_ID <= a.VOUCHER_DETAILS_ID GROUP BY a.VOUCHER_DETAILS_ID,a.VOUCHER_NO, a.ACCOUNT_HEADER_CODE,a.VOU_DESCRIPTION,a.DEBIT, a.CREDIT,a.CENTER_NAME, a.ACCOUNT_HEADER_NAME");
        }
    }
}
