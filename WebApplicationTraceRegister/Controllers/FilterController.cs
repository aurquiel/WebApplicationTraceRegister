using ClassLibraryDataAccess.Data;
using ClassLibraryDataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTraceRegister.Models.Output;

namespace WebApplicationTraceRegister.Controllers
{
    [ApiController]
    public class FilterController : ControllerBase
    {
        private readonly IFilterData _filterData;

        public FilterController(IFilterData filterData)
        {
            this._filterData = filterData;
        }

        [HttpPost(), Authorize]
        [Route("api/[controller]/StoreReportFiltered")]
        public async Task<GeneralAnswer> StoreReportFiltered(StoreFilter storeFilter)
        {
            try
            {
                return new GeneralAnswer(true, "Exitoso: Reportes de Tiendas obtenidos.", await _filterData.GetStoreReportFiltered(storeFilter));
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error obteniendo Reportes de Tiendas, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpPost(), Authorize]
        [Route("api/[controller]/SupervisorReportFiltered")]
        public async Task<GeneralAnswer> SupervisorReportFiltered(SupervisorFilter supervisorFilter)
        {
            try
            {
                return new GeneralAnswer(true, "Exitoso: Reportes de Supervisor obtenidos.", await _filterData.GetSupervisorReportFiltered(supervisorFilter));
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error obteniendo Reportes de Supervisor, Excepcion webservice: " + ex.Message, null);
            }
        }
    }
}
