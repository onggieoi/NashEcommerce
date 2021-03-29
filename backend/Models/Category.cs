using System.Collections.Generic;
using System.ComponentModel;

namespace backend.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }
    }
}