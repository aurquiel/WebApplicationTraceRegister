using ClassLibraryDataAccess.DbAccess;
using ClassLibraryDataAccess.Models;

namespace ClassLibraryDataAccess.Data
{
    public class FilterData : IFilterData
    {
        private readonly ISqlDataAccess _db;

        public FilterData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<StoreReport>> GetStoreReportFiltered(StoreFilter storeFilter)
        {
            return await _db.LoadData<StoreReport, dynamic>("spConsultStoreReport",
                new
                {
                    p_storep_sto_id = storeFilter.p_storep_sto_id,
                    p_storep_date_ini = storeFilter.p_storep_date_ini.Date.ToString("yyyyMMdd"),
                    p_storep_date_end = storeFilter.p_storep_date_end.Date.ToString("yyyyMMdd"),
                    p_storep_total_bs = storeFilter.p_storep_total_bs,
                    p_storep_change_bs = storeFilter.p_storep_change_bs,
                    p_storep_equivalent_dollar = storeFilter.p_storep_equivalent_dollar,
                    p_storep_payed_euro = storeFilter.p_storep_payed_euro,
                    p_storep_payed_zelle = storeFilter.p_storep_payed_zelle,
                    p_storep_payed_dollar = storeFilter.p_storep_payed_dollar,
                    p_storep_expended_dollar = storeFilter.p_storep_expended_dollar,
                    p_storep_total_dollar = storeFilter.p_storep_total_dollar,
                    p_storep_sta_id = storeFilter.p_storep_sta_id
                },
                "Default");
        }

        public async Task<IEnumerable<SupervisorReport>> GetSupervisorReportFiltered(SupervisorFilter supervisorFilter)
        {
            return await _db.LoadData<SupervisorReport, dynamic>("spConsultSupervisorReport",
                new
                {
                    p_suprep_sup_id = supervisorFilter.p_suprep_sup_id,
                    p_suprep_date_ini = supervisorFilter.p_suprep_date_ini.Date.ToString("yyyyMMdd"),
                    p_suprep_date_end = supervisorFilter.p_suprep_date_end.Date.ToString("yyyyMMdd"),
                    p_suprep_in_dollar = supervisorFilter.p_suprep_in_dollar,
                    p_suprep_out_dollar = supervisorFilter.p_suprep_out_dollar,
                    p_suprep_in_euro = supervisorFilter.p_suprep_in_euro,
                    p_suprep_out_euro = supervisorFilter.p_suprep_out_euro,
                    p_suprep_in_peso = supervisorFilter.p_suprep_in_peso,
                    p_suprep_out_peso = supervisorFilter.p_suprep_out_peso
                },
                "Default");
        }
    }
}
