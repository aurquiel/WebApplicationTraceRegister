using ClassLibraryDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDataAccess.Data
{
    public interface IStoreReportData
    {
        Task<IEnumerable<StoreReport>> GetByMonth(int storep_sto_id, DateTime storep_date);
        Task<StoreReportExist> GetExist(int storep_sto_id, DateTime storep_date);
        Task Insert(StoreReport storeReport);
        Task Update(StoreReport storeReport);
        Task Delete(StoreReport storeReport);   
    }
}
