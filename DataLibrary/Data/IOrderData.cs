using DataLibrary.Models;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public interface IOrderData
    {
        Task<int> CreateOrder(OrderModel order);
        Task<int> DeleteOrder(int OrderId);
        Task<OrderModel> GetOrderById(int orderId);
        Task<int> UpdateModel(int orderId, string orderName);
    }
}