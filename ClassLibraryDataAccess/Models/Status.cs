namespace ClassLibraryDataAccess.Models
{
    public class Status
    {
        public int sta_id { get; set; }
        public string sta_description { get; set; }
        public int sta_audit_id { get; set; }
        public DateTime sta_audit_date { get; set; }
        public bool sta_audit_delete { get; set; }
    }
}
