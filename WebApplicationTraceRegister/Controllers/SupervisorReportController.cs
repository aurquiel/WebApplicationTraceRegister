using ClassLibraryDataAccess.Data;
using ClassLibraryDataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTraceRegister.Models.Output;

namespace WebApplicationTraceRegister.Controllers
{
    [ApiController]
    public class SupervisorReportController : ControllerBase
    {
        private readonly ISupervisorReportData _supervisorReportData;

        public SupervisorReportController(ISupervisorReportData supervisorReportData)
        {
            this._supervisorReportData = supervisorReportData;
        }

        [HttpGet(), Authorize]
        [Route("api/[controller]/SupervisorReportGetByMonth/{suprep_sup_id}/{suprep_date}")]
        public async Task<GeneralAnswer> SupervisorReportGetByMonth(int suprep_sup_id, DateTime suprep_date)
        {
            try
            {
                return new GeneralAnswer(true, "Exitoso: Reportes de Supervisor obtenidos.", await _supervisorReportData.GetByMonth(suprep_sup_id, suprep_date));
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error obteniendo Reportes de Supervisor, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpPost(), Authorize]
        [Route("api/[controller]/SupervisorReportInsert")]
        public async Task<GeneralAnswer> SupervisorReportInsert(List<SupervisorReport> supervisorReports)
        {
            try
            {
                foreach(var item  in supervisorReports) 
                {
                    await _supervisorReportData.Insert(item);
                }

                return new GeneralAnswer(true, "Exitoso: Reportes de Supervisor Creados.", null);

            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error creando Reportes de Supervisor, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpPut(), Authorize]
        [Route("api/[controller]/SupervisorReportUpdate")]
        public async Task<GeneralAnswer> SupervisorReportUpdate(List<SupervisorReport> supervisorReports)
        {
            try
            {
                foreach (var item in supervisorReports)
                {
                    await _supervisorReportData.Update(item);   
                }

                return new GeneralAnswer(true, "Exitoso: Reportes de Supervisor editados.", null);

            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error editando Reportes de Supervisor, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpDelete(), Authorize]
        [Route("api/[controller]/SupervisorReportDelete")]
        public async Task<GeneralAnswer> SupervisorReportDelete(List<SupervisorReport> supervisorReports)
        {
            try
            {
                foreach (var item in supervisorReports)
                {
                    await _supervisorReportData.Delete(item);   
                }

                return new GeneralAnswer(true, "Exitoso: Reportes de Supervisor eliminados.", null);

            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error eliminando Reportes de Supervisor, Excepcion webservice: " + ex.Message, null);
            }
        }
    }
}
