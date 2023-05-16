using ClassLibraryDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDataAccess.Data
{
    public interface IStoreData
    {
        Task<IEnumerable<Store>> GetAll();
        Task<int> Insert(Store store);
        Task<int> Update(Store store);
        Task<int> Delete(Store store);
    }
}
