using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Domain.Entities
{
    public class CartItem
        {
            public int Id { get; set; }

            public int CartId { get; set; }

            public int ProductId { get; set; }

            public int Quantity { get; set; }

            public decimal UnitPrice { get; set; }

            // Propriedades de navegação
            public virtual Cart? Cart { get; set; }

            public virtual Product? Product { get; set; }
        }
}
