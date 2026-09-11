
using Catteria.Desktop.DTOs;
using Catteria.Desktop.Helpers;
using System;

using System.Collections.Generic;
using System.Text;

namespace Catteria.Desktop.Services
{
    public class CupomApiService
    {
        private readonly HttpClientHelper _http;

        public CupomApiService()
        {
            _http = HttpClientHelper.Instance;
        }

        /// <summary>
        /// Lista todos os cupons via GET /api/cupons.
        /// Requer perfil Admin (verificado pela API).
        /// </summary>
        /// <returns>Lista de cupons ou lista vazia em caso de erro</returns>
        public async Task<List<CuponsResponseDto>> GetAllAsync()
        {
            try
            {
                var cupons = await _http.GetAsync<List<CuponsResponseDto>>("/api/cupons");
                return cupons ?? new List<CuponsResponseDto>();
            }
            catch
            {
                return new List<CuponsResponseDto>();
            }
        }

        /// <summary>
        /// Cria um novo cupom via POST /api/cupons.
        /// Requer perfil Admin (verificado pela API).
        /// </summary>
        public async Task<(bool Success, CuponsResponseDto? Cupom, string ErrorMessage)>
            CreateAsync(CreateCupomDto request)
        {
            return await _http.PostAsync<CuponsResponseDto>("/api/cupons", request);
        }

        /// <summary>
        /// Atualiza o percentual de desconto de um cupom via PUT /api/cupons/{id}.
        /// Requer perfil Admin (verificado pela API).
        /// </summary>
        public async Task<(bool Success, CuponsResponseDto? Cupom, string ErrorMessage)>
            UpdateAsync(Guid id, UpdateCupomDto request)
        {
            return await _http.PutAsync<CuponsResponseDto>($"/api/cupons/{id}", request);
        }

        /// <summary>
        /// Desabilita um cupom via PATCH /api/cupons/{id}/status?ativo=false.
        /// Não deleta — apenas marca Ativo = false. Requer perfil Admin.
        /// </summary>
        public async Task<(bool Success, string ErrorMessage)> DesabilitarAsync(Guid id)
        {
            return await _http.PatchAsync($"/api/cupons/{id}/status?ativo=false");
        }

        /// <summary>
        /// Reabilita um cupom via PATCH /api/cupons/{id}/status?ativo=true.
        ///
        /// </summary>
        public async Task<(bool Success, string ErrorMessage)> HabilitarAsync(Guid id)
        {
            return await _http.PatchAsync($"/api/cupons/{id}/status?ativo=true");
        }
    }

}
