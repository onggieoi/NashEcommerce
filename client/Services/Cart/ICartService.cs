using System.Collections.Generic;
using System.Threading.Tasks;
using client.Models;
using ViewModelShare.CartOrder;

namespace client.Services.Cart
{
    public interface ICartService
    {
        Task<CartViewModel> GetCartViewModel();
        Task<IEnumerable<CartOrderRespone>> AddOrder(CartOrderRespone cartOrder);
        Task Remove(int productId);
        Task Clear();
    }
}