using ClassLibraryDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDataAccess.Data
{
    public interface IStatusReportData
    {
        Task<IEnumerable<StatusReport>> GetAll();
    }
}
