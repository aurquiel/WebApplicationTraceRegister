using ClassLibraryDataAccess.DbAccess;
using ClassLibraryDataAccess.Models;
using ClassLibraryTools;

namespace ClassLibraryDataAccess.Data
{
    public class SupervisorData : ISupervisorData
    {
        private readonly ISqlDataAccess _db;

        public SupervisorData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Supervisor>> GetAll()
        {
            return await _db.LoadData<Supervisor, dynamic>("spSupervisorGetAll", new { }, "Default");
        }

        public async Task<int> Insert(Supervisor supervisor)
        {
            return (await _db.LoadData<int, dynamic>("spSupervisorInsert", 
                new {
                    sup_description = supervisor.sup_description,
                    sup_audit_id = supervisor.sup_audit_id,
                    sup_audit_date = supervisor.sup_audit_date,
                    sup_audit_delete = supervisor.sup_audit_delete
                }, 
                "Default")).FirstOrDefault();
        }

        public async Task<int> Update(Supervisor supervisor)
        {
            return (await _db.LoadData<int, dynamic>("spSupervisorUpdate",
                new
                {
                    sup_id = supervisor.sup_id,
                    sup_description = supervisor.sup_description,
                    sup_audit_id = supervisor.sup_audit_id,
                    sup_audit_date = supervisor.sup_audit_date
                },
                "Default")).FirstOrDefault();
        }

        public async Task<int> Delete(Supervisor supervisor)
        {
            return (await _db.LoadData<int, dynamic>("spSupervisorDelete",
                new
                {
                    sup_id = supervisor.sup_id,
                    sup_audit_id = supervisor.sup_audit_id,
                    sup_audit_date = supervisor.sup_audit_date
                },
                "Default")).FirstOrDefault();
        }
    }
}
