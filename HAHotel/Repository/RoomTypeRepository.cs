using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HAHotel.Models;
using HAHotel.Repository.Common;

namespace HAHotel.Repository
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly IDatabase _database;

        public RoomTypeRepository(IDatabase database)
        {
            _database = database;
        }

        public bool Delete(int id)
        {
            _database.ExecuteNonQuery($"DELETE FROM RoomType WHERE RoomTypeId = {id}", null, ExecuteTypeEnum.SqlQuery);

            return true;
        }

        public RoomType GetById(int id)
        {
            var data = _database.ExecuteToTable($"SELECT * FROM RoomType WHERE RoomTypeId = {id}", null, ExecuteTypeEnum.SqlQuery);
            if (data != null && data.Rows.Count > 0)
            {
                return SqlMapper<RoomType>.Map(data).FirstOrDefault();
            }

            return new RoomType();
        }

        public List<RoomType> GetListRoomType(RoomTypeRequest request)
        {
            var param = new SqlServerParameter();
            if (request.IsActive.HasValue)
                param.Add_Parameter("@_IsActive", request.IsActive);
            param.Add_Parameter("@_PageSize", request.PageSize);
            param.Add_Parameter("@_PageIndex", request.PageIndex);

            var data = _database.ExecuteToTable("RoomType_GetList", param, ExecuteTypeEnum.StoredProcedure);
            if (data != null && data.Rows.Count > 0)
            {
                return SqlMapper<RoomType>.Map(data);
            }

            return new List<RoomType>();
        }

        public bool Save(RoomType roomType)
        {
            var param = new SqlServerParameter();
            param.Add_Parameter("@_Name", roomType.TypeName);
            param.Add_Parameter("@_UrlImage", roomType.UrlImage);
            param.Add_Parameter("@_IsActive", roomType.IsActive);
            param.Add_Parameter("@_Id", roomType.RoomTypeId);

            var data = _database.ExecuteScalar<int>("RoomType_Save", param, ExecuteTypeEnum.StoredProcedure);

            return data == 1;
        }
    }
}