using Catteria.Desktop.DTOs;
using Catteria.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catteria.Desktop.Services
{
    public class CategoriesApiService
    {
        private readonly HttpClientHelper _http;

        public CategoriesApiService()
        {
            _http = HttpClientHelper.Instance;
        }

        /// <summary>
        /// Lista todas as categorias via GET /api/categories.
        /// </summary>
        /// <returns></returns>
        public async Task <List<CategoriesResponseDto>> GetAllAsync()
        {
            try
            {
                var categorias = await _http.GetAsync<List<CategoriesResponseDto>>("/api/categories");
                return categorias ?? new List<CategoriesResponseDto>();
            }
            catch
            {
                return new List<CategoriesResponseDto>();
            }
        }
       
        /// <summary>
        /// Cria uma nova categoria via POST /api/categories.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task <(bool Success, CategoriesResponseDto? Categoria, string ErrorMessage)>
            CreateAsync ( CreateCategoriesDto dto) 
        {
            return await _http.PostAsync <CategoriesResponseDto>("/api/categories", dto);
        }

        /// <summary>
        /// Atualiza uma categoria via PUT /api/categories/{id}.
        /// Requer perfil Admin.
        /// </summary>
        public async Task<(bool Success, CategoriesResponseDto? Categoria, string ErrorMessage)>
            UpdateAsync(int id, UpdateCategoriesDto dto)
        {
            return await _http.PutAsync<CategoriesResponseDto>($"/api/categories/{id}", dto);
        }

        /// <summary>
        /// Exclui uma categoria via DELETE /api/categories/{id}.
        /// Requer perfil Admin.
        /// </summary>
        public async Task<(bool Success, string ErrorMessage)> DeleteAsync(int id)
        {
            return await _http.DeleteAsync($"/api/categories/{id}");
        }

    }
}
