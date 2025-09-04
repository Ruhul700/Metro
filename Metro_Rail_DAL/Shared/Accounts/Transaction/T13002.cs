namespace Metro_Rail_DAL.Shared.Accounts.Transaction
{
    public class T13002Data
    {
        public int VOUCHER_DETAILS_ID { get; set; }
        public string VOUCHER_NO { get; set; }      
        public string PARTY_CODE { get; set; }
        public string ACCOUNT_HEADER_CODE  { get; set; }
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
}