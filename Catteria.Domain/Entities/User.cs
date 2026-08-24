using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Domain.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    }
}
