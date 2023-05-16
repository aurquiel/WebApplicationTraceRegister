using ClassLibraryDataAccess.Data;
using ClassLibraryDataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTraceRegister.Models.Output;

namespace WebApplicationTraceRegister.Controllers
{
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleData _userRoleData;
        private readonly IUserData _userData;

        public RoleController(IRoleData userRoleData, IUserData userData)
        {
            this._userRoleData = userRoleData;
            this._userData = userData;
        }

        [HttpGet(), Authorize]
        [Route("api/[controller]/UserRoleGetAll/{usr_id}")]
        public async Task<GeneralAnswer> UserRoleGetAll(int usr_id)
        {
            try
            {
                if (await _userData.IsUserAdmin(usr_id) == 0)
                {
                    return new GeneralAnswer(false, "Error usuario sin permisos para realizar esta operacion.", null);
                }

                return new GeneralAnswer(true, "Exitoso: Roles obtenidos.", await _userRoleData.GetUserRoleAll());
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error obteniendo Roles, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpGet(), Authorize]
        [Route("api/[controller]/UserModuleGetAll/{usr_id}")]
        public async Task<GeneralAnswer> UserModuleGetAll(int usr_id)
        {
            try
            {
                if (await _userData.IsUserAdmin(usr_id) == 0)
                {
                    return new GeneralAnswer(false, "Error usuario sin permisos para realizar esta operacion.", null);
                }

                return new GeneralAnswer(true, "Exitoso: Modulos obtenidos.", await _userRoleData.GetUserModuleAll());
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error obteniendo Modulos, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpGet(), Authorize]
        [Route("api/[controller]/UserModuleDetailGetAll/{usr_id}")]
        public async Task<GeneralAnswer> UserModuleDetailGetAll(int usr_id)
        {
            try
            {
                if (await _userData.IsUserAdmin(usr_id) == 0)
                {
                    return new GeneralAnswer(false, "Error usuario sin permisos para realizar esta operacion.", null);
                }

                return new GeneralAnswer(true, "Exitoso: Modulos de Detalels obtenidos.", await _userRoleData.GetUserModuleDetailAll());
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error obteniendo Modulos de Detalles, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpGet(), Authorize]
        [Route("api/[controller]/UserPermitGetByRol/{usr_uro_id}")]
        public async Task<GeneralAnswer> UserPermitGetByRol(int usr_uro_id)
        {
            try
            {
                return new GeneralAnswer(true, "Exitoso: Permisos de Rol obtenidos.", await _userRoleData.GetUserPermitByRol(usr_uro_id));
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error obteniendo Permisos de Rol, Excepcion webservice: " + ex.Message, null);
            }
        }


        [HttpPost(), Authorize]
        [Route("api/[controller]/UserPermitInsertBulk")]
        public async Task<GeneralAnswer> UserPermitInsertBulk(UserPermitBulk userPermitBulk)
        {
            try
            {
                int result = await _userRoleData.InsertUserPermit(userPermitBulk);

                if (result == 0)
                {
                    return new GeneralAnswer(false, "Error usuario sin permisos para realizar esta operacion.", null);
                }
                else
                {
                    return new GeneralAnswer(true, "Exitoso: Rol y Permisos de Rol creados.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error creando Rol, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpPut(), Authorize]
        [Route("api/[controller]/UserPermitUpdateBulk")]
        public async Task<GeneralAnswer> UserPermitUpdateBulk(UserPermitBulk userPermitBulk)
        {
            try
            {
                int result = await _userRoleData.UpdateUserPermit(userPermitBulk);

                if (result == 0)
                {
                    return new GeneralAnswer(false, "Error usuario sin permisos para realizar esta operacion.", null);
                }
                else
                {
                    return new GeneralAnswer(true, "Exitoso: Permisos de Rol editados.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error editando Permisos de Rol, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpDelete(), Authorize]
        [Route("api/[controller]/UserPermitDeleteBulk")]
        public async Task<GeneralAnswer> UserPermitDeleteBulk(UserPermitBulk userPermitBulk)
        {
            try
            {
                int result = await _userRoleData.DeleteUserPermit(userPermitBulk);

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
                    return new GeneralAnswer(true, "Exitoso: Rol Eliminado.", null);           
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error eliminando Rol, Excepcion webservice: " + ex.Message, null);
            }
        }
    }
}
