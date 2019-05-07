using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
    }
}