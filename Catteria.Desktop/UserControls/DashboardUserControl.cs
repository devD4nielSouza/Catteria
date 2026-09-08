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
    public partial class DashboardUserControl : UserControl
    {
        private ProductsApiService _productService = null;
        private CategoriesApiService _categoriesService = null;
        public DashboardUserControl()
        {
            InitializeComponent();
        }

        private async void DashboardUserControl_Load(object sender, EventArgs e)
                {
                    if (DesignMode) return;

                    _productService = new ProductsApiService();
                    _categoriesService = new CategoriesApiService();

                    lblTitulo.Text = $"Olá, {SessionManager.Instance.GetDisplayName()!}";
                    lblSubTitulo.Text = $"Bem-vindo ao Catteria Desktop - {DateTime.Now:dddd, dd 'de' MMM 'de' yyyy}";

                    await CarregarDadosAsync();
                }

        private async Task CarregarDadosAsync()
        {
            SetCarregando(true);

            try
            {
                var tarefaProduct = _productService.GetAllAsync();
                var tarefaCategories = _categoriesService.GetAllAsync();
                await Task.WhenAll(tarefaProduct, tarefaCategories);

                var products = tarefaProduct.Result;
                var categories = tarefaCategories.Result;

                cardProdutosLblNumero.Text = products.Count.ToString();
                cardCategoriasLblNumero.Text = categories.Count.ToString();

                gridUltimosProdutos.Rows.Clear();
                foreach (var product in products.OrderByDescending(x => x.CreatedAt).Take(5))
                {
                    var nomeCategoria = categories
                        .FirstOrDefault(c => c.Id == product.CategoryId)?.Name
                        ?? "Sem categoria";

                    gridUltimosProdutos.Rows.Add(
                        product.Id,
                        product.Name,
                        nomeCategoria,
                        product.IsFeatured,
                        product.CreatedAt.ToString("dd/MM/yyyy HH:mm")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                $"Erro ao carregar dados: {ex.Message}",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            finally
            {
                SetCarregando(false);
            }
        }

        private void AtualizarNumeroCard(Guna.UI2.WinForms.Guna2Panel card, string numero)
        {
            var lblNumero = card.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "numero");

            if (lblNumero != null)
            {
                lblNumero.Text = numero;
            }
        }

        private void SetCarregando(bool carregando)
        {
            cardProdutos.Visible = !carregando;
            cardCategorias.Visible = !carregando;
            lblUltimosProdutos.Visible = !carregando;
            gridUltimosProdutos.Visible = !carregando;
        }

        
    }
}
