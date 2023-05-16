namespace ClassLibraryDataAccess.Models
{
    public class Supervisor
    {
        public int sup_id { get; set; }
        public string sup_description { get; set; }
        public int sup_audit_id { get; set; }
        public DateTime sup_audit_date { get; set; }
        public bool sup_audit_delete { get; set; }

    }
}
