using System.Data;

namespace Metro_Rail_DAL.DAL.Accounts.Report
{
    public class R13004DAL: CommonDAL
    {
        public DataTable GetAllCustomer()
        {
            DataTable sql = new DataTable();
            sql = Query($"select T_CUSTOMER_ID,CONCAT(T_CUSTOMER_ID,' - ',T_CUSTOMER_NAME,' - ',T_CUSTOMER_ADDRESS,' - ',T_CUSTOMER_MOBILE) CUST_NAME from T15000 WHERE T_CUSTOMER_MOBILE IS NOT NULL");

            return sql;
        }
        public DataTable IndividualCustomer(string custId,string fDate,string tDate)
        {
            DataTable sql = new DataTable();
            sql = Query($@";with Table_Tamp as (
                select VOUCHER_DETAILS_ID,
                AT13001.VOUCHER_NO,
                 AT13001.T_CUSTOMER_ID,
                AT13001.ENTRY_DATE,
                AT13001.VOUCHER_DATE,
                AT13001.PARTY_TYPE_CODE,
                 T15000.T_CUSTOMER_NAME PARTY_TYPE_NAME,
                AT13002.ACCOUNT_HEADER_CODE,
                T12010.ACCOUNT_HEADER_NAME,
                VOU_DESCRIPTION,
                DEBIT,
                CREDIT,
                (DEBIT - CREDIT)BALANCE
                from AT13002
                JOIN AT13001 ON AT13002.VOUCHER_NO = AT13001.VOUCHER_NO
                JOIN T15000 ON AT13001.T_CUSTOMER_ID = T15000.T_CUSTOMER_ID 
                JOIN T12010 ON AT13002.ACCOUNT_HEADER_CODE = T12010.ACCOUNT_HEADER_CODE
                WHERE

                AT13001.T_CUSTOMER_ID = '{custId}'

            and AT13001.VAUCHER_TYPE_CODE = '102'
                AND AT13002.ACCOUNT_HEADER_CODE != '138'
                AND AT13002.ACCOUNT_HEADER_CODE != '137'
                 )
                  select
                00 RowNumber,
                PARTY_TYPE_NAME,
                00 VOUCHER_DETAILS_ID, 
                '00'VOUCHER_DATE, 
                '00'ENTRY_DATE,
                '00' ACCOUNT_HEADER_CODE, 
                'An Opening' ACCOUNT_HEADER_NAME,
                'Opening balance' VOU_DESCRIPTION,
                '00' DEBIT,
                '00'CREDIT,
                (Balance - DEBIT) + CREDIT AS BALANCE
                from(
                SELECT ROW_NUMBER() OVER(Order by t2.VOUCHER_DETAILS_ID) AS RowNumber,
                t2.PARTY_TYPE_NAME,
                t2.VOUCHER_DETAILS_ID,
                t2.VOUCHER_DATE,
                t2.ENTRY_DATE,
                t2.ACCOUNT_HEADER_CODE,
                t2.ACCOUNT_HEADER_NAME,
                t2.VOU_DESCRIPTION,
                t2.DEBIT,
                t2.CREDIT,
                SUM(t1.BALANCE) AS Balance
                from Table_Tamp t1
                INNER JOIN Table_Tamp t2 ON t1.VOUCHER_DETAILS_ID <= t2.VOUCHER_DETAILS_ID
                WHERE CONVERT(date, t2.ENTRY_DATE, 104)
                BETWEEN CONVERT(date, '{fDate}', 104)
                AND CONVERT(date, '{tDate}', 104)
                GROUP BY
                t2.VOUCHER_DETAILS_ID,
                t2.PARTY_TYPE_NAME,
                t2.VOUCHER_DATE,
                t2.ENTRY_DATE,
                t2.VOU_DESCRIPTION,
                t2.CREDIT,
                t2.ACCOUNT_HEADER_CODE,
                t2.ACCOUNT_HEADER_NAME,
                t2.DEBIT)t_3
                where RowNumber = 1
                UNION select ROW_NUMBER() OVER(Order by t2.VOUCHER_DETAILS_ID) AS RowNumber,
               t2.PARTY_TYPE_NAME,
                t2.VOUCHER_DETAILS_ID, t2.VOUCHER_DATE, t2.ENTRY_DATE,
                t2.ACCOUNT_HEADER_CODE, t2.ACCOUNT_HEADER_NAME,
                t2.VOU_DESCRIPTION, t2.DEBIT, t2.CREDIT,
                SUM(t1.BALANCE) AS Balance from Table_Tamp t1
                INNER JOIN Table_Tamp t2 ON t1.VOUCHER_DETAILS_ID <= t2.VOUCHER_DETAILS_ID
                WHERE CONVERT(date, t2.ENTRY_DATE ,104)
                BETWEEN CONVERT(date, '{fDate}' ,104)
                AND CONVERT(date, '{tDate}' ,104) 
                GROUP BY t2.VOUCHER_DETAILS_ID,
                t2.PARTY_TYPE_NAME,
                t2.VOUCHER_NO,
                t2.VOUCHER_DATE,t2.ENTRY_DATE,
                t2.VOU_DESCRIPTION, t2.CREDIT,
                t2.ACCOUNT_HEADER_CODE, 
                t2.ACCOUNT_HEADER_NAME, 
                t2.DEBIT");

            return sql;
        }
        public DataTable AllCustormerSummary()
        {
            DataTable sql = new DataTable();
            sql = Query($"select PARTY_TYPE_CODE,T_CUSTOMER_ID, T_CUSTOMER_NAME, sum(DEBIT) TOTAL_DEBIT, SUM(CREDIT)TOTAL_CREDIT, (sum(DEBIT)-SUM(CREDIT))TOTAL_BALANCE from ( select AT13001.PARTY_TYPE_CODE, T15000.T_CUSTOMER_NAME,AT13001.T_CUSTOMER_ID, AT13002.VOUCHER_NO, AT13002.ACCOUNT_HEADER_CODE, T12010.ACCOUNT_HEADER_NAME, AT13002.DEBIT, AT13002.CREDIT from AT13002 JOIN AT13001 ON AT13002.VOUCHER_NO =AT13001.VOUCHER_NO JOIN T15000 ON AT13001.T_CUSTOMER_ID =T15000.T_CUSTOMER_ID JOIN T12010 ON AT13002.ACCOUNT_HEADER_CODE =T12010.ACCOUNT_HEADER_CODE where AT13001.VAUCHER_TYPE_CODE = '102' AND AT13001.T_CUSTOMER_ID IS NOT NULL AND AT13002.ACCOUNT_HEADER_CODE != '138' AND AT13002.ACCOUNT_HEADER_CODE != '137')t_1 group by PARTY_TYPE_CODE,T_CUSTOMER_ID, T_CUSTOMER_NAME");
            return sql;
        }
    }
}
