using ClassLibraryDataAccess.DbAccess;
using ClassLibraryDataAccess.Models;
using static System.Formats.Asn1.AsnWriter;

namespace ClassLibraryDataAccess.Data
{
    public class StoreData : IStoreData
    {
        private readonly ISqlDataAccess _db;

        public StoreData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Store>> GetAll()
        {
            return await _db.LoadData<Store, dynamic>("spStoreGetAll", new { }, "Default");
        }

        public async Task<int> Insert(Store store)
        {
             return (await _db.LoadData<int, dynamic>("spStoreInsert", 
                new {
                    sto_code = store.sto_code,
                    sto_sup_id = store.sto_sup_id,
                    sto_audit_id = store.sto_audit_id,
                    sto_audit_date = store.sto_audit_date,
                    sto_audit_delete = store.sto_audit_delete
                }, 
                "Default")).FirstOrDefault();
        }

        public async Task<int> Update(Store store)
        {
            return (await _db.LoadData<int, dynamic>("spStoreUpdate",
                new
                {
                    sto_id = store.sto_id,
                    sto_code = store.sto_code,
                    sto_sup_id = store.sto_sup_id,
                    sto_audit_id = store.sto_audit_id,
                    sto_audit_date = store.sto_audit_date
                },
                "Default")).FirstOrDefault();
        }

        public async Task<int> Delete(Store store)
        {
            return (await _db.LoadData<int, dynamic>("spStoreDelete",
                new
               {
                   sto_id = store.sto_id,
                   sto_audit_id = store.sto_audit_id,
                   sto_audit_date = store.sto_audit_date
                },
               "Default")).FirstOrDefault();
        }

    }
}
