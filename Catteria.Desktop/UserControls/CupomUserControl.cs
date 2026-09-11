using Catteria.Desktop.DTOs;
using Catteria.Desktop.Forms;
using Catteria.Desktop.Helpers;
using Catteria.Desktop.Services;
using Catteria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Catteria.Desktop.UserControls
{
    public partial class CupomUserControl : UserControl
    {
        private CupomApiService _cuponsService = null!;

        private List<CuponsResponseDto> _todosCupons = new();
        public CupomUserControl()
        {
            InitializeComponent();
        }

        private async void CupomUserControl_Load(object sender, EventArgs e)
        {
            _cuponsService = new CupomApiService();

            ConfigurarPermissoes();

            await CarregarDadosAsync();
        }



        /// <summary>
        /// Mostra/esconde os botões de acordo com o perfil do usuário logado,
        /// igual ao que é feito no ProductsUserControl. Aqui não existe "Novo"
        /// porque pedidos não são criados manualmente pela tela do Desktop.
        /// </summary>
        private void ConfigurarPermissoes()
        {
            bool isAdmin = SessionManager.Instance.IsAdmin;
            btnEditar.Visible = isAdmin;
            btnNovo.Visible = isAdmin;
            btnAtualizar.Visible = isAdmin;
        }

        private async Task CarregarDadosAsync()
        {
            gridCupons.Rows.Clear();

            try
            {
                _todosCupons = await _cuponsService.GetAllAsync();

                PopularGrid(_todosCupons);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar pedidos: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // POPULAR GRID
        // =====================================================================

        /// <summary>
        /// Mostra uma lista de pedidos no DataGridView.
        /// </summary>
        private void PopularGrid(List<CuponsResponseDto> cupons)
        {
            gridCupons.Rows.Clear();

            foreach (var cupom in cupons)
            {
                var percentualDisplay = $"{cupom.PercentualDesconto:0.##}%"; // ex: "10%"
                gridCupons.Rows.Add(
                    cupom.Id,
                    cupom.Codigo,
                    percentualDisplay, // string com % aqui
                    cupom.Ativo ? "Ativo" : "Desativado",
                    cupom.DataCriacao.ToString("dd/MM/yyyy HH:mm")
                );
            }

            // opcional: alinhar coluna percentual à direita
            if (gridCupons.Columns["colPercentual"] is DataGridViewColumn col)
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        private void FiltrarCupons()
        {
            // Pega o texto digitado na pesquisa.
            string termo = txtPesquisa.Text.Trim();

            // Se não foi digitado nada, mostra todos os cupons.
            if (string.IsNullOrEmpty(termo))
            {
                PopularGrid(_todosCupons);
                return;
            }

            // Procura o termo nos campos do cupom.
            var cuponsFiltrados = _todosCupons
                .Where(c =>
                    // Código do cupom.
                    (c.Codigo ?? "")
                        .Contains(termo, StringComparison.OrdinalIgnoreCase)

                    // Percentual de desconto.
                    || c.PercentualDesconto
                        .ToString()
                        .Contains(termo, StringComparison.OrdinalIgnoreCase)

                    // Data de criação.
                    || c.DataCriacao
                        .ToString("dd/MM/yyyy HH:mm")
                        .Contains(termo, StringComparison.OrdinalIgnoreCase)

                    // Status.
                    || (c.Ativo ? "Ativo" : "Desativado")
                        .Contains(termo, StringComparison.OrdinalIgnoreCase)
                )
                .ToList();

            // Mostra somente os cupons encontrados.
            PopularGrid(cuponsFiltrados);
        }


        private void txtPesquisa_TextChanged(object sender, EventArgs e) => FiltrarCupons();

        private CuponsResponseDto? ObterCupomSelecionado()
        {
            if (gridCupons.SelectedRows.Count == 0) return null;
            var row = gridCupons.SelectedRows[0];
            var id = Guid.Parse(row.Cells["colId"].Value.ToString());
            return _todosCupons.FirstOrDefault(c => c.Id == id);
        }

        private async void btnNovo_Click(object sender, EventArgs e)
        {
            // Abre o formulário vazio para cadastrar um novo cupom.
            using var form = new CupomFormDialog();

            // Verifica se o usuário salvou o formulário.
            if (form.ShowDialog() == DialogResult.OK &&
                form.CupomDto != null)
            {
                // Envia o novo cupom para a API.
                var (success, _, error) =
                    await _cuponsService.CreateAsync(form.CupomDto);

                if (success)
                {
                    MessageBox.Show(
                        "Cupom cadastrado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Atualiza a grid.
                    await CarregarDadosAsync();
                }
                else
                {
                    MessageBox.Show(
                        $"{error}",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            var cupom = ObterCupomSelecionado();
            if (cupom == null)
            {
                MessageBox.Show("Selecione um cupom para editar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using var form = new CupomFormDialog(cupom);
            if (form.ShowDialog() == DialogResult.OK && form.UpdateDto != null)
            {
                var (success, _, error) = await _cuponsService.UpdateAsync(cupom.Id, form.UpdateDto);
                if (success)
                {
                    MessageBox.Show("✅ Cupom atualizado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    await CarregarDadosAsync();
                }
                else
                {
                    MessageBox.Show($"❌ {error}",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }



        private async void btnAtualizar_Click_1(object sender, EventArgs e) => await CarregarDadosAsync();


    }

}


