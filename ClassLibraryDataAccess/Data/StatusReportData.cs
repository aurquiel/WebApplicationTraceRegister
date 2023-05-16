using ClassLibraryDataAccess.DbAccess;
using ClassLibraryDataAccess.Models;
using ClassLibraryTools;

namespace ClassLibraryDataAccess.Data
{
    public class StatusReportData : IStatusReportData
    {
        private readonly ISqlDataAccess _db;

        public StatusReportData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<StatusReport>> GetAll()
        {
            return await _db.LoadData<StatusReport, dynamic>("spStatusReportGetAll", new { }, "Default");
        }
    }
}
