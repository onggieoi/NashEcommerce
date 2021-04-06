using System.Collections.Generic;
using client.Models;
using ViewModelShare.CartOrder;

namespace client.Services.Cart
{
    public interface ICartService
    {
        CartViewModel GetCartViewModel();
        IEnumerable<CartOrderRespone> AddOrder(CartOrderRespone cartOrder);

        void Clear();
    }
}