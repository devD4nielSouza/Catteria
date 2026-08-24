using Catteria.Domain.Entities;
using Catteria.Domain.Interfaces;
using Catteria.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Infraestructure.Repositories
{
    // Infrastructure/Repositories/CupomRepository.cs
    public class CupomRepository : ICupomRepository
    {
        private readonly CatteriaDbContext _context;

        public CupomRepository(CatteriaDbContext context)
        {
            _context = context;
        }

        public async Task<Cupom?> ObterPorCodigoAsync(string codigo)
        {
            var codigoNormalizado = codigo.Trim().ToUpperInvariant();
            return await _context.Cupons
                .FirstOrDefaultAsync(c => c.Codigo == codigoNormalizado);
        }

        public async Task<Cupom?> ObterPorIdAsync(Guid id)
        {
            return await _context.Cupons.FindAsync(id);
        }

        public async Task<List<Cupom>> ListarTodosAsync()
        {
            return await _context.Cupons
                .OrderByDescending(c => c.DataCriacao)
                .ToListAsync();
        }

        public async Task AdicionarAsync(Cupom cupom)
        {
            await _context.Cupons.AddAsync(cupom);
        }

        public async Task<bool> JaFoiUsadoPorAsync(Guid cupomId, string usuarioId)
        {
            return await _context.CupomUsos
                .AnyAsync(u => u.CupomId == cupomId && u.UsuarioId == usuarioId);
        }

        public async Task RegistrarUsoAsync(CupomUso cupomUso)
        {
            await _context.CupomUsos.AddAsync(cupomUso);
        }

        public async Task SalvarAlteracoesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
