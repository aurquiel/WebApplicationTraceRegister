using ClassLibraryDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDataAccess.Data
{
    public interface IUserData
    {
        Task<User> Get(int usr_id);
        Task<IEnumerable<User>> GetAll();
        Task<int> Insert(User user);
        Task<int> Update(User user);
        Task<int> Delete(User user);
        Task<int> AcccesLoginToken(string usr_alias, string usr_password);
        Task<int> IsUserAdmin(int usr_id);
    }
}
