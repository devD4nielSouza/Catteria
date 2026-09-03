using Catteria.Desktop.DTOs;
using Catteria.Desktop.Forms;
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
    public partial class ProductsUserControl : UserControl
    {

        private ProductsApiService _productsService = null;
        private CategoriesApiService _categoriesService = null;

        private List<ProductsResponseDto> _todosProdutos = new();
        private List<CategoriesResponseDto> _categorias = new();

        public ProductsUserControl()
        {
            InitializeComponent();
        }

        private async void ProductsUserControl_Load(object sender, EventArgs e)
        {
            _productsService = new ProductsApiService();
            _categoriesService = new CategoriesApiService();

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
            gridProdutos.Rows.Clear();

            try
            {
                var tarefaProdutos = _productsService.GetAllAsync();
                var tarefaCategorias = _categoriesService.GetAllAsync();
                await Task.WhenAll(tarefaProdutos, tarefaCategorias);

                _todosProdutos = tarefaProdutos.Result;
                _categorias = tarefaCategorias.Result;

                PopularGrid(_todosProdutos);

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao carregar os Produtos : {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void PopularGrid(List<ProductsResponseDto> produtos)
        {
            gridProdutos.Rows.Clear(); // Limpa a grid pra não duplicar linhas quando recarregar

            foreach (var p in produtos) // Percorre cada produto da lista, um por vez
            {
                // A API só manda o CategoryId (número) do produto, não o nome da categoria.
                // Então aqui a gente procura, na lista de categorias já carregada (_categorias),
                // qual categoria tem o Id igual ao CategoryId do produto.
                var nomeCategoria = _categorias
                    .FirstOrDefault(c => c.Id == p.CategoryId) // Procura a categoria com esse Id na lista
                    ?.Name                                     // Se encontrou, pega o nome dela
                    ?? "Sem categoria";                         // Se não encontrou (Id inválido/nulo), usa esse texto padrão

                // Adiciona uma nova linha na grid, uma coluna de cada vez, na ordem: Id, Categoria, Preço, Nome
                gridProdutos.Rows.Add(
                    p.Id,           // Coluna "ID" -> Id do produto
                    p.Name,         // Coluna "Nome do Produto" -> nome do produto vindo da API
                    nomeCategoria,  // Coluna "Categoria" -> nome que acabamos de descobrir (não mais o número)        // Coluna "Preço do Produto" -> preço vindo da API
                    p.Price
                 
                );
            }
        }

        private void FiltrarProdutos()
        {
            var termo = txtPesquisa.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(termo))
            {
                PopularGrid(_todosProdutos);
                return;
            }

            var filtrados = _todosProdutos
                .Where(p =>
                {
                    // Busca o nome da categoria desse produto na lista de categorias (mesma lógica do PopularGrid)
                    var nomeCategoria = _categorias
                        .FirstOrDefault(c => c.Id == p.CategoryId)?.Name ?? "";

                    // Filtra se o termo pesquisado aparece no nome do produto OU no nome da categoria
                    return p.Name.Contains(termo, StringComparison.OrdinalIgnoreCase)
                        || nomeCategoria.Contains(termo, StringComparison.OrdinalIgnoreCase);
                })
                .ToList();

            PopularGrid(filtrados);
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e) => FiltrarProdutos();
        private async void btnNovo_Click(object sender, EventArgs e)
        {
            using var form = new ProductFormDialog(_categorias, null);
            if (form.ShowDialog() == DialogResult.OK && form.ProductDto != null)
            {
                var (success, _, error) = await _productsService.CreateAsync(form.ProductDto);
                if (success)
                {
                    MessageBox.Show("Produto atualizado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    await CarregarDadosAsync();

                }
                else
                {
                    MessageBox.Show($"{error}", "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            var product = ObterProdutoSelecionado();
            if (product == null)
            {
                MessageBox.Show($"Selecione um produto para editar",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;


            }

            using var form = new ProductFormDialog(_categorias, product);
            if (form.ShowDialog() == DialogResult.OK && form.UpdateDto != null)
            {
                var (sucess, _, error) = await _productsService.UpdateAsync(product.Id, form.UpdateDto);
                if (sucess)
                {
                    MessageBox.Show("Produto atualizado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    await CarregarDadosAsync();
                }
                else
                {
                    MessageBox.Show($"{error}",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }


        }

        private ProductsResponseDto? ObterProdutoSelecionado()
        {
            if (gridProdutos.SelectedRows.Count == 0) return null;
            var row = gridProdutos.SelectedRows[0];
            var id = Convert.ToInt32(row.Cells["colId"].Value);
            return _todosProdutos.FirstOrDefault(p => p.Id == id);
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            var product = ObterProdutoSelecionado();
            if (product == null)
            {
                MessageBox.Show("Selecione um produto para excluir.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            var conf = MessageBox.Show
                ($"Tem certeza que deseja excluir esse produto:\n\"{product.Name}\"?",
                "Confirmar Exclusão", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (conf != DialogResult.Yes) ;

            var (success, error) = await _productsService.DeleteAsync(product.Id);
            if (success)
            {
                MessageBox.Show("Produto excluido com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CarregarDadosAsync();
            }
            else
            {
                MessageBox.Show($"{error}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private async void btnAtualizar_Click(object sender, EventArgs e) => await CarregarDadosAsync();



    }
}
