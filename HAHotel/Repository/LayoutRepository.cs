using System.Collections.Generic;
using HAHotel.Models;
using HAHotel.Repository.Common;

namespace HAHotel.Repository
{
    public class LayoutRepository: ILayoutRepository
    {
        private readonly IDatabase _database;

        public LayoutRepository(IDatabase database)
        {
            _database = database;
        }

        public IEnumerable<SystemMenu> FetchMenuItems()
        {
            var result = _database.ExecuteToTable("SELECT * FROM SystemMenu WHERE IsActive =1", null, ExecuteTypeEnum.SqlQuery);
            if (result != null && result.Rows.Count > 0)
            {
                return SqlMapper<SystemMenu>.Map(result);
            }

            return null;
        }

        public IEnumerable<RoomType> FetchRoomTypes()
        {
            var result = _database.ExecuteToTable("SELECT * FROM RoomType WHERE IsActive = 1", null, ExecuteTypeEnum.SqlQuery);
            if (result != null && result.Rows.Count > 0)
            {
                return SqlMapper<RoomType>.Map(result);
            }

            return null;
        }

        public IEnumerable<SystemSlide> FetchListSlides()
        {
            var result = _database.ExecuteToTable("SELECT * FROM SystemSlide WHERE IsActive = 1", null, ExecuteTypeEnum.SqlQuery);
            if (result != null && result.Rows.Count > 0)
            {
                return SqlMapper<SystemSlide>.Map(result);
            }

            return null;
        }

        public IEnumerable<News> GetTopNews(int top)
        {
            var sqlParam = new SqlServerParameter();
            sqlParam.Add_Parameter("@top", top);
            var result = _database.ExecuteToTable("SELECT TOP (@top) * FROM News WHERE IsHot=1 AND IsActive =1", sqlParam, ExecuteTypeEnum.SqlQuery);
            if (result != null && result.Rows.Count > 0)
            {
                return SqlMapper<News>.Map(result);
            }

            return null;
        }

        public IEnumerable<Reviews> FetchTopCustomer(int top)
        {
            var sqlParam = new SqlServerParameter();
            sqlParam.Add_Parameter("@top", top);
            var result = _database.ExecuteToTable("SELECT TOP (@top) * FROM Reviews WHERE IsActive =1", sqlParam, ExecuteTypeEnum.SqlQuery);

            if (result != null && result.Rows.Count > 0)
            {
                return SqlMapper<Reviews>.Map(result);
            }

            return null;
        }

        public Footer LoadFooterDefaul()
        {
            var result = _database.ExecuteToTable("SELECT TOP 1 * FROM Footer", null, ExecuteTypeEnum.SqlQuery);

            if (result != null && result.Rows.Count > 0)
            {
                return SqlMapper<Footer>.Map(result.Rows[0]);
            }

            return null;
        }

        public Introduction LoadDefaultIntroduction()
        {
            var result = _database.ExecuteToTable("SELECT TOP 1 * FROM Introduction", null, ExecuteTypeEnum.SqlQuery);

            if (result != null && result.Rows.Count > 0)
            {
                return SqlMapper<Introduction>.Map(result.Rows[0]);
            }

            return null;
        }

        public bool SaveIntroduction(Introduction introduction)
        {
            var param = new SqlServerParameter();
            param.Add_Parameter("@_MainContent", introduction.MainContent);

            var data = _database.ExecuteScalar<int>("Introduction_Save", param, ExecuteTypeEnum.StoredProcedure);

            return data == 1;
        }

        public bool SaveFooter(Footer footer)
        {
            var param = new SqlServerParameter();
            param.Add_Parameter("@_TitleFooter", footer.TitleFooter);
            param.Add_Parameter("@_Address", footer.Address);
            param.Add_Parameter("@_Phone", footer.Phone);
            param.Add_Parameter("@_Email", footer.Email);
            param.Add_Parameter("@_Facebook", footer.Facebook);
            param.Add_Parameter("@_Twifter", footer.Twifter);
            param.Add_Parameter("@_Youtube", footer.Youtube);
            param.Add_Parameter("@_Google", footer.Google);
            param.Add_Parameter("@_FooterId", footer.FooterId);

            var data = _database.ExecuteScalar<int>("Footer_Save", param, ExecuteTypeEnum.StoredProcedure);

            return data == 1;
        }
    }
}