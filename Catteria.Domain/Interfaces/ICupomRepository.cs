using Catteria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Domain.Interfaces
{
    // Application/Interfaces/ICupomRepository.cs
    public interface ICupomRepository
    {
        Task<Cupom?> ObterPorCodigoAsync(string codigo);
        Task<Cupom?> ObterPorIdAsync(Guid id);
        Task<List<Cupom>> ListarTodosAsync();
        Task AdicionarAsync(Cupom cupom);
        Task<bool> JaFoiUsadoPorAsync(Guid cupomId, string usuarioId);
        Task RegistrarUsoAsync(CupomUso cupomUso);
        Task SalvarAlteracoesAsync();
    }
}
