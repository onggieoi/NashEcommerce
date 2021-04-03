using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
    public class Rate
    {
        public int Id { get; set; }

        [Range(0, 5)]
        [Column(TypeName = "TINYINT")]
        public int Value { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int UserId { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}