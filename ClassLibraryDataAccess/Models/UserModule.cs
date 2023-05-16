using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDataAccess.Models
{
    public class UserModule
    {
        public int umo_id { get; set; }
        public string umo_name { get;set; }
        public int umo_audit_id { get; set; }
        public DateTime umo_audit_date { get; set; }
        public bool umo_deleted { get; set; }
    }
}
