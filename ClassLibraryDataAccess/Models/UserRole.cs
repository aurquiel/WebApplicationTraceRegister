namespace ClassLibraryDataAccess.Models
{
    public class UserRole
    {
        public int uro_id { get; set; }
        public string uro_name { get; set; }
        public int uro_audit_id { get; set; }
        public DateTime uro_audit_date { get; set; }
        public bool uro_deleted { get; set; }
    }
}
