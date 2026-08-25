using Catteria.Desktop.DTOs;
using Catteria.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catteria.Desktop.Services
{
    public class UsuariosApiService
    {
        private readonly HttpClientHelper _http;

        public UsuariosApiService()
        {
            _http = HttpClientHelper.Instance;
        }

        public async Task <List<UsuariosResponseDto>> GetAllAsync()
        {
            try
            {
                var users = await _http.GetAsync<List<UsuariosResponseDto>>("/api/usuarios");
                return users ?? new List<UsuariosResponseDto>();
            }
            catch
            {
                return new List<UsuariosResponseDto>();
            }
        }

        public async Task<List<string>> GetPerfisAsync()
        {
            try
            {
                var perfis = await _http.GetAsync<List<string>>("/api/usuarios/perfis");
                return perfis ?? new List<string>();
            }
            catch
            {
                return new List<string>();
            }
        }

        public async Task<(bool Success, UsuariosResponseDto? Usuario, string ErrorMessage)> CreateAsync(CreateUsuarioDto dto)
        {
            try
            {
                var (success, data, errorMessage) = await _http.PostAsync<UsuariosResponseDto>("/api/usuarios", dto);
                return(success, data, errorMessage);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }

        public async Task <(bool Success, UsuariosResponseDto? Usuario, string ErrorMessage)> UpdateAsync(UpdateUsuarioDto dto, string id)
        {
            try
            {
                var (success, data, errorMessage) = await _http.PutAsync<UsuariosResponseDto>("/api/usuario/{id", dto);
                return (success, data, errorMessage);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool Success, string ErrorMessage)> DeleteAsync(string id)
        {
            try
            {
                await _http.DeleteAsync($"/api/usuarios/{id}");
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
