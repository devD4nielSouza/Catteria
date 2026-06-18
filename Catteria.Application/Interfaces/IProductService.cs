using Catteria.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetFeaturedAsync();
        Task<IEnumerable<ProductDto>> GetByCategoryAsync(int categoryId);
        Task<ProductDto> CreateAsync(CreateProductDto dto)
    }
}
