using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDataAccess.Models
{
    public class SupervisorFilter
    {
        public int p_suprep_sup_id { get; set; }
        public DateTime p_suprep_date_ini { get; set; }
        public DateTime p_suprep_date_end { get; set; }
        public decimal p_suprep_in_dollar { get; set; }
        public decimal p_suprep_out_dollar { get; set; }
        public decimal p_suprep_in_euro { get; set; }
        public decimal p_suprep_out_euro { get; set; }
        public decimal p_suprep_in_peso { get; set; }
        public decimal p_suprep_out_peso { get; set; }
    }
}
