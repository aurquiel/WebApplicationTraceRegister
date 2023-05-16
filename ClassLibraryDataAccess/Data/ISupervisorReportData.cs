using ClassLibraryDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDataAccess.Data
{
    public interface ISupervisorReportData
    {
        Task<IEnumerable<SupervisorReport>> GetByMonth(int suprep_sup_id, DateTime suprep_date);
        Task Insert(SupervisorReport supervisorReport);
        Task Update(SupervisorReport supervisorReport);
        Task Delete(SupervisorReport supervisorReport);
    }
}
