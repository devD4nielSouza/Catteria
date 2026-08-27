using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Domain.Entities
{
    // Entidade que representa um registro de uso de cupom
    public class CupomUso
    {
        // Identificador único do registro
        public Guid Id { get; private set; }

        // Referência ao cupom utilizado
        public Guid CupomId { get; private set; }

        // Id do usuário que usou o cupom
        public string UsuarioId { get; private set; }

        // Id do pedido associado ao uso do cupom
        public int OrderId { get; private set; }

        // Data e hora em que o cupom foi usado (UTC)
        public DateTime DataUso { get; private set; }

        // Construtor privado sem parâmetros necessário para o EF Core (ORM)
        private CupomUso() { } // EF Core

        // Construtor público que cria um novo registro de uso de cupom,
        // validando argumentos obrigatórios e inicializando propriedades.
        public CupomUso(Guid cupomId, string usuarioId, int orderId)
        {
            // Valida que o cupomId não seja o Guid vazio
            if (cupomId == Guid.Empty)
                throw new ArgumentException("CupomId inválido.", nameof(cupomId));

            // Valida que o usuarioId não seja nulo, vazio ou somente espaços
            if (string.IsNullOrWhiteSpace(usuarioId))
                throw new ArgumentException("UsuarioId inválido.", nameof(usuarioId));
            // Valida que o orderId não seja menor ou igual a zero
            if (orderId <= 0)
                throw new ArgumentException("OrderId inválido.", nameof(orderId));

            // Inicializa propriedades: gera um novo Id e marca a DataUso como UTC agora
            Id = Guid.NewGuid();
            CupomId = cupomId;
            UsuarioId = usuarioId;
            OrderId = orderId;
            DataUso = DateTime.UtcNow;
        }
    }
}
