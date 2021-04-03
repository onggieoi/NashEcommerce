using System;
using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
    public class Cart : Autiable
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public int UserId { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}