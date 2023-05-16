using ClassLibraryDataAccess.DbAccess;
using ClassLibraryDataAccess.Models;

namespace ClassLibraryDataAccess.Data
{
    public class SupervisorReportData : ISupervisorReportData
    {
        private readonly ISqlDataAccess _db;

        public SupervisorReportData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<SupervisorReport>> GetByMonth(int suprep_sup_id, DateTime suprep_date)
        {
            return await _db.LoadData<SupervisorReport, dynamic>("spSupervisorReportGetByMonth", 
                new {
                    suprep_sup_id = suprep_sup_id,
                    suprep_date = suprep_date
                }, 
                "Default");
        }

        public async Task Insert(SupervisorReport supervisorReport)
        {
             await _db.SaveData("spSupervisorReportInsert", 
                new {
                    suprep_sup_id = supervisorReport.suprep_sup_id,
                    suprep_date = supervisorReport.suprep_date,
                    suprep_sto_id = supervisorReport.suprep_sto_id,
                    suprep_in_dollar = supervisorReport.suprep_in_dollar,
                    suprep_out_dollar = supervisorReport.suprep_out_dollar,
                    suprep_in_euro = supervisorReport.suprep_in_euro,
                    suprep_out_euro = supervisorReport.suprep_out_euro,
                    suprep_in_peso = supervisorReport.suprep_in_peso,
                    suprep_out_peso = supervisorReport.suprep_out_peso,
                    suprep_comments = supervisorReport.suprep_comments,
                    suprep_starep_id = supervisorReport.suprep_starep_id,
                    suprep_audit_id = supervisorReport.suprep_audit_id,
                    suprep_audit_date = supervisorReport.suprep_audit_date,
                    suprep_audit_delete = supervisorReport.suprep_audit_delete
                }, 
                "Default");
        }

        public async Task Update(SupervisorReport supervisorReport)
        {
            await _db.SaveData("spSupervisorReportUpdate",
                new
                {
                    suprep_id = supervisorReport.suprep_id,
                    suprep_sup_id = supervisorReport.suprep_sup_id,
                    suprep_date = supervisorReport.suprep_date,
                    suprep_sto_id = supervisorReport.suprep_sto_id,
                    suprep_in_dollar = supervisorReport.suprep_in_dollar,
                    suprep_out_dollar = supervisorReport.suprep_out_dollar,
                    suprep_in_euro = supervisorReport.suprep_in_euro,
                    suprep_out_euro = supervisorReport.suprep_out_euro,
                    suprep_in_peso = supervisorReport.suprep_in_peso,
                    suprep_out_peso = supervisorReport.suprep_out_peso,
                    suprep_comments = supervisorReport.suprep_comments,
                    suprep_starep_id = supervisorReport.suprep_starep_id,
                    suprep_audit_id = supervisorReport.suprep_audit_id,
                    suprep_audit_date = supervisorReport.suprep_audit_date
                },
                "Default");
        }

        public async Task Delete(SupervisorReport supervisorReport)
        {
            await _db.SaveData("spSupervisorReportDelete",
               new
               {
                   suprep_id = supervisorReport.suprep_id,
                   suprep_audit_id = supervisorReport.suprep_audit_id,
                   suprep_audit_date = supervisorReport.suprep_audit_date
               },
               "Default");
        }

    }
}
