using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catteria.Desktop.DTOs
{
    public class CategoriesDto
    {
        public string Name { get; set; } = string.Empty;
        public int Id { get; set; }
        public int ProductCount { get; set; }

    }
        public class CreateCategoriesDto
        {
            public string Name { get; set; } = string.Empty;
        }

        public class UpdateCategoriesDto
        {
            public string Name { get; set; } = string.Empty;
        }
}
