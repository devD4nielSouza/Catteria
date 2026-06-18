using Catteria.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(int  id);
        Task<CategoryDto> CreateAsync(CreateCategoryDto dto);
        Task<CategoryDto?> UpdateAsync(int id, UpdateCategoryDto dto);
        Task<bool> DeleteAsync(int id);
        Task<int> CountAsync();

    }
}
