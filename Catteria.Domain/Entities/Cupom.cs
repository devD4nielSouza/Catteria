namespace Catteria.Domain.Entities
{
    // Representa um cupom de desconto no domínio da aplicação.
    public class Cupom
    {
        // Identificador único do cupom.
        public Guid Id { get; private set; }

        // Código do cupom, por exemplo: "PROMO10".
        public string Codigo { get; private set; }

        // Percentual de desconto aplicado pelo cupom.
        public decimal PercentualDesconto { get; private set; }

        // Indica se o cupom está ativo ou não.
        public bool Ativo { get; private set; }

        // Data em que o cupom foi criado.
        public DateTime DataCriacao { get; private set; }

        // Construtor vazio exigido pelo EF Core para materialização da entidade.
        private Cupom() { } //EF Core

        // Cria um novo cupom validando os dados informados.
        public Cupom(string codigo, decimal percentualDesconto)
        {
            // Impede criação com código vazio ou nulo.
            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("Código do cupom não pode ser vazio.", nameof(codigo));

            // Garante que o desconto esteja entre 0 e 100.
            if (percentualDesconto <= 0 || percentualDesconto > 100)
                throw new ArgumentException("Percentual de desconto deve estar entre 0 e 100.", nameof(percentualDesconto));

            // Gera um novo ID.
            Id = Guid.NewGuid();

            // Normaliza o código removendo espaços e deixando em maiúsculo.
            Codigo = codigo.Trim().ToUpperInvariant();

            // Define o percentual de desconto.
            PercentualDesconto = percentualDesconto;

            // Ao criar, o cupom já nasce ativo.
            Ativo = true;

            // Registra a data de criação em UTC.
            DataCriacao = DateTime.UtcNow;
        }

        // Ativa o cupom.
        public void Ativar() => Ativo = true;

        // Desativa o cupom.
        public void Desativar() => Ativo = false;

        // Atualiza o percentual de desconto com validação.
        public void AtualizarDesconto(decimal percentualDesconto)
        {
            if (percentualDesconto <= 0 || percentualDesconto > 100)
                throw new ArgumentException("Percentual de desconto deve estar entre 0 e 100.", nameof(percentualDesconto));

            PercentualDesconto = percentualDesconto;
        }
    }
}
