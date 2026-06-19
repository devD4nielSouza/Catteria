using Catteria.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Application.Interfaces
{
    public interface ICategoryService
    {
        //Mostrar todos
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        //Puxar pelo id
        Task<CategoryDto?> GetByIdAsync(int  id);
        //Criar nova categoria
        Task<CategoryDto> CreateAsync(CreateCategoryDto dto);
        //atualizar categoria
        Task<CategoryDto?> UpdateAsync(int id, UpdateCategoryDto dto);
        //deletar categoria
        Task<bool> DeleteAsync(int id);
        //mostrar quantidade de categorias totais
        Task<int> CountAsync();

    }
}
