using Catteria.Desktop.DTOs;
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
    /// <summary>
    /// Tela responsável pelo gerenciamento das categorias.
    /// Permite listar, criar, editar e excluir categorias.
    /// </summary>
    public partial class CategoriesUserControl : UserControl
    {
        /// <summary>
        /// Inicializa os componentes da tela.
        /// </summary>
        public CategoriesUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Serviço responsável por fazer as operações de categorias na API.
        /// </summary>

        private CategoriesApiService _categoriasService = null!;


        /// <summary>
        /// Lista que guarda as categorias carregadas da API.
        /// </summary>
        private List<CategoriesResponseDto> _categorias = new();

        /// <summary>
        /// Guarda o ID da categoria que está sendo editada.
        /// null = criando uma nova categoria.
        /// </summary
        private int? _editandoId = null;

        /// <summary>
        /// Executado quando a tela de categorias é carregada.
        /// Inicializa o serviço e busca as categorias da API.
        /// </summary>
        private async void CategoriesUserControl_Load(object sender, EventArgs e)
        {
            // Cria o serviço que irá conversar com a API.
            _categoriasService = new CategoriesApiService();

            // Busca e mostra as categorias no grid.
            await CarregarDadosAsync();
        }

        // =====================================================================
        // DADOS
        // =====================================================================
        private async Task CarregarDadosAsync()
        {
            gridCategorias.Rows.Clear();
            try
            {
                _categorias = await _categoriasService.GetAllAsync();
                foreach (var c in _categorias)
                    gridCategorias.Rows.Add(c.Id, c.Name, c.ProductCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        // =====================================================================
        // FORMULÁRIO
        // =====================================================================
        private void MostrarFormulario(CategoriesResponseDto? category)
        {
            _editandoId = category?.Id;
            txtNome.Text = category?.Name ?? string.Empty;
            lblFormTitulo.Text = category == null ? "Nova Categoria" : "Editar Categoria";
            pnlForm.Visible = true;
            txtNome.Focus();
        }

        private void OcultarFormulario()
        {
            pnlForm.Visible = false;
            _editandoId = null;
            txtNome.Clear();
        }

        private void btnNova_Click(object sender, EventArgs e) => MostrarFormulario(null);

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var cat = ObterCategoriaSelecionada();
            if (cat == null)
            {
                MessageBox.Show("Selecione uma categoria para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MostrarFormulario(cat);
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            var cat = ObterCategoriaSelecionada();
            if (cat == null)
            {
                MessageBox.Show("Selecione uma categoria para excluir.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cat.ProductCount > 0)
            {
                MessageBox.Show(
                    $"A categoria \"{cat.Name}\" possui {cat.ProductCount} produto (s) vinculado(s).\nRemova os produtos antes de excluir.",
                    "Não é possível excluir",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var conf = MessageBox.Show(
                $"Excluir a categoria \"{cat.Name}\"?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (conf != DialogResult.Yes) return;

            var (success, error) = await _categoriasService.DeleteAsync(cat.Id);
            if (success)
            {
                MessageBox.Show("✅ Categoria excluída!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CarregarDadosAsync();
            }
            else
            {
                MessageBox.Show($"❌ {error}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnAtualizar_Click(object sender, EventArgs e) => await CarregarDadosAsync();


        private CategoriesResponseDto? ObterCategoriaSelecionada()
        {
            if (gridCategorias.SelectedRows.Count == 0) return null;
            var id = Convert.ToInt32(gridCategorias.SelectedRows[0].Cells["colId"].Value);
            return _categorias.FirstOrDefault(c => c.Id == id);
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o nome da categoria", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success;
            string error;

            if (_editandoId == null)
            {
                var dto = new CreateCategoriesDto { Name = txtNome.Text.Trim() };
                var result = await _categoriasService.CreateAsync(dto);
                success = result.Success;
                error = result.ErrorMessage;
            }
            else
            {
                var dto = new UpdateCategoriesDto { Name = txtNome.Text.Trim() };
                var result = await _categoriasService.UpdateAsync(_editandoId.Value, dto);
                success = result.Success;
                error = result.ErrorMessage;
            }

            if (success)
            {
                MessageBox.Show("✅ Salvo com sucesso!", "Sucesso",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                OcultarFormulario();
                await CarregarDadosAsync();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => OcultarFormulario();

    }
}






