using ClassLibraryDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDataAccess.Data
{
    public interface IFilterData
    {
        Task<IEnumerable<StoreReport>> GetStoreReportFiltered(StoreFilter storeFilter);
        Task<IEnumerable<SupervisorReport>> GetSupervisorReportFiltered(SupervisorFilter supervisorFilter);
    }
}
