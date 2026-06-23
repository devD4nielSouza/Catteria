using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; }=string.Empty;
        public string Address { get; set; } = string.Empty;
        
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
