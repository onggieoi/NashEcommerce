using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
using ViewModelShare.CartOrder;

namespace backend.Repositories.OrderCartRepo
{
    public interface IOrderCartRepository
    {
        Task<Cart> CreateOrder(IEnumerable<CartOrderRequest> CartOrdersRequest);
        Task<IEnumerable<CartOrderRespone>> GetOrders(int orderId);
    }
}