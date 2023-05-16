using ClassLibraryDataAccess.Data;
using ClassLibraryDataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTraceRegister.Models.Output;

namespace WebApplicationTraceRegister.Controllers
{
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusData _statusData;

        public StatusController(IStatusData statusData)
        {
            this._statusData = statusData;
        }

        [HttpGet(), Authorize]
        [Route("api/[controller]/StatusGetAll")]
        public async Task<GeneralAnswer> StatusGetAll()
        {
            try
            {
                return new GeneralAnswer(true, "Exitoso: Estatus obtenidos.", await _statusData.GetAll());
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error obteniendo Estatus, Excepcion webservice: " + ex.Message, null);
            }
        }


        [HttpPost(), Authorize]
        [Route("api/[controller]/StatusInsert")]
        public async Task<GeneralAnswer> StatusInsert(Status status)
        {
            try
            {
                int result = await _statusData.Insert(status);

                if (result == 0)
                {
                    return new GeneralAnswer(false, "Error usuario sin permisos para realizar esta operacion.", null);
                }
                else
                {
                    return new GeneralAnswer(true, "Exitoso: Estatus creado.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error creando Estatus, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpPut(), Authorize]
        [Route("api/[controller]/StatusUpdate")]
        public async Task<GeneralAnswer> StatusUpdate(Status status)
        {
            try
            {
                int result = await _statusData.Update(status);
                
                if (result == 0)
                {
                    return new GeneralAnswer(false, "Error usuario sin permisos para realizar esta operacion.", null);
                }
                else
                {
                    return new GeneralAnswer(true, "Exitoso: Estatus editado.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error editando Estatus, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpDelete(), Authorize]
        [Route("api/[controller]/StatusDelete")]
        public async Task<GeneralAnswer> StatusDelete(Status status)
        {
            try
            {
                int result = await _statusData.Delete(status);

                if (result == 0)
                {
                    return new GeneralAnswer(false, "Error usuario sin permisos para realizar esta operacion.", null);
                    
                }
                else if (result == 1)
                {
                    return new GeneralAnswer(false, "Error campo de relacion en uso, no es posible eliminar.", null);
                }
                else
                {
                    return new GeneralAnswer(true, "Exitoso: Estatus eliminado.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error eliminando Estatus, Excepcion webservice: " + ex.Message, null);
            }
        }
    }
}
