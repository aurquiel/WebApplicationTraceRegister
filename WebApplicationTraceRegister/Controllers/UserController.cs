using ClassLibraryDataAccess.Data;
using ClassLibraryDataAccess.Models;
using ClassLibraryTools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTraceRegister.Models.Output;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationTraceRegister.Controllers
{
    
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserData _userData;

        public UserController(IUserData userData)
        {
            this._userData = userData;
        }

        [HttpGet(), Authorize]
        [Route("api/[controller]/UserGetById/{id}")]
        public async Task<GeneralAnswer> UserGetById(int id)
        {
            try
            { 
                var result = await _userData.Get(id);

                if (result is null)
                {
                    return new GeneralAnswer(false, "Error: Usuario no encontrado.", null);
                }

                return new GeneralAnswer(true, "Exitoso: Usuario encontrado.", result);
            }
            catch(Exception ex) 
            {
                return new GeneralAnswer(false, "Error obteniendo Usuario, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpGet(), Authorize]
        [Route("api/[controller]/UserGetAll/{usr_id}")]
        public async Task<GeneralAnswer> UserGetAll(int usr_id)
        {
            try
            {
                if (await _userData.IsUserAdmin(usr_id) == 0)
                {
                    return new GeneralAnswer(false, "Error usuario sin permisos para realizar esta operacion.", null);
                }

                return new GeneralAnswer(true, "Exitoso: Usuarios obtenidos.", await _userData.GetAll());
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error obteniendo Usuarios, Excepcion webservice: " + ex.Message, null);
            }
        }


        [HttpPost(), Authorize]
        [Route("api/[controller]/UserInsert")]
        public async Task<GeneralAnswer> UserInsert(User user)
        {
            try
            {
                user.usr_password = Hash256.HashOfUserPassword(user.usr_password);
                int result = await _userData.Insert(user);

                if (result == 0)
                {
                    return new GeneralAnswer(false, "Error usuario sin permisos para realizar esta operacion.", null);
                }
                else
                {
                    return new GeneralAnswer(true, "Exitoso: Usuario creado.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error creando Usuario, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpPut(), Authorize]
        [Route("api/[controller]/UserUpdate")]
        public async Task<GeneralAnswer> UserUpdate(User user)
        {
            try
            {
                user.usr_password = Hash256.HashOfUserPassword(user.usr_password);
                int result = await _userData.Update(user);

                if (result == 0)
                {
                    return new GeneralAnswer(false, "Error usuario sin permisos para realizar esta operacion.", null);
                }
                else
                {
                    return new GeneralAnswer(true, "Exitoso: Usuario editado.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error editando Usuario, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpDelete(), Authorize]
        [Route("api/[controller]/UserDelete")]
        public async Task<GeneralAnswer> UserDelete(User user)
        {
            try
            {
                int result = await _userData.Delete(user);

                if (result == 0)
                {
                    return new GeneralAnswer(false, "Error usuario sin permisos para realizar esta operacion.", null);
                }
                else
                {
                    return new GeneralAnswer(true, "Exitoso: Usuario eliminado.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error eliminando Usuario, Excepcion webservice:" + ex.Message, null);
            }
        }
    }
}
