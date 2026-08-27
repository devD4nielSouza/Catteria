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

        private ProductsApiService _apiService = null;
        private CategoriesApiService _categoriesService = null;

        public ProductsUserControl()
        {
            InitializeComponent();
        }

        private void ProductsUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
