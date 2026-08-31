using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Desktop.DTOs
{
    public class CupomResponseDto
    {
        public Guid Id { get; private set; }
        public string Codigo { get; private set; } = string.Empty;
        public int PercentualDesconto { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCriacao { get; private set; }
    }
    public class CreateCupomDto
    {
        public string Codigo { get; private set; } = string.Empty;
        public int PercentualDesconto { get; private set; }
        public bool Ativo { get; private set; }
    }
    public class UpdateCupomDto
    {
        public string Codigo { get; private set; } = string.Empty;
        public int PercentualDesconto { get; private set; }
        public bool Ativo { get; private set; }
    }
}
