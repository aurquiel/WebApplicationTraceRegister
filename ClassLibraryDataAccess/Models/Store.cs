namespace ClassLibraryDataAccess.Models
{
    public class Store
    {
        public int sto_id { get; set; }
        public int sto_code { get; set; }
        public int sto_sup_id { get; set; }
        public int sto_audit_id { get; set; }
        public DateTime sto_audit_date { get; set; }
        public bool sto_audit_delete { get; set; }
    }
}
