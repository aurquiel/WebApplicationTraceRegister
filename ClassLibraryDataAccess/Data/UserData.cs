using ClassLibraryDataAccess.DbAccess;
using ClassLibraryDataAccess.Models;
using ClassLibraryTools;

namespace ClassLibraryDataAccess.Data
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<User> Get(int usr_id)
        {
            var result = await _db.LoadData<User, dynamic>("spUserGetById", new { usr_id = usr_id }, "Default");
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            IEnumerable<User> users = await _db.LoadData<User, dynamic>("spUserGetAll", new { }, "Default");
            
            foreach(var user in users) //Do not send the SHA256 Passsword
            {
                user.usr_password = null;
            }
            return users;
        }

        public async Task<int> Insert(User user)
        {
            return (await _db.LoadData<int, dynamic>("spUserInsert", 
                new {
                    usr_alias = user.usr_alias,
                    usr_password = user.usr_password,
                    usr_firstname = user.usr_firstname,
                    usr_lastname = user.usr_lastname,
                    usr_manage_id = user.usr_manage_id,
                    usr_email = user.usr_email,
                    usr_urol_id = user.usr_urol_id,
                    usr_audit = user.usr_audit,
                    usr_audit_date = user.usr_audit_date,
                    usr_deleted = user.usr_deleted
                }, 
                "Default")).FirstOrDefault();
        }

        public async Task<int> Update(User user)
        {
            return (await _db.LoadData<int, dynamic>("spUserUpdate",
                new
                {
                    usr_id = user.usr_id,
                    usr_alias = user.usr_alias,
                    usr_password = user.usr_password,
                    usr_firstname = user.usr_firstname,
                    usr_lastname = user.usr_lastname,
                    usr_manage_id = user.usr_manage_id,
                    usr_email = user.usr_email,
                    usr_urol_id = user.usr_urol_id,
                    usr_audit = user.usr_audit,
                    usr_audit_date = user.usr_audit_date
                },
                "Default")).FirstOrDefault();
        }

        public async Task<int> AcccesLoginToken(string usr_alias, string usr_password)
        {
            return (await _db.LoadData<int, dynamic>("spUserLoginToken", new { usr_alias = usr_alias, usr_password = usr_password }, "Default")).FirstOrDefault();
        }

        public async Task<int> IsUserAdmin(int id)
        {
            return (await _db.LoadData<int, dynamic>("spUserIsAdmin", new { usr_id = id }, "Default")).FirstOrDefault();
        }

        public async Task<int> Delete(User user)
        {
            return (await _db.LoadData<int, dynamic>("spUserDelete",
                new
                {
                    usr_id = user.usr_id,
                    usr_audit = user.usr_audit,
                    usr_audit_date = user.usr_audit_date
                },
                "Default")).FirstOrDefault();
        }
    }
}
