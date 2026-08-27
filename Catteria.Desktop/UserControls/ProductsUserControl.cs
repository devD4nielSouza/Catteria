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
            gridProdutos.Rows.Clear();
            foreach (var p in produtos)
            {
                gridProdutos.Rows.Add(
                p.Id,
                p.CategoryName,
                p.Price,
                p.Name
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
                .Where(p => p.Name.Contains(termo, StringComparison.OrdinalIgnoreCase)
                || p.CategoryName.Contains(termo, StringComparison.OrdinalIgnoreCase))
                .ToList();

            PopularGrid(filtrados);
        }
        private void txtPesquisa_TextChanged(object sender, EventArgs e) => FiltrarProdutos();
        private void btnNovo_Click(object sender, EventArgs e)
        {
            //using var form = new ProductFormDialog(_categorias, null);
            //if(form.ShowDialog() == DialogResult.OK && form.Product)
        }

    }


}
