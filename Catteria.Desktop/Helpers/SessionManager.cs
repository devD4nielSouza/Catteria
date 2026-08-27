using Catteria.Desktop.DTOs;

namespace Catteria.Desktop.Helpers
{
    public sealed class SessionManager
    {
        // Instância única (lazy initialization + thread-safe com Lazy<T>)
        private static readonly Lazy<SessionManager> _instance =
            new(() => new SessionManager());

        /// <summary>
        /// Ponto de acesso global à instância única do SessionManager.
        /// Uso: SessionManager.Instance.CurrentUser
        /// </summary>
        public static SessionManager Instance => _instance.Value;

        // Construtor privado: impede criação de novas instâncias de fora
        private SessionManager() { }

        // =====================================================================
        // DADOS DA SESSÃO
        // =====================================================================

        /// <summary>
        /// Dados do usuário atualmente autenticado.
        /// É null quando nenhum usuário está logado.
        /// </summary>
        public UserResponseDto? CurrentUser { get; private set; }

        /// <summary>
        /// Indica se há um usuário autenticado na sessão atual.
        /// </summary>
        public bool IsAuthenticated => CurrentUser != null;

        /// <summary>
        /// Indica se o usuário autenticado possui perfil de Administrador.
        /// Usado para controlar acesso a módulos restritos.
        /// </summary>
        public bool IsAdmin => CurrentUser?.IsAdmin ?? false;

        // =====================================================================
        // MÉTODOS
        // =====================================================================

        /// <summary>
        /// Define o usuário autenticado na sessão.
        /// Chamado após login bem-sucedido na API.
        /// </summary>
        /// <param name="user">Dados do usuário retornados pela API</param>
        public void SetUser(UserResponseDto user)
        {
            CurrentUser = user;
        }

        /// <summary>
        /// Limpa os dados da sessão (logout).
        /// Após este método, IsAuthenticated retorna false.
        /// </summary>
        public void Clear()
        {
            CurrentUser = null;
        }

        /// <summary>
        /// Retorna o e-mail do usuário atual de forma segura.
        /// Retorna string vazia se não houver usuário autenticado.
        /// </summary>
        public string GetEmail() => CurrentUser?.Email ?? string.Empty;

        /// <summary>
        /// Retorna o nome de exibição do usuário (parte antes do @).
        /// Exemplo: "joao.silva@email.com"  "joao.silva"
        /// </summary>
        public string GetDisplayName()
        {
            var email = GetEmail();
            if (string.IsNullOrEmpty(email)) return "Usuário";

            var at = email.IndexOf('@');
            return at > 0 ? email[..at] : email;
        }
    }
}
