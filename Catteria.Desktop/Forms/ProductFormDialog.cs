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

        private List<CategoriesResponseDto> _categorias = new();
        private ProductsResponseDto? _ProdutoExistente;

        public CreateProductDto ProductDto { get; private set; }
        public ProductFormDialog()
        {
            InitializeComponent();
        }

        public ProductFormDialog(List<CategoriesResponseDto> categorias, ProductsResponseDto? game)
        {
            _categorias = categorias;
            _ProdutoExistente = game;
            InitializeComponent();
        }
    }
}
