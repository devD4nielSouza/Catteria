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

        private async void UsuarioUserControl_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

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
                    u.Perfil,
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
                    || (u.Perfil ?? "").Contains(termo, StringComparison.OrdinalIgnoreCase)
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

        //
        // 
        //

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

        private async void btnNovo_Click_1(object sender, EventArgs e)
        {
            using var form = new UsuarioFormDialog(_perfis, null);
            if (form.ShowDialog() == DialogResult.OK && form.CreateDto != null)
            {
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

        private void txtPesquisa_TextChanged(object sender, EventArgs e) => FiltrarUsuarios();

        private async void btnAtualizar_Click(object sender, EventArgs e) => await CarregarDadosAsync();

    }
}