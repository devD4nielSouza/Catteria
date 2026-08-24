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
       
       

    }
}
