using ClassLibraryDataAccess.Data;
using ClassLibraryDataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTraceRegister.Models.Output;

namespace WebApplicationTraceRegister.Controllers
{
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreData _storeData;

        public StoreController(IStoreData storeData)
        {
            this._storeData = storeData;
        }

        [HttpGet(), Authorize]
        [Route("api/[controller]/StoreGetAll")]
        public async Task<GeneralAnswer> StoreGetAll()
        {
            try
            {
                return new GeneralAnswer(true, "Exitoso: Tiendas obtenidas.", await _storeData.GetAll());
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error obteniendo Tiendas, Excepcion webservice: " + ex.Message, null);
            }
        }


        [HttpPost(), Authorize]
        [Route("api/[controller]/StoreInsert")]
        public async Task<GeneralAnswer> StoreInsert(Store store)
        {
            try
            {
                int result = await _storeData.Insert(store);

                if (result == 0)
                {
                    return new GeneralAnswer(false, "Error usuario sin permisos para realizar esta operacion.", null);
                }
                else
                {
                    return new GeneralAnswer(true, "Exitoso: Tienda creada.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error creando Tienda, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpPut(), Authorize]
        [Route("api/[controller]/StoreUpdate")]
        public async Task<GeneralAnswer> StoreUpdate(Store store)
        {
            try
            {
                int result = await _storeData.Update(store);

                if (result == 0)
                {
                    return new GeneralAnswer(false, "Error usuario sin permisos para realizar esta operacion.", null);
                }
                else
                {
                    return new GeneralAnswer(true, "Exitoso: Tienda editada.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error editando Tienda, Excepcion webservice: " + ex.Message, null);
            }
        }

        [HttpDelete(), Authorize]
        [Route("api/[controller]/StoreDelete")]
        public async Task<GeneralAnswer> StoreDelete(Store store)
        {
            try
            {
                int result = await _storeData.Delete(store);

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
                    return new GeneralAnswer(true, "Exitoso: Tienda eliminada.", null);
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error eliminando Tienda, Excepcion webservice: " + ex.Message, null);
            }
        }
    }
}
