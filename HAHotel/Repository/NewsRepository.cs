using System.Collections.Generic;
using System.Linq;
using HAHotel.Models;
using HAHotel.Repository.Common;

namespace HAHotel.Repository
{
    public class NewsRepository: INewsRepository
    {
        private readonly IDatabase _database;

        public NewsRepository(IDatabase database)
        {
            _database = database;
        }

        public bool Delete(int id)
        {
            _database.ExecuteNonQuery($"DELETE FROM RoomType WHERE RoomTypeId = {id}", null, ExecuteTypeEnum.SqlQuery);

            return true;
        }

        public News GetById(int id)
        {
            var param = new SqlServerParameter();
            param.Add_Parameter("@_Id", id);
            var data = _database.ExecuteToTable($"SELECT * FROM News WHERE NewId = @_Id", param, ExecuteTypeEnum.SqlQuery);
            if (data != null && data.Rows.Count > 0)
            {
                return SqlMapper<News>.Map(data).FirstOrDefault();
            }

            return new News();
        }

        public GridModel<News> GetListNew(RoomTypeRequest request)
        {
            var param = new SqlServerParameter();
            param.Add_Parameter("@_PageSize", request.PageSize);
            param.Add_Parameter("@_PageIndex", request.PageIndex);
            param.Add_Parameter("@_TextSearch", request.Keyword);

            var data = _database.ExecuteToDataset("News_GetList", param, ExecuteTypeEnum.StoredProcedure);
            if (data != null && data.Tables.Count == 2)
            {
                return new GridModel<News>
                {
                    Data = SqlMapper<News>.Map(data.Tables[0]),
                    TotalRecord = (int)data.Tables[1].Rows[0]["TotalRecord"]
                };
            }

            return new GridModel<News>();
        }

        public bool Save(News newModel)
        {
            var param = new SqlServerParameter();
            param.Add_Parameter("@_NewId", newModel.NewId);
            param.Add_Parameter("@_Title", newModel.Title);
            param.Add_Parameter("@_Description", newModel.Description);
            param.Add_Parameter("@_MainContent", newModel.MainContent);
            param.Add_Parameter("@_IsHot", newModel.IsHot);
            param.Add_Parameter("@_OrderItem", newModel.OrderItem);
            param.Add_Parameter("@_TitleSEO", newModel.TitleSeo);
            param.Add_Parameter("@_UrlImage", newModel.UrlImage);
            param.Add_Parameter("@_IsActive", newModel.IsActive);

            var data = _database.ExecuteScalar<int>("News_Save", param, ExecuteTypeEnum.StoredProcedure);

            return data == 1;
        }
    }
}