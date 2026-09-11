using System;

namespace Catteria.Desktop.DTOs
{
    /// <summary>
    /// Dados de um cupom vindos da API.
    /// Setter precisa ser público para o System.Text.Json conseguir
    /// desserializar — com "private set" os campos ficam com valor
    /// padrão sem lançar nenhum erro visível.
    /// </summary>
    public class CuponsResponseDto
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public decimal PercentualDesconto { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
    }

    /// <summary>
    /// Espelha o CriarCupomRequest da Application: só Código e Percentual.
    /// O cupom já nasce ativo no backend, por isso não tem campo "Ativo".
    /// </summary>
    public class CreateCupomDto
    {
        public string Codigo { get; set; } = string.Empty;
        public decimal PercentualDesconto { get; set; }

        public bool Ativo { get; set; }
    }

    /// <summary>
    /// Espelha o AtualizarCupomRequest da Application: só dá pra mudar
    /// o percentual de desconto por aqui. Código e Ativo/Inativo têm
    /// fluxos próprios.
    /// </summary>
    public class UpdateCupomDto
    {
        public bool Ativo { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public decimal PercentualDesconto { get; set; }
    }
}