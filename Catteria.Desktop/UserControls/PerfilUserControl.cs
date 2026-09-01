using Catteria.Desktop.Helpers;
using Catteria.Desktop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catteria.Desktop.UserControls
{
    public partial class PerfilUserControl : UserControl
    {

        // =====================================================================
        // SERVIÇOS (inicializados no Load)
        // =====================================================================
        private AuthApiService _authService = null!;

        public PerfilUserControl()
        {
            InitializeComponent();
        }

        private void PerfilUserControl_Load(object sender, EventArgs e)
        {
            _authService = new AuthApiService();

            //Preenche os dados de sessão nas varíaveis
            var displayName = SessionManager.Instance.GetDisplayName();
            var email = SessionManager.Instance.GetEmail();
            var isAdmin = SessionManager.Instance.IsAdmin;

    

            // Preenche os campos do perfil
            lblNome.Text = displayName;
            lblEmailValor.Text = email;
        

            // bagde do perfil
            var perfil = isAdmin ? "🔑 Administrador" : "👀 Usuário";
                lblBadge.Text = perfil;
      

            // Roles - Permissões do usuário
            var roles = SessionManager.Instance.CurrentUser?.Roles
                ?? new List<string>();

            lblRolesValor.Text = roles.Count > 0 ? string.Join(", ", roles)
                : "Sem perfil atribuído";
        }
    }
}
