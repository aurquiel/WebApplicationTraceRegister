using System;
using System.Collections.Generic;
namespace ClassLibraryDataAccess.Models
{
    public class User
    {
        public int usr_id { get; set; }
        public string usr_alias { get; set; }
        public string usr_password { get; set; }
        public string usr_firstname { get; set; }
        public string usr_lastname { get; set; }
        public int usr_manage_id { get; set; }
        public string usr_email { get; set; }
        public int usr_urol_id { get; set; }
        public int usr_audit { get; set; }
        public DateTime usr_audit_date { get; set; }
        public bool usr_deleted { get; set; }
    }
}
