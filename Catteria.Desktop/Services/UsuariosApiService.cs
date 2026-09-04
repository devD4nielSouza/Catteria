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

        /// <summary> ///
        /// Busca todos os usuários cadastrados através da API.
        /// /// </summary>
        public async Task <List<UsuariosResponseDto>> GetAllAsync()
        {
            try
            {
                // REQUISIÇÃO PARA API: //
                // Faz uma requisição GET para a rota /api/usuarios. 
                // 
                // A API deve retornar uma lista de usuários.
                var users = await _http.GetAsync<List<UsuariosResponseDto>>("/api/usuario");
                // Retorna os usuários recebidos. 
                //
                // Caso a API retorne null, retorna uma lista vazia 
                // para evitar problemas no restante da aplicação.
                return users ?? new List<UsuariosResponseDto>();
            }
            catch
            {
                // Caso aconteça algum erro na requisição,
                // retorna uma lista vazia. 
                // 
                // OBS:
                // Isso impede que o programa quebre, mas também // pode esconder o motivo real do erro.
                return new List<UsuariosResponseDto>();
            }
        }

        public async Task<List<string>> GetPerfisAsync()
        {
            try
            {
                var perfis = await _http.GetAsync<List<string>>("/api/usuario/perfis");
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
                var (success, data, errorMessage) = await _http.PostAsync<UsuariosResponseDto>("/api/usuario", dto);
                return(success, data, errorMessage);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }

        public async Task <(bool Success, UsuariosResponseDto? Usuario, string ErrorMessage)> UpdateAsync(string id, UpdateUsuarioDto dto)
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
                await _http.DeleteAsync($"/api/usuario/{id}");
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
