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
    public partial class CupomFormDialog : Form
    {
        private CupomResponseDto? _cupomExistente;
        public CreateCupomDto? CupomDto { get; private set; }
        public UpdateCupomDto? UpdateDto { get; private set; }
        public CupomFormDialog()
        {
            InitializeComponent();
        }

        private void txtPorcent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true; // Cancela o evento, impedindo a digitação
            }
        }

        private void CupomFormDialog_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            this.Text = _cupomExistente == null ? "Novo Cupom" : "Editar Cupom";
            lblTituloForm.Text = _cupomExistente == null ? "Novo Cupom" : "Editar Cupom";

            PreencherCampos();
        }

        private void PreencherCampos()
        {
            if (_cupomExistente == null) return;

            txtCod.Text = _cupomExistente.Codigo;
            txtPorcent.Text = _cupomExistente.PercentualDesconto.ToString();
            chkWorking.Checked = _cupomExistente.Ativo;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCod.Text))
            {
               MessageBox.Show(
                   "Informe o titulo do game.",
                   "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        
    }
}
