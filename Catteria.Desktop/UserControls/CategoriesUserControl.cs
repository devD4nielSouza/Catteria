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
    public partial class CategoriesUserControl : UserControl
    {
        public CategoriesUserControl()
        {
            InitializeComponent();
        }

        private CategoriesApiService _categoriasService = null!;
        private List<CategoriesResponseDto> _categorias = new();


        private int? _editandoId = null;

        private void CategoriesUserControl_Load(object sender, EventArgs e)
        {
            _categoriasService = new CategoriesApiService();
        }

        private async Task CarregarDadosAsync()
        {
            
        }
    }
}
