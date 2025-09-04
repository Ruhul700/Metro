using System.Data;

namespace Metro_Rail_DAL.DAL.Accounts.Report
{
    public  class R13002DAL : CommonDAL
    {
        public DataTable RrialBalance(string center, string fromDate, string toDate)
        {
            DataTable sql = new DataTable();
            var condition = "";
            if (center == "0")
            { condition = $" CONVERT(date, t1.VOUCHER_DATE ,104) BETWEEN CONVERT(date, '{fromDate}' ,104) AND CONVERT(date, '{toDate}' ,104)"; }
            else { condition = $"t1.CENTER_CODE ='{center}' AND CONVERT(date, t1.VOUCHER_DATE ,104) BETWEEN CONVERT(date, '{fromDate}' ,104) AND CONVERT(date, '{toDate}' ,104)"; }

            sql = Query($"Select t_1.*,(Case when t_1.BALANCE > 0 then t_1.BALANCE else 00 end ) AS DEBITBALANCE, (Case when t_1.BALANCE < 0 then cast( SUBSTRING(cast(t_1.BALANCE as char),2,20) as decimal(18,2)) else 00 end ) AS CREDITBALANCE from ( Select a2.ACCOUNT_HEADER_CODE, t10.ACCOUNT_HEADER_NAME,SUM( DEBIT) DEBIT,SUM(CREDIT) CREDIT, SUM( DEBIT)-SUM(CREDIT) AS BALANCE from AT13002 a2 JOIN AT13001 t1 ON a2.VOUCHER_NO =t1.VOUCHER_NO JOIN T12005 t5 ON t1.CENTER_CODE =t5.CENTER_CODE JOIN T12010 t10 ON a2.ACCOUNT_HEADER_CODE =t10.ACCOUNT_HEADER_CODE WHERE {condition} GROUP BY a2.ACCOUNT_HEADER_CODE, t10.ACCOUNT_HEADER_NAME )t_1");
            return sql;
            
        }
        public DataTable IncomeStatement(string center, string fromDate, string toDate)
        {
            DataTable sql = new DataTable();
            var condition = "";
            if (center == "0")
            { condition = $" CONVERT(date, AT13001.VOUCHER_DATE ,104) BETWEEN CONVERT(date, '{fromDate}' ,104) AND CONVERT(date, '{toDate}' ,104)"; }
            else { condition = $"AT13001.CENTER_CODE ='{center}' AND CONVERT(date, AT13001.VOUCHER_DATE ,104) BETWEEN CONVERT(date, '{fromDate}' ,104) AND CONVERT(date, '{toDate}' ,104)"; }

            sql = Query($@"select t_1.ACCOUNT_TYPE_CODE,
                t_1.VOU_DESCRIPTION,
                SUM(CREDIT) CREDIT,
                SUM(DEBIT) DEBIT,
                (case when t_1.ACCOUNT_TYPE_CODE = '104' then '1 Revenue' else '2 Expense' end ) TYPE
                from(
                select T12013.ACCOUNT_TYPE_CODE,
                T12010.ACCOUNT_HEADER_NAME VOU_DESCRIPTION,
                SUM(CREDIT) - SUM(DEBIT) CREDIT,
                 00 DEBIT
                from AT13002 join AT13001 on AT13002.VOUCHER_NO = AT13001.VOUCHER_NO
                left
                join T12010 on AT13002.ACCOUNT_HEADER_CODE = T12010.ACCOUNT_HEADER_CODE

           left join T12013 on T12010.ACCOUNT_TYPE_CODE = T12013.ACCOUNT_TYPE_CODE
                where (T12013.ACCOUNT_TYPE_CODE = '104')               
                AND AT13002.ACCOUNT_HEADER_CODE not in ('142')
                AND { condition}
            GROUP BY T12013.ACCOUNT_TYPE_CODE,
                T12010.ACCOUNT_HEADER_NAME,DEBIT
                union all
                select T12013.ACCOUNT_TYPE_CODE,
                T12010.ACCOUNT_HEADER_NAME VOU_DESCRIPTION,
                00 CREDIT,
                SUM(DEBIT) - SUM(CREDIT) DEBIT
                  from AT13002
                  join AT13001 on AT13002.VOUCHER_NO = AT13001.VOUCHER_NO
                left join T12010 on AT13002.ACCOUNT_HEADER_CODE = T12010.ACCOUNT_HEADER_CODE
                left join T12013 on T12010.ACCOUNT_TYPE_CODE = T12013.ACCOUNT_TYPE_CODE
                where(T12013.ACCOUNT_TYPE_CODE = '105'
                )
                AND { condition}
            GROUP BY T12013.ACCOUNT_TYPE_CODE,
                T12010.ACCOUNT_HEADER_NAME,
                CREDIT
                )t_1
                GROUP BY t_1.ACCOUNT_TYPE_CODE,
                t_1.VOU_DESCRIPTION");
            return sql;

        }

        public DataTable BalanceSheet(string center, string fromDate, string toDate)
        {
            DataTable sql = new DataTable();
            var condition = "";
            if (center == "0")
            { condition = $" CONVERT(date, AT13001.VOUCHER_DATE ,104) BETWEEN CONVERT(date, '{fromDate}' ,104) AND CONVERT(date, '{toDate}' ,104)"; }
            else { condition = $"AT13001.CENTER_CODE ='{center}' AND CONVERT(date, AT13001.VOUCHER_DATE ,104) BETWEEN CONVERT(date, '{fromDate}' ,104) AND CONVERT(date, '{toDate}' ,104)"; }

            sql = Query($"select ACCOUNT_HEADER_NAME,(DEBIT-CREDIT) BALANCE ,00 AS DEPRECIATION from ( select T12010.ACCOUNT_HEADER_NAME, SUM(DEBIT) DEBIT ,SUM(CREDIT) CREDIT from AT13002 JOIN AT13001 ON AT13002.VOUCHER_NO = AT13001.VOUCHER_NO JOIN T12010 ON AT13002.ACCOUNT_HEADER_CODE = T12010.ACCOUNT_HEADER_CODE JOIN T12013 ON T12010.ACCOUNT_TYPE_CODE = T12013.ACCOUNT_TYPE_CODE where T12010.ACCOUNT_TYPE_CODE ='101' AND {condition} GROUP BY T12010.ACCOUNT_HEADER_NAME )t_1");
            //  sql = Query($"select ACCOUNT_HEADER_NAME,(DEBIT-CREDIT) BALANCE ,00 AS DEPRECIATION from ( select T12010.ACCOUNT_HEADER_NAME, SUM(DEBIT) DEBIT ,SUM(CREDIT) CREDIT from AT13002 JOIN AT13001 ON AT13002.VOUCHER_NO = AT13001.VOUCHER_NO JOIN T12010 ON AT13002.ACCOUNT_HEADER_CODE = T12010.ACCOUNT_HEADER_CODE JOIN T12013 ON T12010.ACCOUNT_TYPE_CODE = T12013.ACCOUNT_TYPE_CODE where T12010.ACCOUNT_TYPE_CODE ='101' AND {condition} GROUP BY T12010.ACCOUNT_HEADER_NAME )t_1 UNION ALL select T12010.ACCOUNT_HEADER_NAME,00 as BALANCE,CREDIT DEPRECIATION from AT13002 JOIN AT13001 ON AT13002.VOUCHER_NO = AT13001.VOUCHER_NO JOIN T12010 ON AT13002.ACCOUNT_HEADER_CODE = T12010.ACCOUNT_HEADER_CODE JOIN T12013 ON T12010.ACCOUNT_TYPE_CODE = T12013.ACCOUNT_TYPE_CODE where T12010.ACCOUNT_HEADER_CODE ='134' AND {condition}");
            return sql;
        }
        public DataTable Depreciation(string center, string fromDate, string toDate)
        {
            DataTable sql = new DataTable();
            var condition = "";
            if (center == "0")
            { condition = $" CONVERT(date, AT13001.VOUCHER_DATE ,104) BETWEEN CONVERT(date, '{fromDate}' ,104) AND CONVERT(date, '{toDate}' ,104)"; }
            else { condition = $"AT13001.CENTER_CODE ='{center}' AND CONVERT(date, AT13001.VOUCHER_DATE ,104) BETWEEN CONVERT(date, '{fromDate}' ,104) AND CONVERT(date, '{toDate}' ,104)"; }
            sql = Query($"select SUM( CREDIT) DEPRECIATION from AT13002 JOIN AT13001 ON AT13002.VOUCHER_NO = AT13001.VOUCHER_NO JOIN T12010 ON AT13002.ACCOUNT_HEADER_CODE = T12010.ACCOUNT_HEADER_CODE JOIN T12013 ON T12010.ACCOUNT_TYPE_CODE = T12013.ACCOUNT_TYPE_CODE where T12010.ACCOUNT_HEADER_CODE ='134' AND {condition}");
            return sql;
        }
        public DataTable Liability(string center, string fromDate, string toDate)
        {
            DataTable sql = new DataTable();
            var condition = "";
            if (center == "0")
            { condition = $" CONVERT(date, AT13001.VOUCHER_DATE ,104) BETWEEN CONVERT(date, '{fromDate}' ,104) AND CONVERT(date, '{toDate}' ,104)"; }
            else { condition = $"AT13001.CENTER_CODE ='{center}' AND CONVERT(date, AT13001.VOUCHER_DATE ,104) BETWEEN CONVERT(date, '{fromDate}' ,104) AND CONVERT(date, '{toDate}' ,104)"; }

            sql = Query($@"Select T12013.ACCOUNT_TYPE_NAME ACCOUNT_HEADER_NAME,
                    SUM (CREDIT)-SUM(DEBIT)  BALANCE from AT13002 at2 join AT13001 on at2.VOUCHER_NO = AT13001.VOUCHER_NO
                    join T12010 on at2.ACCOUNT_HEADER_CODE = T12010.ACCOUNT_HEADER_CODE
                    JOIN T12013 ON T12010.ACCOUNT_TYPE_CODE = T12013.ACCOUNT_TYPE_CODE
                    where(T12013.ACCOUNT_TYPE_CODE in ('102', '103'))
                    AND {condition}                    
                    GROUP BY T12013.ACCOUNT_TYPE_NAME
                    union
                    select 'Net profit' AS ACCOUNT_HEADER_NAME,
                    (SUM(t_1.CREDIT) - SUM(t_1.DEBIT)) BALANCE
                    from(
                    select T12013.ACCOUNT_TYPE_CODE,
                    T12010.ACCOUNT_HEADER_NAME VOU_DESCRIPTION,
                    SUM(CREDIT) - SUM(DEBIT) CREDIT,
                     00 DEBIT
                    from AT13002 join AT13001 on AT13002.VOUCHER_NO = AT13001.VOUCHER_NO
                    left
                    join T12010 on AT13002.ACCOUNT_HEADER_CODE = T12010.ACCOUNT_HEADER_CODE
                    left
                    join T12013 on T12010.ACCOUNT_TYPE_CODE = T12013.ACCOUNT_TYPE_CODE
                    where (T12013.ACCOUNT_TYPE_CODE = '104')
                    AND {condition}
                    GROUP BY T12013.ACCOUNT_TYPE_CODE,
                    T12010.ACCOUNT_HEADER_NAME, DEBIT
                    union all
                    select T12013.ACCOUNT_TYPE_CODE,
                    T12010.ACCOUNT_HEADER_NAME VOU_DESCRIPTION,
                    00 CREDIT,
                    SUM(DEBIT) - SUM(CREDIT) DEBIT
                    from AT13002
                    join AT13001 on AT13002.VOUCHER_NO = AT13001.VOUCHER_NO
                    left
                    join T12010 on AT13002.ACCOUNT_HEADER_CODE = T12010.ACCOUNT_HEADER_CODE
                    left
                    join T12013 on T12010.ACCOUNT_TYPE_CODE = T12013.ACCOUNT_TYPE_CODE
                    where (T12013.ACCOUNT_TYPE_CODE = '105')
                    AND {condition}                    
                    GROUP BY T12013.ACCOUNT_TYPE_CODE,
                    T12010.ACCOUNT_HEADER_NAME,
                    CREDIT
                    )t_1");
            return sql;
        }

        public DataTable Banck_Cash_Initial_Balance()
        {
            DataTable sql = new DataTable();
            sql = Query($"Select t_1.*,(Case when t_1.BALANCE > 0 then t_1.BALANCE else 00 end ) AS DEBITBALANCE, (Case when t_1.BALANCE < 0 then cast( SUBSTRING(cast(t_1.BALANCE as char),2,20) as decimal(18,2)) else 00 end ) AS CREDITBALANCE from ( Select a2.ACCOUNT_HEADER_CODE, t10.ACCOUNT_HEADER_NAME,SUM( DEBIT) DEBIT,SUM(CREDIT) CREDIT, SUM( DEBIT)-SUM(CREDIT) AS BALANCE from AT13002 a2 JOIN AT13001 t1 ON a2.VOUCHER_NO =t1.VOUCHER_NO JOIN T12005 t5 ON t1.CENTER_CODE =t5.CENTER_CODE JOIN T12010 t10 ON a2.ACCOUNT_HEADER_CODE =t10.ACCOUNT_HEADER_CODE WHERE a2.ACCOUNT_HEADER_CODE in ('101','108') GROUP BY a2.ACCOUNT_HEADER_CODE, t10.ACCOUNT_HEADER_NAME )t_1");

            return sql;
        }
        public DataTable GeneralLedger(string center, string fromDate, string toDate)
        {
            DataTable sql = new DataTable();
            sql = Query($"select 00 RowNumber, 00 VOUCHER_DETAILS_ID, VOUCHER_DATE, '00' ACCOUNT_HEADER_CODE, 'An Opening' ACCOUNT_HEADER_NAME, 'Opening balance' VOU_DESCRIPTION, '00'VOUCHER_NO, '00' DEBIT, '00'CREDIT, (Balance-DEBIT)+CREDIT AS BALANCE from ( SELECT ROW_NUMBER() OVER (Order by CONVERT(date, t2.VOUCHER_DATE ,104) ,cast(t2.VOUCHER_NO as int)) AS RowNumber, t2.VOUCHER_DETAILS_ID, t2.VOUCHER_DATE, t2.ACCOUNT_HEADER_CODE, t2.ACCOUNT_HEADER_NAME, t2.VOU_DESCRIPTION, t2.VOUCHER_NO, t2.DEBIT, t2.CREDIT, SUM(t1.BALANCE) AS Balance FROM V_CASH_FLOW t1 INNER JOIN V_CASH_FLOW t2 ON t1.VOUCHER_DETAILS_ID <= t2.VOUCHER_DETAILS_ID WHERE CONVERT(date, t2.VOUCHER_DATE ,104) BETWEEN CONVERT(date, '{fromDate}' ,104) AND CONVERT(date, '{toDate}' ,104) GROUP BY t2.VOUCHER_DETAILS_ID,t2.VOUCHER_DATE, t2.VOU_DESCRIPTION, t2.VOUCHER_NO, t2.CREDIT,t2.ACCOUNT_HEADER_CODE, t2.ACCOUNT_HEADER_NAME, t2.DEBIT )t_3 where RowNumber=1 UNION SELECT ROW_NUMBER() OVER (Order by CONVERT(date, t2.VOUCHER_DATE ,104) ,cast(t2.VOUCHER_NO as int)) AS RowNumber, t2.VOUCHER_DETAILS_ID, t2.VOUCHER_DATE, t2.ACCOUNT_HEADER_CODE, t2.ACCOUNT_HEADER_NAME, t2.VOU_DESCRIPTION, t2.VOUCHER_NO, t2.DEBIT, t2.CREDIT, SUM(t1.BALANCE) AS Balance FROM V_CASH_FLOW t1 INNER JOIN V_CASH_FLOW t2 ON t1.VOUCHER_DETAILS_ID <= t2.VOUCHER_DETAILS_ID WHERE CONVERT(date, t2.VOUCHER_DATE ,104) BETWEEN CONVERT(date, '{fromDate}' ,104) AND CONVERT(date, '{toDate}' ,104) GROUP BY t2.VOUCHER_DETAILS_ID,t2.VOUCHER_DATE, t2.VOU_DESCRIPTION,t2.ACCOUNT_HEADER_CODE, t2.ACCOUNT_HEADER_NAME, t2.VOUCHER_NO, t2.CREDIT, t2.DEBIT");
            return sql;
        }
        public DataTable OpeningBalance(string center, string fromDate, string toDate)
        {
            DataTable sql = new DataTable();
            sql = Query($"select 00 VOUCHER_DETAILS_ID, VOUCHER_DATE,'Opening balance' VOU_DESCRIPTION,'00'VOUCHER_NO,'00' DEBIT,'00'CREDIT,(Balance-DEBIT)+CREDIT AS OPEN_BALANCE from ( SELECT ROW_NUMBER() OVER (Order by t2.VOUCHER_DETAILS_ID) AS RowNumber, t2.VOUCHER_DETAILS_ID, t2.VOUCHER_DATE, t2.VOU_DESCRIPTION, t2.VOUCHER_NO, t2.DEBIT, t2.CREDIT, SUM(t1.BALANCE) AS Balance FROM V_CASH_FLOW t1 INNER JOIN V_CASH_FLOW t2 ON t1.VOUCHER_DETAILS_ID <= t2.VOUCHER_DETAILS_ID WHERE CONVERT(date, t2.VOUCHER_DATE ,104) BETWEEN CONVERT(date, '{fromDate}' ,104) AND CONVERT(date, '{toDate}' ,104) GROUP BY t2.VOUCHER_DETAILS_ID,t2.VOUCHER_DATE, t2.VOU_DESCRIPTION, t2.VOUCHER_NO, t2.CREDIT, t2.DEBIT )t_3 where RowNumber=1");

            return sql;
        }
        public DataTable GeneralLedger_cash(string center, string fromDate, string toDate)
        {
            DataTable sql = new DataTable();
            sql = Query($"select 00 RowNumber, 00 VOUCHER_DETAILS_ID, VOUCHER_DATE,ENTRY_DATE, '00' ACCOUNT_HEADER_CODE, 'An Opening' ACCOUNT_HEADER_NAME, 'Opening balance' VOU_DESCRIPTION, '00'VOUCHER_NO, '00' DEBIT, '00'CREDIT, (Balance-DEBIT)+CREDIT AS BALANCE from ( SELECT ROW_NUMBER() OVER (Order by CONVERT(date, t2.ENTRY_DATE ,104) , cast(t2.VOUCHER_NO as int)) AS RowNumber, t2.VOUCHER_DETAILS_ID, t2.VOUCHER_DATE, t2.ENTRY_DATE, t2.ACCOUNT_HEADER_CODE, t2.ACCOUNT_HEADER_NAME, t2.VOU_DESCRIPTION, t2.VOUCHER_NO, t2.DEBIT, t2.CREDIT, SUM(t1.BALANCE) AS Balance FROM V_CASH_FLOW_CASH t1 INNER JOIN V_CASH_FLOW_CASH t2 ON t1.VOUCHER_DETAILS_ID <= t2.VOUCHER_DETAILS_ID WHERE CONVERT(date, t2.ENTRY_DATE ,104) BETWEEN CONVERT(date, '{fromDate}' ,104) AND CONVERT(date, '{toDate}' ,104) GROUP BY t2.VOUCHER_DETAILS_ID,t2.VOUCHER_DATE,t2.ENTRY_DATE, t2.VOU_DESCRIPTION, t2.VOUCHER_NO, t2.CREDIT,t2.ACCOUNT_HEADER_CODE, t2.ACCOUNT_HEADER_NAME, t2.DEBIT )t_3 where RowNumber=1 UNION SELECT ROW_NUMBER() OVER (Order by CONVERT(date, t2.ENTRY_DATE ,104) , cast(t2.VOUCHER_NO as int)) AS RowNumber, t2.VOUCHER_DETAILS_ID, t2.VOUCHER_DATE, t2.ENTRY_DATE, t2.ACCOUNT_HEADER_CODE, t2.ACCOUNT_HEADER_NAME, t2.VOU_DESCRIPTION, t2.VOUCHER_NO, t2.DEBIT, t2.CREDIT, SUM(t1.BALANCE) AS Balance FROM V_CASH_FLOW_CASH t1 INNER JOIN V_CASH_FLOW_CASH t2 ON t1.VOUCHER_DETAILS_ID <= t2.VOUCHER_DETAILS_ID WHERE CONVERT(date, t2.ENTRY_DATE ,104) BETWEEN CONVERT(date, '{fromDate}' ,104) AND CONVERT(date, '{toDate}' ,104) GROUP BY t2.VOUCHER_DETAILS_ID,t2.VOUCHER_DATE, t2.ENTRY_DATE, t2.VOU_DESCRIPTION,t2.ACCOUNT_HEADER_CODE, t2.ACCOUNT_HEADER_NAME, t2.VOUCHER_NO, t2.CREDIT, t2.DEBIT");
            return sql;
        }
        public DataTable OpeningBalance_cash(string center, string fromDate, string toDate)
        {
            DataTable sql = new DataTable();
            sql = Query($"select 00 VOUCHER_DETAILS_ID, VOUCHER_DATE,'Opening balance' VOU_DESCRIPTION,'00'VOUCHER_NO,'00' DEBIT,'00'CREDIT,(Balance-DEBIT)+CREDIT AS OPEN_BALANCE from ( SELECT ROW_NUMBER() OVER (Order by t2.VOUCHER_DETAILS_ID) AS RowNumber, t2.VOUCHER_DETAILS_ID, t2.VOUCHER_DATE, t2.VOU_DESCRIPTION, t2.VOUCHER_NO, t2.DEBIT, t2.CREDIT, SUM(t1.BALANCE) AS Balance FROM V_CASH_FLOW_CASH t1 INNER JOIN V_CASH_FLOW_CASH t2 ON t1.VOUCHER_DETAILS_ID <= t2.VOUCHER_DETAILS_ID WHERE CONVERT(date, t2.VOUCHER_DATE ,104) BETWEEN CONVERT(date, '{fromDate}' ,104) AND CONVERT(date, '{toDate}' ,104) GROUP BY t2.VOUCHER_DETAILS_ID,t2.VOUCHER_DATE, t2.VOU_DESCRIPTION, t2.VOUCHER_NO, t2.CREDIT, t2.DEBIT )t_3 where RowNumber=1");

            return sql;
        }
    }
}
