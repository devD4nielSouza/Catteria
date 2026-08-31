using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Catteria.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public decimal TotalValue { get; set; }

        public int StatusId { get; set; }

        public virtual OrderStatus Status { get; set; } = null!;

        public string IdUser { get; set; } = string.Empty;

        public string? Observations { get; set; }

        public string PaymentMethod { get; set; } = string.Empty;
        public Guid? CupomId { get; set; }
        public string? CupomCodigo { get; set; }
        public decimal Desconto { get; set; }
        public virtual ApplicationUser? User { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
            = new List<OrderItem>();
    }
}
