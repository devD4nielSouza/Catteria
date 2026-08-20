using System;

namespace Catteria.Domain.Entities
{
    public class Favorite
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }

        // Inicializa para evitar inserir DateTime.MinValue e garantir CreatedAt válido
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Nav
        public virtual User? User { get; set; }
        public virtual Product? Product { get; set; }
    }
}
