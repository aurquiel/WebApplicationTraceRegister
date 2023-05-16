using ClassLibraryDataAccess.DbAccess;
using ClassLibraryDataAccess.Models;

namespace ClassLibraryDataAccess.Data
{
    public class StoreReportData : IStoreReportData
    {
        private readonly ISqlDataAccess _db;

        public StoreReportData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<StoreReport>> GetByMonth(int storep_sto_id, DateTime storep_date)
        {
            return await _db.LoadData<StoreReport, dynamic>("spStoreReportGetByMonth", 
                new {
                    storep_sto_id = storep_sto_id,
                    storep_date = storep_date
                }, 
                "Default");
        }

        public async Task Insert(StoreReport storeReport)
        {
             await _db.SaveData("spStoreReportInsert", 
                new {
                    storep_sto_id = storeReport.storep_sto_id,
                    storep_date = storeReport.storep_date,
                    storep_total_bs = storeReport.storep_total_bs,
                    storep_change_bs = storeReport.storep_change_bs,
                    storep_rate = storeReport.storep_rate,
                    storep_equivalent_dollar = storeReport.storep_equivalent_dollar,
                    storep_payed_euro = storeReport.storep_payed_euro,
                    storep_payed_zelle = storeReport.storep_payed_zelle,
                    storep_payed_dollar = storeReport.storep_payed_dollar,
                    storep_expended_dollar = storeReport.storep_expended_dollar,
                    storep_total_dollar = storeReport.storep_total_dollar,
                    storep_sta_id = storeReport.storep_sta_id,
                    storep_sup_id = storeReport.storep_sup_id,
                    storep_comments = storeReport.storep_comments,
                    storep_starep_id = storeReport.storep_starep_id,
                    storep_audit_id = storeReport.storep_audit_id,
                    storep_audit_date = storeReport.storep_audit_date,
                    storep_audit_delete = storeReport.storep_audit_delete
                }, 
                "Default");
        }

        public async Task Update(StoreReport storeReport)
        {
            await _db.SaveData("spStoreReportUpdate",
                new
                {
                    storep_id = storeReport.storep_id,
                    storep_sto_id = storeReport.storep_sto_id,
                    storep_date = storeReport.storep_date,
                    storep_total_bs = storeReport.storep_total_bs,
                    storep_change_bs = storeReport.storep_change_bs,
                    storep_rate = storeReport.storep_rate,
                    storep_equivalent_dollar = storeReport.storep_equivalent_dollar,
                    storep_payed_euro = storeReport.storep_payed_euro,
                    storep_payed_zelle = storeReport.storep_payed_zelle,
                    storep_payed_dollar = storeReport.storep_payed_dollar,
                    storep_expended_dollar = storeReport.storep_expended_dollar,
                    storep_total_dollar = storeReport.storep_total_dollar,
                    storep_sta_id = storeReport.storep_sta_id,
                    storep_sup_id = storeReport.storep_sup_id,
                    storep_comments = storeReport.storep_comments,
                    storep_starep_id = storeReport.storep_starep_id,
                    storep_audit_id = storeReport.storep_audit_id,
                    storep_audit_date = storeReport.storep_audit_date
                },
                "Default");
        }

        public async Task Delete(StoreReport storeReport)
        {
            await _db.SaveData("spStoreReportDelete",
                new
                {
                    storep_id = storeReport.storep_id,
                    storep_audit_id = storeReport.storep_audit_id,
                    storep_audit_date = storeReport.storep_audit_date
                },
                "Default");
        }

        public async Task<StoreReportExist> GetExist(int storep_sto_id, DateTime storep_date)
        {
            var result = await _db.LoadData<(int, int), dynamic>("spStoreReportExist",
                new
                {
                    storep_sto_id = storep_sto_id,
                    storep_date = storep_date,
                    storep_record_exists = 0,
                    storep_record_processed = 0
                },
                "Default");

            return new StoreReportExist
            {
                storep_record_exists = result.FirstOrDefault().Item1 == 1 ? true : false,
                storep_record_processed = result.FirstOrDefault().Item2 == 1 ? true : false
            };
        }
    }
}
