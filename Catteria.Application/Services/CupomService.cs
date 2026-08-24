using Catteria.Application.DTOs;
using Catteria.Domain.Entities;
using Catteria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Application.Services
{
    // Application/Services/CupomService.cs
    public class CupomService
    {
        private readonly ICupomRepository _repository;

        public CupomService(ICupomRepository repository)
        {
            _repository = repository;
        }

        public async Task<CupomDto> CriarAsync(CriarCupomRequest request)
        {
            var existente = await _repository.ObterPorCodigoAsync(request.Codigo);
            if (existente is not null)
                throw new InvalidOperationException($"Já existe um cupom com o código '{request.Codigo}'.");

            var cupom = new Cupom(request.Codigo, request.PercentualDesconto);
            await _repository.AdicionarAsync(cupom);
            await _repository.SalvarAlteracoesAsync();

            return MapearParaDto(cupom);
        }

        public async Task<List<CupomDto>> ListarAsync()
        {
            var cupons = await _repository.ListarTodosAsync();
            return cupons.Select(MapearParaDto).ToList();
        }

        public async Task<CupomDto> AtualizarAsync(Guid id, AtualizarCupomRequest request)
        {
            var cupom = await _repository.ObterPorIdAsync(id)
                ?? throw new KeyNotFoundException("Cupom não encontrado.");

            cupom.AtualizarDesconto(request.PercentualDesconto);
            await _repository.SalvarAlteracoesAsync();

            return MapearParaDto(cupom);
        }

        public async Task AlternarStatusAsync(Guid id, bool ativo)
        {
            var cupom = await _repository.ObterPorIdAsync(id)
                ?? throw new KeyNotFoundException("Cupom não encontrado.");

            if (ativo) cupom.Ativar();
            else cupom.Desativar();

            await _repository.SalvarAlteracoesAsync();
        }

        public async Task<ValidarCupomResult> ValidarAsync(string codigo, string usuarioId)
        {
            var cupom = await _repository.ObterPorCodigoAsync(codigo);

            if (cupom is null)
                return new ValidarCupomResult(false, "Cupom não encontrado.", null);

            if (!cupom.Ativo)
                return new ValidarCupomResult(false, "Cupom inativo.", null);

            var jaUsado = await _repository.JaFoiUsadoPorAsync(cupom.Id, usuarioId);
            if (jaUsado)
                return new ValidarCupomResult(false, "Cupom já utilizado por este usuário.", null);

            return new ValidarCupomResult(true, null, cupom);
        }

        private static CupomDto MapearParaDto(Cupom cupom) =>
            new(cupom.Id, cupom.Codigo, cupom.PercentualDesconto, cupom.Ativo, cupom.DataCriacao);
    }
}
