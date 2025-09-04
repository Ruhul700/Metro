using System.Collections.Generic;

namespace Metro_Rail_DAL.Shared.Accounts.Transaction
{
    public class T13006Data
    {
        public T13006Single SingleData { get; set; }
        public List<T13006List> ListData { get; set; }
    }
    public class T13006Single
    {
        public int VOUCHER_MASTER_ID { get; set; }
        public string VOUCHER_NO { get; set; }
        public string VOUCHER_DATE { get; set; }
        public string CENTER_CODE { get; set; }
        public string T_PROJECT_CODE { get; set; }
        public string VAUCHER_TYPE_CODE { get; set; }
        public string TRANSACTION_TYPE_CODE { get; set; }
        public string PARTY_TYPE_CODE { get; set; }
        public string PARTY_CODE { get; set; }
        public decimal TOTAL_DEBIT { get; set; }
        public decimal TOTAL_CREDIT { get; set; }
        public string VERIFY_FLG { get; set; }
        public string POSTING_FLG { get; set; }
        public string ENTRY_USER { get; set; }
        public string UPDATE_USER { get; set; }
        public string ENTRY_DATE { get; set; }
        public string UPDATE_DATE { get; set; }
    }
    public class T13006List
    {
        public int VOUCHER_DETAILS_ID { get; set; }
        public string VOUCHER_NO { get; set; }
        public string PARTY_CODE { get; set; }
        public string ACCOUNT_HEADER_CODE { get; set; }
        public string DEPARTMENT_CODE { get; set; }
        public string PURPOSE_CODE { get; set; }
        public string VOU_DESCRIPTION { get; set; }
        public decimal DEBIT { get; set; }
        public decimal CREDIT { get; set; }
        public string ENTRY_USER { get; set; }
        public string UPDATE_USER { get; set; }
        public string ENTRY_DATE { get; set; }
        public string UPDATE_DATE { get; set; }
    }
    public class T13006ParamList
    {
        public string T_RADIO_VALUE { get; set; }
        public string T_SEARCH { get; set; }
    }
}
