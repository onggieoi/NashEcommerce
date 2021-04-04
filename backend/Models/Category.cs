using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Category : Autiable
    {
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        public string Description { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}