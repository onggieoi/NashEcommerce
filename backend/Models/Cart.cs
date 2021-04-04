using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
    public class Cart : Autiable
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual IdentityUser User { get; set; }
        public virtual IEnumerable<CartDetail> CartDetails { get; set; }
    }
}