using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDataAccess.Models
{
    public class UserPermit
    {
        public int upm_id { get; set; }
        public int upm_uro_id { get; set; }
        public int upm_umd_id { get; set; }
        public bool upm_select { get; set; }
        public bool upm_insert { get; set; }
        public bool upm_update { get; set; }
        public bool upm_delete { get; set; }
        public int upm_audit_id { get; set; }
        public DateTime upm_audit_date { get; set; }
        public bool upm_deleted { get; set; }
    }
}
