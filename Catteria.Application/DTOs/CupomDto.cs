using Catteria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Application.DTOs
{
    // Application/DTOs/CupomDto.cs
    public record CupomDto(Guid Id, string Codigo, decimal PercentualDesconto, bool Ativo, DateTime DataCriacao);

    // Application/DTOs/CriarCupomRequest.cs
    public record CriarCupomRequest(string Codigo, decimal PercentualDesconto);

    // Application/DTOs/AtualizarCupomRequest.cs
    public record AtualizarCupomRequest(decimal PercentualDesconto);

    // Application/DTOs/ValidarCupomResult.cs
    public record ValidarCupomResult(bool Valido, string? MotivoInvalido, Cupom? Cupom);
}
