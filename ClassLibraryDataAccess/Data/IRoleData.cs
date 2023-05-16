using ClassLibraryDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDataAccess.Data
{
    public interface IRoleData
    {
        Task<IEnumerable<UserRole>> GetUserRoleAll();
        Task<IEnumerable<UserModule>> GetUserModuleAll();
        Task<IEnumerable<UserModuleDetail>> GetUserModuleDetailAll();
        Task<IEnumerable<UserPermit>> GetUserPermitByRol(int usr_rol_id);
        Task<int> InsertUserPermit(UserPermitBulk userPermitBulk);
        Task<int> UpdateUserPermit(UserPermitBulk userPermitBulk);
        Task<int> DeleteUserPermit(UserPermitBulk userPermitBulk);
    }
}
