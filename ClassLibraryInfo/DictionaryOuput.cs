using ClassLibraryInfo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryInfo
{
    public static class DictionaryOuput
    {
        public static Dictionary<int, GeneralAnswer> Ouput { get; set; } = new Dictionary<int, GeneralAnswer>
        {
            {100, new GeneralAnswer {Status = true, StatusMessage = "Usuario obtenido con exito."} },
            {100, new GeneralAnswer {Status = true, StatusMessage = "Usuarios obtenidos con exito."} },
            {100, new GeneralAnswer {Status = true, StatusMessage = "Usuario creado con exito."} },
            {101, new GeneralAnswer {Status = true, StatusMessage = "Usuario editado con exito."} },
            {101, new GeneralAnswer {Status = true, StatusMessage = "Usuario eliminado con exito."} },



            {200, new GeneralAnswer {Status = true, StatusMessage = "Operacion Exitosa"} }
        };

        public GeneralAnswer GetAnswerForCode(int code, Object data)
        {

        }

    }
}
