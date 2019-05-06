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
    }
}