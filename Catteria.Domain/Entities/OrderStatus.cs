using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Domain.Entities
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
