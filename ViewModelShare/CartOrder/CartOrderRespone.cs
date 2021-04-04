using System.Collections.Generic;
using ViewModelShare.Product;

namespace CartOrder
{
    public class CartOrderRespone
    {
        public int Quantity { get; set; }
        public ProductRespone Product { get; set; }
    }
}