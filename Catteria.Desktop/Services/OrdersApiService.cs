using Catteria.Desktop.DTOs;
using Catteria.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catteria.Desktop.Services
{
    public class OrdersApiService
    {

        private readonly HttpClientHelper _http;

        public OrdersApiService()
        {
            _http = HttpClientHelper.Instance;
        }

        public async Task<List<OrdersResponseDto>> GetAllAsync()
        {
            try
            {
                var produtos = await _http.GetAsync<List<OrdersResponseDto>>("/api/orders/All");
                return produtos ?? new List<OrdersResponseDto>();
            }
            catch
            {
                return new List<OrdersResponseDto>();
            }
        }

        public async Task<OrdersResponseDto> GetByIdAsync(int id)
        {
            return await _http.GetAsync<OrdersResponseDto>($"/api/orders/{id}");
        }

        public async Task<(bool Success, OrdersResponseDto? Order, string ErrorMessage)>
       CreateAsync(CreateOrderDto dto)
        {
            return await _http.PostAsync<OrdersResponseDto>("/api/orders/CreateOrder", dto);
        }

        public async Task<(bool Success, OrdersResponseDto? Order, string ErrorMessage)>
        UpdateAsync(int id, UpdateOrderDto dto)
        {
            return await _http.PutAsync<OrdersResponseDto>($"/api/orders/{id}", dto);
        }

        public async Task<(bool Success, string ErrorMessage)> DeleteAsync(int id)
        {
            return await _http.DeleteAsync($"/api/orders/{id}");
        }

        public async Task<List<OrderStatusResponseDto>> GetStatusesAsync()
        {
            try
            {
                var list = await _http.GetAsync<List<OrderStatusResponseDto>>("/api/orders/statuses");
                return list ?? new List<OrderStatusResponseDto>();
            }
            catch
            {
                return new List<OrderStatusResponseDto>();
            }
        }
    }
}
