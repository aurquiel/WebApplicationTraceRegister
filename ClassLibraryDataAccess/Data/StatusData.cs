using ClassLibraryDataAccess.DbAccess;
using ClassLibraryDataAccess.Models;
using ClassLibraryTools;

namespace ClassLibraryDataAccess.Data
{
    public class StatusData : IStatusData
    {
        private readonly ISqlDataAccess _db;

        public StatusData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Status>> GetAll()
        {
            return await _db.LoadData<Status, dynamic>("spStatusGetAll", new { }, "Default");
        }

        public async Task<int> Insert(Status status)
        {
             return (await _db.LoadData<int, dynamic>("spStatusInsert", 
                new {
                    sta_description = status.sta_description,
                    sta_audit_id = status.sta_audit_id,
                    sta_audit_date = status.sta_audit_date,
                    sta_audit_delete = status.sta_audit_delete
                }, 
                "Default")).FirstOrDefault();
        }

        public async Task<int> Update(Status status)
        {
            return (await _db.LoadData<int, dynamic>("spStatusUpdate",
                new
                {
                    sta_id = status.sta_id,
                    sta_description = status.sta_description,
                    sta_audit_id = status.sta_audit_id,
                    sta_audit_date = status.sta_audit_date
                },
                "Default")).FirstOrDefault();
        }

        public async Task<int> Delete(Status status)
        {
            return (await _db.LoadData<int, dynamic>("spStatusDelete",
                new
                {
                    sta_id = status.sta_id,
                    sta_audit_id = status.sta_audit_id,
                    sta_audit_date = status.sta_audit_date
                },
                "Default")).FirstOrDefault();
        }
    }
}
