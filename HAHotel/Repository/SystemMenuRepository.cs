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

        public List<SystemSlide> GetListSlides(RoomTypeRequest request)
        {
            var param = new SqlServerParameter();
            if (request.IsActive.HasValue)
                param.Add_Parameter("@_IsActive", request.IsActive);
            param.Add_Parameter("@_PageSize", request.PageSize);
            param.Add_Parameter("@_PageIndex", request.PageIndex);

            var data = _database.ExecuteToTable("SystemSlide_GetList", param, ExecuteTypeEnum.StoredProcedure);
            if (data != null && data.Rows.Count > 0)
            {
                return SqlMapper<SystemSlide>.Map(data);
            }

            return new List<SystemSlide>();
        }

        public SystemSlide GetSlideById(int id)
        {
            var param = new SqlServerParameter();
            param.Add_Parameter("@_SlideId", id);

            var data = _database.ExecuteToTable($"SELECT * FROM SystemSlide WHERE SlideId = @_SlideId", param, ExecuteTypeEnum.SqlQuery);
            if (data != null && data.Rows.Count > 0)
            {
                return SqlMapper<SystemSlide>.Map(data).FirstOrDefault();
            }

            return new SystemSlide();
        }

        public bool SaveSlide(SystemSlide systemSlide)
        {
            var param = new SqlServerParameter();
            param.Add_Parameter("@_SlideId", systemSlide.SlideId);
            param.Add_Parameter("@_SlideName", systemSlide.SlideName);
            param.Add_Parameter("@_LinkUrl", systemSlide.LinkUrl);
            param.Add_Parameter("@_UrlImage", systemSlide.UrlImage);
            param.Add_Parameter("@_IsActive", systemSlide.IsActive);
            param.Add_Parameter("@_OrderItem", systemSlide.OrderItem);

            var data = _database.ExecuteScalar<int>("SystemSlide_Save", param, ExecuteTypeEnum.StoredProcedure);

            return data == 1;
        }
    }
}