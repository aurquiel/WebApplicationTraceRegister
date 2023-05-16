using ClassLibraryDataAccess.Data;
using ClassLibraryDataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTraceRegister.Models.Output;

namespace WebApplicationTraceRegister.Controllers
{
    [ApiController]
    public class StatusReportController : ControllerBase
    {
        private readonly IStatusReportData _statusReportData;

        public StatusReportController(IStatusReportData statusReportData)
        {
            this._statusReportData = statusReportData;
        }

        [HttpGet(), Authorize]
        [Route("api/[controller]/StatusReportGetAll")]
        public async Task<GeneralAnswer> StatusReportGetAll()
        {
            try
            {
                return new GeneralAnswer(true, "Exitoso: Estatus de Reporte obtenidos.", await _statusReportData.GetAll());
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error obteniendo Estatus de Reporte, Excepcion webservice: " + ex.Message, null);
            }
        }
    }
}
