using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDataAccess.Models
{
    public class UserModuleDetail
    {
        public int umd_id { get; set; }
        public int umd_umo_id { get; set; }
        public string umd_name { get;set; }
        public int umd_audit_id { get; set; }
        public DateTime umd_audit_date { get; set; }
        public bool umd_deleted { get; set; }
    }
}
