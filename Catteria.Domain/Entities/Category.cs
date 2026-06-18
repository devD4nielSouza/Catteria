using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Domain.Entities
{
    /// <summary>
    /// Representa uma categoria de produtos.
    /// Uma categoria agrupa produtos do mesmo tipo.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Identificador único da categoria (chave primária).
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da categoria. Exemplo: "Refeição", "Bebida Fria", "Bebida Quente".
        /// </summary>
        public string Name { get; set; } = string.Empty;

        // =====================================================================
        // NAVIGATION PROPERTY - Coleção de Games
        // =====================================================================
        // 📌 CONCEITO:
        // Uma Category pode ter VÁRIOS Games associados (relação 1:N).
        // O ICollection<Game> representa essa coleção de games.
        // O Entity Framework usa essa propriedade para fazer JOINs automáticos.
        // =====================================================================

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
