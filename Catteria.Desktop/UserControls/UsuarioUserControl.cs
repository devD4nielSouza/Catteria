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

namespace Catteria.Desktop.UserControls
{
    public partial class UsuarioUserControl : UserControl
    {
        private UsuariosApiService _usuariosService = null!;
        private List<UsuariosResponseDto> _todosUsuarios = new();

        public UsuarioUserControl()
        {
            InitializeComponent();
        }

        private async void UsuarioUserControl_Load(object sender, EventArgs e)
        {


            _usuariosService = new UsuariosApiService();

            ConfigurarPermissoes();

            await CarregarDadosAsync();
        }

        private void ConfigurarPermissoes()
        {
            bool isAdmin = SessionManager.Instance.IsAdmin;
            btnNovo.Visible = isAdmin;
            btnEditar.Visible = isAdmin;
            btnExcluir.Visible = isAdmin;
        }

        private async Task CarregarDadosAsync()
        {
            gridUsuarios.Rows.Clear();

            try
            {
                _todosUsuarios = await _usuariosService.GetAllAsync();
                PopularGrid(_todosUsuarios);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar usuários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PopularGrid(List<UsuariosResponseDto> usuarios)
        {
            gridUsuarios.Rows.Clear();
            foreach (var u in usuarios)
            {
                gridUsuarios.Rows.Add(
                    u.Id,
                    u.Nome,
                    u.Email,
                    u.Telephone,
                    u.Type,
                    u.Address
                );
            }
        }

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
                    || (u.Type ?? "").Contains(termo, StringComparison.OrdinalIgnoreCase)
                    || (u.Address ?? "").Contains(termo, StringComparison.OrdinalIgnoreCase)
                )
                .ToList();

            PopularGrid(filtrados);
        }




        private UsuariosResponseDto? ObterUsuarioSelecionado()
        {
            if (gridUsuarios.SelectedRows.Count == 0) return null;
            var row = gridUsuarios.SelectedRows[0];
            var id = row.Cells["colId"].Value?.ToString();
            if (string.IsNullOrEmpty(id)) return null;
            return _todosUsuarios.FirstOrDefault(u => (u.Id?.ToString() ?? "") == id);
        }



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

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            var usuario = ObterUsuarioSelecionado();
            if (usuario == null)
            {
                MessageBox.Show("Selecione um usuário para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Implementar abertura de formulário de edição se existir (ex: UsuarioFormDialog).
            MessageBox.Show($"Editar usuário '{usuario.Nome}' não implementado aqui. ID: {usuario.Id}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNovo_Click_1(object sender, EventArgs e)
        {
            // Implementação do formulário de criação de usuário pode ser adicionada aqui.
            MessageBox.Show("Funcionalidade de criação de usuário não implementada nesta versão.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e) => FiltrarUsuarios();

        private async void btnAtualizar_Click(object sender, EventArgs e) => await CarregarDadosAsync();

    }
}