using System.Collections.Generic;
using HAHotel.Models;
using HAHotel.Repository.Common;

namespace HAHotel.Repository
{
    public class OrderRepository: IOrderRepository
    {
        private readonly IDatabase _database;

        public OrderRepository(IDatabase database)
        {
            _database = database;
        }

        public bool Saving(Order order)
        {
            var param = new SqlServerParameter();
            param.Add_Parameter("@_OrderId", order.OrderId);
            param.Add_Parameter("@_Name", order.Name);
            param.Add_Parameter("@_Phone", order.Phone);
            param.Add_Parameter("@_Email", order.Email);
            param.Add_Parameter("@_RoomId", order.RoomId);
            param.Add_Parameter("@_CheckIn", order.CheckIn);
            param.Add_Parameter("@_CheckOut", order.CheckOut);
            param.Add_Parameter("@_Status", order.Status);
            param.Add_Parameter("@_Description", order.Description);

            var data = _database.ExecuteScalar<int>("Order_Save", param, ExecuteTypeEnum.StoredProcedure);

            return data == 1;
        }

        public List<Order> FetchListOrder(RoomTypeRequest request)
        {
            var param = new SqlServerParameter();
            param.Add_Parameter("@_IsActive", request.IsActive);
            param.Add_Parameter("@_PageSize", request.PageSize);
            param.Add_Parameter("@_PageIndex", request.PageIndex);

            var data = _database.ExecuteToTable("Order_GetList", param, ExecuteTypeEnum.StoredProcedure);
            if (data != null && data.Rows.Count > 0)
            {
                return SqlMapper<Order>.Map(data);
            }

            return new List<Order>();
        }
    }
}