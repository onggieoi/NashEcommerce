using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Product : Autiable
    {
        public int ProductId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Image { get; set; }
        public string Description { get; set; }

        [Range(0, 5)]
        [Column(TypeName = "TINYINT")]
        public int Rated { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}