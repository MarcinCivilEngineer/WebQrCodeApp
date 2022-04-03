using System.Collections.Generic;
using System.Threading.Tasks;
using WebBetardQRCodeLib.Models;

namespace WebBetardQRCodeLib.DataAccess
{
    public interface IOrderData
    {
        Task CreateOrderAsync(OrderModel order);
        Task<List<OrderModel>> GetAllOrdersAsync();
        Task<List<DrawingModel>> GetOrderDrawingsAsync(string id);
        Task<OrderModel> GetOrdersAsync(string id);
        Task RemoveOrder(string orderId);
        Task UpdateOrderAsync(OrderModel order);
    }
}