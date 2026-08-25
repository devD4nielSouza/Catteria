using Catteria.Desktop.DTOs;
using Catteria.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catteria.Desktop.Services
{
    public class ProductsApiService
    {

        private readonly HttpClientHelper _http;

        public ProductsApiService()
        {
            _http = HttpClientHelper.Instance;
        }

        /// <summary>
        /// Lista todos os produtos via GET /api/products.
        /// Disponível para qualquer usuário autenticado.
        /// </summary>
        /// <returns>Lista de produtos ou lista vazia em caso de erro</returns>
        public async Task<List<ProductsResponseDto>> GetAllAsync()
        {
            try
            {
                var produtos = await _http.GetAsync<List<ProductsResponseDto>>("/api/products");
                return produtos ?? new List<ProductsResponseDto>();
            }
            catch
            {
                return new List<ProductsResponseDto>();
            }
        }

        /// <summary>
        /// Busca um produto específico por ID via GET /api/products/{id}.
        /// </summary>
        public async Task<ProductsResponseDto?> GetByIdAsync(int id)
        {
            return await _http.GetAsync<ProductsResponseDto>($"/api/products/{id}");
        }

        /// <summary>
        /// Cria um novo produto via POST /api/products.
        /// Requer perfil Admin (verificado pela API).
        /// </summary>
        /// <param name="dto">Dados do produto a ser criado</param>
        /// <returns>Produto criado ou null em caso de erro</returns>
        public async Task<(bool Success, ProductsResponseDto? Product, string ErrorMessage)>
            CreateAsync(CreateProductDto dto)
        {
            return await _http.PostAsync<ProductsResponseDto>("/api/products", dto);
        }

        /// <summary>
        /// Atualiza um produto existente via PUT /api/products/{id}.
        /// Requer perfil Admin (verificado pela API).
        /// </summary>
        public async Task<(bool Success, ProductsResponseDto? Product, string ErrorMessage)>
            UpdateAsync(int id, UpdateProductDto dto)
        {
            return await _http.PutAsync<ProductsResponseDto>($"/api/products/{id}", dto);
        }

        /// <summary>
        /// Exclui um produto via DELETE /api/products/{id}.
        /// Requer perfil Admin (verificado pela API).
        /// </summary>
        public async Task<(bool Success, string ErrorMessage)> DeleteAsync(int id)
        {
            return await _http.DeleteAsync($"/api/products/{id}");
        }
    }
}
