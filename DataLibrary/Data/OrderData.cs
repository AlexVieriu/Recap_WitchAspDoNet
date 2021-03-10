using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class OrderData : IOrderData
    {
        private readonly ISql _db;
        private readonly ConnectionStringData _connectionString;

        //ctor
        public OrderData(ISql db, ConnectionStringData connectionString)
        {
            _db = db;
            _connectionString = connectionString;
        }

        // CreateOrder
        public async Task<int> CreateOrder(OrderModel order)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("OrderName", order.OrderName);
            p.Add("OrderDate", order.OrderDate);
            p.Add("FoodId", order.FoodId);
            p.Add("Quantity", order.Quantity);
            p.Add("Total", order.Total);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _db.SaveData("dbo.spOrders_Insert", p, _connectionString.ConnectionStringName);

            return p.Get<int>("Id");

        }

        // DeleteOrder
        public Task<int> DeleteOrder(int OrderId)
        {
            return _db.SaveData("dbo.spOrder_Delete",
                                new { Id = OrderId },
                                _connectionString.ConnectionStringName);
        }

        // GetOrderById
        public async Task<OrderModel> GetOrderById(int orderId)
        {
            var records = await _db.LoadData<OrderModel, dynamic>("dbo.spOrders_GetById",
                                                                  new { Id = orderId },
                                                                  _connectionString.ConnectionStringName);

            return records.FirstOrDefault();
        }

        // UpdateOrder
        public async Task<int> UpdateModel(int orderId, string orderName)
        {
            return await _db.SaveData("dbo.spOrders_Insert",
                                              new { Id = orderId, OrderName = orderName },
                                              _connectionString.ConnectionStringName);
        }
    }
}
