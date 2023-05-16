using ClassLibraryDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDataAccess.Data
{
    public interface IStatusData
    {
        Task<IEnumerable<Status>> GetAll();
        Task<int> Insert(Status status);
        Task<int> Update(Status status);
        Task<int> Delete(Status status);
    }
}
