using ClassLibraryDataAccess.Data;
using ClassLibraryDataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTraceRegister.Models.Output;

namespace WebApplicationTraceRegister.Controllers
{
    [ApiController]
    public class SupervisorController : ControllerBase
    {
        private readonly ISupervisorData _supervisorData;

        public SupervisorController(ISupervisorData supervisorData)
        {
            this._supervisorData = supervisorData;
        }

        [HttpGet(), Authorize]
        [Route("api/[controller]/SupervisorGetAll")]
        public async Task<GeneralAnswer> SupervisorGetAll()
        {
            try
            {
                return new GeneralAnswer(true, "Exitoso: Supervisores obtenidos.", await _supervisorData.GetAll());
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error obteniendo Supervisores, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpPost(), Authorize]
        [Route("api/[controller]/SupervisorInsert")]
        public async Task<GeneralAnswer> SupervisorInsert(Supervisor supervisor)
        {
            try
            {
                int result = await _supervisorData.Insert(supervisor);

                if (result == 0)
                {
                    return new GeneralAnswer(false, "Error usuario sin permisos para realizar esta operacion.", null);
                }
                else
                {
                    return new GeneralAnswer(true, "Exitoso: Supervisor creado.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error creando Supervisor, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpPut(), Authorize]
        [Route("api/[controller]/SupervisorUpdate")]
        public async Task<GeneralAnswer> SupervisorUpdate(Supervisor supervisor)
        {
            try
            {
                int result = await _supervisorData.Update(supervisor);

                if (result == 0)
                {
                    return new GeneralAnswer(false, "Error usuario sin permisos para realizar esta operacion.", null);
                }
                else
                {
                    return new GeneralAnswer(true, "Exitoso: Supervisor editado.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error editando Supervisor, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpDelete(), Authorize]
        [Route("api/[controller]/SupervisorDelete")]
        public async Task<GeneralAnswer> SupervisorDelete(Supervisor supervisor)
        {
            try
            {
                int result = await _supervisorData.Delete(supervisor);
                
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
                    return new GeneralAnswer(true, "Exitoso: Supervisor eliminado.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error eliminando Supervisor, Excepcion webservice: " + ex.Message, null);
            }
        }
    }
}
