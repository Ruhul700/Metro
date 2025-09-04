using System.Collections.Generic;

namespace Metro_Rail_DAL.Shared.Budget.Transaction
{
    public class T12023Data
    {
        public int T_BUDGET_ID { get; set; }
        public string T_PROJECT_CODE { get; set; }
        public List<T12023List> T12023List { get; set; }
    }
    public class T12023List
    {
        public int T_BUDGET_ID { get; set; }
        public string T_PROJECT_CODE { get; set; }
        public string T_BUDGET_CODE { get; set; }
        public string T_ACCOUNT_HEADER_CODE { get; set; }
        public string ACCOUNT_ECONO_CODE { get; set; }
        public decimal T_FUND_COLLECT { get; set; }
        public Header ddlActHead { get; set; }
    }
    public class Header
    {
        public string ACCOUNT_HEADER_CODE { get; set; }
        public string ACCOUNT_HEADER_NAME { get; set; }
    }
}
