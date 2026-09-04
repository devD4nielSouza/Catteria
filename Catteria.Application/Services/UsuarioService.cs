using Catteria.Application.DTOs;
using Catteria.Application.Interfaces;
using Catteria.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Catteria.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsuarioService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
        {
            var users = _userManager.Users.ToList();
            var result = new List<UsuarioDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                result.Add(new UsuarioDto
                {
                    Id = user.Id,
                    Nome = user.UserName ?? string.Empty, // UserName é usado como Nome no projeto atual
                    Email = user.Email ?? string.Empty,
                    Perfil = roles.FirstOrDefault() ?? "Usuario",
                    Address = user.Address ?? string.Empty,
                    Telephone = user.PhoneNumber ?? string.Empty,
                });
            }

            return result;
        }

        public async Task<UsuarioDto?> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return null;

            var roles = await _userManager.GetRolesAsync(user);

            return new UsuarioDto
            {
                Id = user.Id,
                Nome = user.UserName ?? string.Empty,
                Email = user.Email ?? string.Empty,
                Perfil = roles.FirstOrDefault() ?? "Usuario",
                Address = user.Address ?? string.Empty,
                Telephone = user.PhoneNumber ?? string.Empty
            };
        }

        public async Task<(bool Success, UsuarioDto? Usuario, string ErrorMessage)> CreateAsync(CreateUsuarioDto dto)
        {
            if (dto.Senha != dto.ConfirmarSenha)
                return (false, null, "As senhas não coincidem.");

            // Verifica se e-mail já existe
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
                return (false, null, "E-mail já cadastrado.");

            var user = new ApplicationUser
            {
                UserName = dto.Nome,
                Email = dto.Email,
                Address = dto.Address,
                PhoneNumber = dto.Telephone
            };

            var result = await _userManager.CreateAsync(user, dto.Senha);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return (false, null, $"Erro ao criar usuário: {errors}");
            }

            // Adicionar ao Perfil
            if (!string.IsNullOrWhiteSpace(dto.Perfil))
            {
                if (await _roleManager.RoleExistsAsync(dto.Perfil))
                {
                    await _userManager.AddToRoleAsync(user, dto.Perfil);
                }
            }
            else
            {
                // Perfil padrão
                await _userManager.AddToRoleAsync(user, "Usuario");
            }

            var createdUser = await GetByIdAsync(user.Id);
            return (true, createdUser, string.Empty);
        }

        public async Task<UsuarioDto?> UpdateAsync(string id, UpdateUsuarioDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Senha) && dto.Senha != dto.ConfirmarSenha)
                return null;

            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return null;

            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null && existingUser.Id != user.Id) return null;

            user.UserName = dto.Nome;
            user.Email = dto.Email;
            user.PhoneNumber = dto.Telephone;
            user.Address = dto.Address;

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded) return null;

            if (!string.IsNullOrWhiteSpace(dto.Senha))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passResult = await _userManager.ResetPasswordAsync(user, token, dto.Senha);
                if (!passResult.Succeeded) return null;
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            if (!string.IsNullOrWhiteSpace(dto.Perfil) && !currentRoles.Contains(dto.Perfil))
            {
                if (await _roleManager.RoleExistsAsync(dto.Perfil))
                {
                    await _userManager.RemoveFromRolesAsync(user, currentRoles);
                    await _userManager.AddToRoleAsync(user, dto.Perfil);
                }
            }

            return await GetByIdAsync(user.Id);
        }

        public async Task<(bool Success, string ErrorMessage)> DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return (false, "Usuário não encontrado.");

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return (false, $"Erro ao excluir usuário: {errors}");
            }

            return (true, string.Empty);
        }

        public async Task<IEnumerable<string>> GetPerfisAsync()
        {
            var roles = _roleManager.Roles.Select(r => r.Name).ToList();
            return await Task.FromResult(roles!);
        }
    }
}
