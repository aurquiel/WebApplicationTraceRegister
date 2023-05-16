using ClassLibraryDataAccess.DbAccess;
using ClassLibraryDataAccess.Models;

namespace ClassLibraryDataAccess.Data
{
    public class RoleData : IRoleData
    {
        private readonly ISqlDataAccess _db;

        public RoleData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<UserRole>> GetUserRoleAll()
        {
            return await _db.LoadData<UserRole, dynamic>("spUserRoleGetAll", new { }, "Default");
        }

        public async Task<IEnumerable<UserModule>> GetUserModuleAll()
        {
            return await _db.LoadData<UserModule, dynamic>("spUserModuleGetAll", new { }, "Default");
        }

        public async Task<IEnumerable<UserModuleDetail>> GetUserModuleDetailAll()
        {
            return await _db.LoadData<UserModuleDetail, dynamic>("spUserModuleDetailGetAll", new { }, "Default");
        }
        public async Task<IEnumerable<UserPermit>> GetUserPermitByRol(int usr_rol_id)
        {
            return await _db.LoadData<UserPermit, dynamic>("spUserPermitGetByRol", new { usr_rol_id = usr_rol_id }, "Default");
        }

        public async Task<int> InsertUserPermit(UserPermitBulk userPermitBulk)
        {
            return (await _db.LoadData<int, dynamic>(
                "spUserPermitInsert", 
                new 
                {
                    uro_name = userPermitBulk.uro_name,
                    upm_umd_1 = userPermitBulk.upm_umd_1,
                    upm_select_1 = userPermitBulk.upm_select_1,
                    upm_insert_1 = userPermitBulk.upm_insert_1,
                    upm_update_1 = userPermitBulk.upm_update_1,
                    upm_delete_1 = userPermitBulk.upm_delete_1,
                    upm_umd_2 = userPermitBulk.upm_umd_2,
                    upm_select_2 = userPermitBulk.upm_select_2,
                    upm_insert_2 = userPermitBulk.upm_insert_2,
                    upm_update_2 = userPermitBulk.upm_update_2,
                    upm_delete_2 = userPermitBulk.upm_delete_2,
                    upm_umd_3 = userPermitBulk.upm_umd_3,
                    upm_select_3 = userPermitBulk.upm_select_3,
                    upm_insert_3 = userPermitBulk.upm_insert_3,
                    upm_update_3 = userPermitBulk.upm_update_3,
                    upm_delete_3 = userPermitBulk.upm_delete_3,
                    upm_umd_4 = userPermitBulk.upm_umd_4,
                    upm_select_4 = userPermitBulk.upm_select_4,
                    upm_insert_4 = userPermitBulk.upm_insert_4,
                    upm_update_4 = userPermitBulk.upm_update_4,
                    upm_delete_4 = userPermitBulk.upm_delete_4, 
                    upm_umd_5 = userPermitBulk.upm_umd_5,
                    upm_select_5 = userPermitBulk.upm_select_5,
                    upm_insert_5 = userPermitBulk.upm_insert_5,
                    upm_update_5 = userPermitBulk.upm_update_5,
                    upm_delete_5 = userPermitBulk.upm_delete_5,
                    upm_umd_6 = userPermitBulk.upm_umd_6,
                    upm_select_6 = userPermitBulk.upm_select_6,
                    upm_insert_6 = userPermitBulk.upm_insert_6,
                    upm_update_6 = userPermitBulk.upm_update_6,
                    upm_delete_6 = userPermitBulk.upm_delete_6, 
                    upm_umd_7 = userPermitBulk.upm_umd_7, 
                    upm_select_7 = userPermitBulk.upm_select_7,
                    upm_insert_7 = userPermitBulk.upm_insert_7,
                    upm_update_7 = userPermitBulk.upm_update_7, 
                    upm_delete_7 = userPermitBulk.upm_delete_7,
                    upm_umd_8 = userPermitBulk.upm_umd_8,
                    upm_select_8 = userPermitBulk.upm_select_8, 
                    upm_insert_8 = userPermitBulk.upm_insert_8,
                    upm_update_8 = userPermitBulk.upm_update_8,
                    upm_delete_8 = userPermitBulk.upm_delete_8, 
                    upm_umd_9 = userPermitBulk.upm_umd_9,
                    upm_select_9 = userPermitBulk.upm_select_9,
                    upm_insert_9 = userPermitBulk.upm_insert_9, 
                    upm_update_9 = userPermitBulk.upm_update_9,
                    upm_delete_9 = userPermitBulk.upm_delete_9,
                    upm_audit_id = userPermitBulk.upm_audit_id,
                    upm_audit_date = userPermitBulk.upm_audit_date
                }, 
                "Default")).FirstOrDefault();
        }

        public async Task<int> UpdateUserPermit(UserPermitBulk userPermitBulk)
        {
            return (await _db.LoadData<int, dynamic>(
                "spUserPermitUpdate",
                new
                {
                    upm_id_1 = userPermitBulk.upm_id_1,
                    upm_select_1 = userPermitBulk.upm_select_1,
                    upm_insert_1 = userPermitBulk.upm_insert_1,
                    upm_update_1 = userPermitBulk.upm_update_1,
                    upm_delete_1 = userPermitBulk.upm_delete_1,
                    upm_id_2 = userPermitBulk.upm_id_2,
                    upm_select_2 = userPermitBulk.upm_select_2,
                    upm_insert_2 = userPermitBulk.upm_insert_2,
                    upm_update_2 = userPermitBulk.upm_update_2,
                    upm_delete_2 = userPermitBulk.upm_delete_2,
                    upm_id_3 = userPermitBulk.upm_id_3,
                    upm_select_3 = userPermitBulk.upm_select_3,
                    upm_insert_3 = userPermitBulk.upm_insert_3,
                    upm_update_3 = userPermitBulk.upm_update_3,
                    upm_delete_3 = userPermitBulk.upm_delete_3,
                    upm_id_4 = userPermitBulk.upm_id_4,
                    upm_select_4 = userPermitBulk.upm_select_4,
                    upm_insert_4 = userPermitBulk.upm_insert_4,
                    upm_update_4 = userPermitBulk.upm_update_4,
                    upm_delete_4 = userPermitBulk.upm_delete_4,
                    upm_id_5 = userPermitBulk.upm_id_5,
                    upm_select_5 = userPermitBulk.upm_select_5,
                    upm_insert_5 = userPermitBulk.upm_insert_5,
                    upm_update_5 = userPermitBulk.upm_update_5,
                    upm_delete_5 = userPermitBulk.upm_delete_5,
                    upm_id_6 = userPermitBulk.upm_id_6,
                    upm_select_6 = userPermitBulk.upm_select_6,
                    upm_insert_6 = userPermitBulk.upm_insert_6,
                    upm_update_6 = userPermitBulk.upm_update_6,
                    upm_delete_6 = userPermitBulk.upm_delete_6,
                    upm_id_7 = userPermitBulk.upm_id_7,
                    upm_select_7 = userPermitBulk.upm_select_7,
                    upm_insert_7 = userPermitBulk.upm_insert_7,
                    upm_update_7 = userPermitBulk.upm_update_7,
                    upm_delete_7 = userPermitBulk.upm_delete_7,
                    upm_id_8 = userPermitBulk.upm_id_8,
                    upm_select_8 = userPermitBulk.upm_select_8,
                    upm_insert_8 = userPermitBulk.upm_insert_8,
                    upm_update_8 = userPermitBulk.upm_update_8,
                    upm_delete_8 = userPermitBulk.upm_delete_8,
                    upm_id_9 = userPermitBulk.upm_id_9,
                    upm_select_9 = userPermitBulk.upm_select_9,
                    upm_insert_9 = userPermitBulk.upm_insert_9,
                    upm_update_9 = userPermitBulk.upm_update_9,
                    upm_delete_9 = userPermitBulk.upm_delete_9,
                    upm_audit_id = userPermitBulk.upm_audit_id,
                    upm_audit_date = userPermitBulk.upm_audit_date
                },
                "Default")).FirstOrDefault();
        }

        public async Task<int> DeleteUserPermit(UserPermitBulk userPermitBulk)
        {
            return (await _db.LoadData<int, dynamic>(
                 "spUserPermitDelete",
                 new
                 {
                     uro_id = userPermitBulk.uro_id,
                     upm_id_1 = userPermitBulk.upm_id_1,
                     upm_id_2 = userPermitBulk.upm_id_2,
                     upm_id_3 = userPermitBulk.upm_id_3,
                     upm_id_4 = userPermitBulk.upm_id_4,
                     upm_id_5 = userPermitBulk.upm_id_5,
                     upm_id_6 = userPermitBulk.upm_id_6,
                     upm_id_7 = userPermitBulk.upm_id_7,
                     upm_id_8 = userPermitBulk.upm_id_8,
                     upm_id_9 = userPermitBulk.upm_id_9,
                     upm_audit_id = userPermitBulk.upm_audit_id,
                     upm_audit_date = userPermitBulk.upm_audit_date
                 },
                 "Default")).FirstOrDefault();
        }
    }
}
