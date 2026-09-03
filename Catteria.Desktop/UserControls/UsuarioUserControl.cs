using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Catteria.Desktop.DTOs;
using Catteria.Desktop.Services;
using Catteria.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Catteria.Desktop.Forms;

namespace Catteria.Desktop.UserControls
{
    public partial class UsuarioUserControl : UserControl
    {
        private UsuariosApiService _usuariosService = null!;
        private List<UsuariosResponseDto> _todosUsuarios = new();
        private List<string> _perfis = new();
        public UsuarioUserControl()
        {
            InitializeComponent();
            _usuariosService = new UsuariosApiService();
        }

        /// <summary>
        /// Executa quando o UserControl é carregado.
        /// Configura as permissões e carrega os usuários da API.
        /// </summary>
      
        private async void UsuarioUserControl_Load_1(object sender, EventArgs e)
        {
            if (DesignMode) return;

            ConfigurarPermissoes();

            await CarregarDadosAsync();
        }

        /// <summary>
        /// Configura a visibilidade dos botões de acordo
        /// com o nível de acesso do usuário logado.
        /// </summary>
        private void ConfigurarPermissoes()
        {
            bool isAdmin = SessionManager.Instance.IsAdmin;
            btnNovo.Visible = isAdmin;
            btnEditar.Visible = isAdmin;
            btnExcluir.Visible = isAdmin;
        }


        /// <summary>
        /// Busca todos os usuários na API e atualiza o DataGridView.
        /// </summary>
        private async Task CarregarDadosAsync()
        {
            gridUsuarios.Rows.Clear();

            try
            {

                // REQUISIÇÃO PARA API:
                // Chama o método GetAllAsync() do serviço,
                // que faz uma requisição GET para buscar todos os usuários.

                _todosUsuarios = await _usuariosService.GetAllAsync();
                PopularGrid(_todosUsuarios);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar usuários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Preenche o DataGridView com os usuários recebidos.
        /// </summary>
        private void PopularGrid(List<UsuariosResponseDto> usuarios)
        {
            gridUsuarios.Rows.Clear();
            foreach (var u in usuarios)
            {
                gridUsuarios.Rows.Add(
                    u.Id,
                    u.Nome, 
                    u.Perfil,
                    u.Email,
                    u.Telephone,
                    u.Address
                );
            }
        }

        /// <summary>
        /// Filtra os usuários pelo nome, e-mail, telefone,
        /// perfil ou endereço informado no campo de pesquisa.
        /// </summary>
        private void FiltrarUsuarios()
        {
            var termo = txtPesquisa.Text?.Trim();
            if (string.IsNullOrEmpty(termo))
            {
                PopularGrid(_todosUsuarios);
                return;
            }

            var filtrados = _todosUsuarios
                .Where(u =>
                    (u.Nome ?? "").Contains(termo, StringComparison.OrdinalIgnoreCase)
                    || (u.Email ?? "").Contains(termo, StringComparison.OrdinalIgnoreCase)
                    || (u.Telephone ?? "").Contains(termo, StringComparison.OrdinalIgnoreCase)
                    || (u.Perfil ?? "").Contains(termo, StringComparison.OrdinalIgnoreCase)
                    || (u.Address ?? "").Contains(termo, StringComparison.OrdinalIgnoreCase)
                )
                .ToList();

            PopularGrid(filtrados);
        }



        /// <summary>
        /// Retorna o usuário atualmente selecionado no DataGridView.
        /// </summary>
        private UsuariosResponseDto? ObterUsuarioSelecionado()
        {
            if (gridUsuarios.SelectedRows.Count == 0) return null;
            var row = gridUsuarios.SelectedRows[0];
            var id = row.Cells["colId"].Value?.ToString();
            if (string.IsNullOrEmpty(id)) return null;
            return _todosUsuarios.FirstOrDefault(u => (u.Id?.ToString() ?? "") == id);
        }


        /// <summary>
        /// Exclui o usuário selecionado após confirmação.
        /// </summary>
        private async void btnExcluir_Click_1(object sender, EventArgs e)
        {
            var usuario = ObterUsuarioSelecionado();
            if (usuario == null)
            {
                MessageBox.Show("Selecione um usuário para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var conf = MessageBox.Show($"Deseja realmente excluir o usuário \"{usuario.Nome}\"?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (conf != DialogResult.Yes) return;

            try
            {
                // REQUISIÇÃO PARA API:
                // Envia o ID do usuário para o service,
                // que realiza a requisição DELETE para a API.
                var (success, error) = await _usuariosService.DeleteAsync(usuario.Id?.ToString() ?? "");
                if (success)
                {
                    MessageBox.Show("✅ Usuário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CarregarDadosAsync();
                }
                else
                {
                    MessageBox.Show($"❌ {error}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Abre o formulário de edição e atualiza os dados do usuário.
        /// </summary>

        private async void btnEditar_Click_1(object sender, EventArgs e)
        {
            var usuario = ObterUsuarioSelecionado();
            if (usuario == null)
            {
                MessageBox.Show(
                    "Selecione um usuário para editar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using var form = new UsuarioFormDialog(_perfis, usuario);
            if (form.ShowDialog() == DialogResult.OK && form.UpdateDto != null)
            {
                // REQUISIÇÃO PARA API:
                // Envia os dados atualizados do usuário para o service,
                // que realiza a requisição de atualização na API.
                var (success, _, error) = await _usuariosService.UpdateAsync(usuario.Id, form.UpdateDto);
                if (success)
                {
                    MessageBox.Show(
                        "✅ Usuário atualizado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    await CarregarDadosAsync();
                }
                else
                {
                    MessageBox.Show(
                        $"❌ {error}",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Abre o formulário para criação de um novo usuário.
        /// </summary>
        private async void btnNovo_Click_1(object sender, EventArgs e)
        {
            using var form = new UsuarioFormDialog(_perfis, null);
            if (form.ShowDialog() == DialogResult.OK && form.CreateDto != null)
            {
                // REQUISIÇÃO PARA API:
                // Envia os dados do novo usuário para o service,
                // que realiza a requisição POST para a API.
                var (success, _, error) = await _usuariosService.CreateAsync(form.CreateDto);
                if (success)
                {
                    MessageBox.Show(
                        "✅ Usuário criado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    await CarregarDadosAsync();
                }
                else
                {
                    MessageBox.Show($"❌ {error}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Executa o filtro sempre que o texto da pesquisa é alterado.
        /// </summary>
        private void txtPesquisa_TextChanged(object sender, EventArgs e) => FiltrarUsuarios();

        /// <summary>
        /// Recarrega os usuários da API quando o botão Atualizar é clicado.
        /// </summary>
        private async void btnAtualizar_Click(object sender, EventArgs e) => await CarregarDadosAsync();

     
    }
}