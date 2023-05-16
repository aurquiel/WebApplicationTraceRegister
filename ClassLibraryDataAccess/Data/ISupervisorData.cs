using ClassLibraryDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDataAccess.Data
{
    public interface ISupervisorData
    {
        Task<IEnumerable<Supervisor>> GetAll();
        Task<int> Insert(Supervisor supervisor);
        Task<int> Update(Supervisor supervisor);
        Task<int> Delete(Supervisor supervisor);
    }
}
