namespace ClassLibraryDataAccess.Models
{
    public class StatusReport
    {
        public int starep_id { get; set; }
        public string starep_description { get; set; }
        public int starep_audit_id { get; set; }
        public DateTime starep_audit_date { get; set; }
        public bool starep_audit_delete { get; set; }
    }
}
