using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class CartDetail
    {
        public int Id { get; set; }

        [Column(TypeName = "TINYINT")]
        public int Quantity { get; set; }
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}