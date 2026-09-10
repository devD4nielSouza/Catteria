using Catteria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Application.DTOs
{
    public class OrderStatusDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
