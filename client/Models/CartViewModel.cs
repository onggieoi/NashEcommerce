using System.Collections.Generic;
using ViewModelShare.CartOrder;

namespace client.Models
{
    public class CartViewModel
    {
        public int Total { get; set; }
        public int Count { get; set; }
        public IEnumerable<CartOrderRespone> Orders { get; set; }
    }
}