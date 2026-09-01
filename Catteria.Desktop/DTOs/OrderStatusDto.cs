using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Desktop.DTOs
{
    public class OrderStatusResponseDto
    {
        public int Id { get; set; }
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; set; }
        public string? Status { get; set; } = string.Empty;

        public int StatusId { get; set; }
    }

    public class UpdateOrderStatusDto
    {
        public int Id { get; set; }
        public int StatusId { get; set; }

        public string? Status { get; set; } = string.Empty;
    }
}
