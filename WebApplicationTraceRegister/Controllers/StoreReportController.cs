using ClassLibraryDataAccess.Data;
using ClassLibraryDataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTraceRegister.Models.Output;

namespace WebApplicationTraceRegister.Controllers
{
    [ApiController]
    public class StoreReportController : ControllerBase
    {
        private readonly IStoreReportData _storeReportData;

        public StoreReportController(IStoreReportData storeReportData)
        {
            this._storeReportData = storeReportData;
        }

        [HttpGet(), Authorize]
        [Route("api/[controller]/StoreReportExist/{storep_sto_id}/{storep_date}")]
        public async Task<GeneralAnswer> StoreReportExist(int storep_sto_id, DateTime storep_date)
        {
            try
            {
                return new GeneralAnswer(true, "Exitoso: Reportes de Tiendas validacion existencia obtenida.", await _storeReportData.GetExist(storep_sto_id, storep_date));
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error obteniendo validacion existencia Reportes de Tiendas, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpGet(), Authorize]
        [Route("api/[controller]/StoreReportGetByMonth/{storep_sto_id}/{storep_date}")]
        public async Task<GeneralAnswer> StoreReportGetByMonth(int storep_sto_id, DateTime storep_date)
        {
            try
            {
                return new GeneralAnswer(true, "Exitoso: Reportes de Tiendas obtenidos.", await _storeReportData.GetByMonth(storep_sto_id, storep_date));
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error obteniendo Reportes de Tiendas, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpPost(), Authorize]
        [Route("api/[controller]/StoreReportInsert")]
        public async Task<GeneralAnswer> StoreReportInsert(List<StoreReport> storeReports)
        {
            try
            {
                foreach(var item  in storeReports)
                {
                    await _storeReportData.Insert(item);
                }

                return new GeneralAnswer(true, "Exitoso: Reportes de Tienda Creados.", null);

            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error creando Reportes de Tienda, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpPut(), Authorize]
        [Route("api/[controller]/StoreReportUpdate")]
        public async Task<GeneralAnswer> StoreReportUpdate(List<StoreReport> storeReports)
        {
            try
            {
                foreach (var item in storeReports)
                {
                    await _storeReportData.Update(item);
                }

                return new GeneralAnswer(true, "Exitoso: Reportes de Tienda editados.", null);

            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error editando Reportes de Tienda, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpDelete(), Authorize]
        [Route("api/[controller]/StoreReportDelete")]
        public async Task<GeneralAnswer> StoreReportDelete(List<StoreReport> storeReports)
        {
            try
            {
                foreach (var item in storeReports)
                {
                    await _storeReportData.Delete(item);
                }

                return new GeneralAnswer(true, "Exitoso: Reportes de Tienda eliminados.", null);

            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error eliminando Reportes de Tienda, Excepcion webservice: " + ex.Message, null);
            }
        }
    }
}
