using System;
using System.Collections.Generic;
using System.Text;

namespace Catteria.Domain.Entities
{
    public class User
    {
        public int Id { get; set; } // Identificador único do usuário (chave primária)
        public string Name { get; set; } = string.Empty; // Nome do usuário

        public string Email { get; set; } = string.Empty; // Endereço de email do usuário

        public string Telephone { get; set; } = string.Empty; // Número de telefone do usuário

        public DateTime DateRegister { get; set; } = DateTime.Now;// Data de registro do usuário, definida automaticamente para a data atual
    }
}
