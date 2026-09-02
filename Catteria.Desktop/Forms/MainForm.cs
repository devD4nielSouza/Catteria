using Catteria.Desktop.Helpers;
using Catteria.Desktop.Services;
using Catteria.Desktop.UserControls;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catteria.Desktop.Forms
{
    public partial class MainForm : Form
    {
        private UserControl? _controleAtual;

        private Guna2Button? _botaoAtivo;

        private AuthApiService _authService = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            _authService = new AuthApiService();

            this.Text = $"Catteria Desktop - {AppConfig.Version}";

            lblUsuario.Text = $"{SessionManager.Instance.GetDisplayName()}";
            
            lblSessao.Text = $"{SessionManager.Instance.GetEmail()}";

            ConfigurarPermissoes();

            NavegarParaDashboard();
        }

        private void ConfigurarPermissoes()
        {
            var isAdmin = SessionManager.Instance.IsAdmin;

            btnCategorias.Visible = isAdmin;
            btnUsuarios.Visible = isAdmin;
        }

        private void NavegarParaDashboard()
        {
            Navegar(new DashboardUserControl(), btnDashboard);
        }

        private void Navegar(UserControl control, Guna2Button? botao = null)
        {
            if (_controleAtual != null)
            {
                pnlConteudo.Controls.Remove(_controleAtual);
                _controleAtual.Dispose();
                _controleAtual = null;
            }

            control.Dock = DockStyle.Fill;
            pnlConteudo.Controls.Add(control);
            _controleAtual = control;

            AtualizarBotaoAtivo(botao);
        }

        private void AtualizarBotaoAtivo(Guna2Button? botao)
        {
            if (_botaoAtivo != null)
            {
                _botaoAtivo.FillColor = Color.Transparent;
                _botaoAtivo.ForeColor = Color.White;

                _botaoAtivo = botao;
                if (_botaoAtivo != null)
                {
                    _botaoAtivo.FillColor = Color.FromArgb(0, 50, 110);
                    _botaoAtivo.ForeColor = Color.White;
                    _botaoAtivo.CustomBorderColor = Color.AliceBlue;

                }
            }
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show(
                "Deseja realmente sair do sistema?",
                "Confirmar Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resposta != DialogResult.Yes) return;

            try
            {
                await _authService.LogoutAsync();
            }
            catch
            {
                // Mesmo se a API falhar, limpa a sessão local
            }
            finally
            {
                SessionManager.Instance.Clear();
                this.Close();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e) => Navegar(new DashboardUserControl(), btnDashboard);

        private void btnProdutos_Click(object sender, EventArgs e) => Navegar(new ProductsUserControl(), btnProdutos);

        private void btnCategorias_Click(object sender, EventArgs e) => Navegar(new CategoriesUserControl(), btnCategorias);

        private void btnPedidos_Click(object sender, EventArgs e) => Navegar(new OrdersUserControl(), btnPedidos);

        private void btnUsuarios_Click(object sender, EventArgs e) => Navegar(new UsuarioUserControl(), btnUsuarios);

        private void btnCupom_Click(object sender, EventArgs e) => Navegar(new CupomUserControl(), btnCupom);
     
    }
}