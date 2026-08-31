using Catteria.Desktop.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catteria.Desktop.Forms
{
    public partial class ProductFormDialog : Form
    {
        public CreateProductDto? ProductDto { get; private set; }
        public UpdateProductDto? UpdateDto { get; private set; }
        private List<CategoriesResponseDto> _categorias = new();
        private ProductsResponseDto? _produtoExistente;
        public ProductFormDialog()
        {
            InitializeComponent();
        }

        public ProductFormDialog(List<CategoriesResponseDto> categorias, ProductsResponseDto? product)
        {
            _categorias = categorias;
            _produtoExistente = product;
            InitializeComponent();
        }

        private void ProductFormDialog_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            this.Text = _produtoExistente == null ? "Novo Produto" : "Editar Produto";
            lblTituloForm.Text = _produtoExistente == null ? "Novo Produto" : "Editar Produto";

            //Popula o ComboBox de categorias
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Selecione uma categoria...");
            foreach (var cat in _categorias)
                cmbCategoria.Items.Add(cat.Name);
            cmbCategoria.SelectedIndex = 0;

            //Preenche campos se estiver no modo edição
            PreencherCampos();
        }

        private void PreencherCampos()
        {
            if (_produtoExistente == null) return;

            txtTitulo.Text = _produtoExistente.Name;
            txtDescricao.Text = _produtoExistente.Description;
            txtPreco.Text = _produtoExistente.Price.ToString();
            txtCoverUrl.Text = _produtoExistente.CoverImageUrl;
            chkDestaque.Checked = _produtoExistente.IsFeatured;

            var idx = _categorias.FindIndex(c => c.Id == _produtoExistente.CategoryId);
            if (idx >= 0) cmbCategoria.SelectedIndex = idx + 1;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show(
                    "Informe o titulo do produto.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
