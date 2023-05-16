using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDataAccess.Models
{
    public class StoreFilter
    {
        public string p_storep_sto_id { get; set;}
        public DateTime p_storep_date_ini { get; set;}
        public DateTime p_storep_date_end { get; set;}
        public decimal p_storep_total_bs { get; set; }
        public decimal p_storep_change_bs { get; set; }
        public decimal p_storep_equivalent_dollar { get; set; }
        public decimal p_storep_payed_euro { get; set; }
        public decimal p_storep_payed_zelle { get; set; }
        public decimal p_storep_payed_dollar { get; set; }
        public decimal p_storep_expended_dollar { get; set; }
        public decimal p_storep_total_dollar { get; set; }
        public int p_storep_sta_id { get; set; }
    }
}
