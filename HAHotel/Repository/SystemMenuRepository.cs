using System;
using System.Collections.Generic;
using System.Linq;
using HAHotel.Models;
using HAHotel.Repository.Common;

namespace HAHotel.Repository
{
    public class SystemMenuRepository: ISystemMenuRepository
    {
        private readonly IDatabase _database;

        public SystemMenuRepository(IDatabase database)
        {
            _database = database;
        }

        public List<SystemMenu> GetListRoomType(RoomTypeRequest request)
        {
            var param = new SqlServerParameter();
            if (request.IsActive.HasValue)
                param.Add_Parameter("@_IsActive", request.IsActive);
            param.Add_Parameter("@_PageSize", request.PageSize);
            param.Add_Parameter("@_PageIndex", request.PageIndex);

            var data = _database.ExecuteToTable("SystemMenu_GetList", param, ExecuteTypeEnum.StoredProcedure);
            if (data != null && data.Rows.Count > 0)
            {
                return SqlMapper<SystemMenu>.Map(data);
            }

            return new List<SystemMenu>();
        }

        public SystemMenu GetById(int id)
        {
            var data = _database.ExecuteToTable($"SELECT * FROM SystemMenu WHERE MenuItemId = {id}", null, ExecuteTypeEnum.SqlQuery);
            if (data != null && data.Rows.Count > 0)
            {
                return SqlMapper<SystemMenu>.Map(data).FirstOrDefault();
            }

            return new SystemMenu();
        }

        public bool Save(SystemMenu systemMenu)
        {
            var param = new SqlServerParameter();
            param.Add_Parameter("@_Name", systemMenu.MenuItemName);
            param.Add_Parameter("@_UrlImage", systemMenu.UrlImage);
            param.Add_Parameter("@_IsActive", systemMenu.IsActive);
            param.Add_Parameter("@_Id", systemMenu.MenuItemId);

            var data = _database.ExecuteScalar<int>("SystemMenu_Save", param, ExecuteTypeEnum.StoredProcedure);

            return data == 1;
        }
    }
}