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
        private CuponsResponseDto? _cupomExistente;
        public CreateCupomDto? CupomDto { get; private set; }
        public UpdateCupomDto? UpdateDto { get; private set; }

        public CupomFormDialog(CuponsResponseDto? cupom = null)
        {
            InitializeComponent();

        _cupomExistente = cupom;

            // Quando for um novo cupom, começa desativado.
            if (_cupomExistente == null)
            {
                chkWorking.Checked = false;
            }
        }

        private void txtPorcent_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas números e Backspace.
            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void CupomFormDialog_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            // Define o título de acordo com o modo do formulário.
            this.Text = _cupomExistente == null ? "Novo Cupom" : "Editar Cupom";
            lblTituloForm.Text = _cupomExistente == null ? "Novo Cupom" : "Editar Cupom";

            // Preenche os campos caso seja uma edição.
            PreencherCampos();
        }

        private void PreencherCampos()
        {
            if (_cupomExistente == null) return;

            txtCod.Text = _cupomExistente.Codigo;
            txtPorcent.Text = _cupomExistente.PercentualDesconto.ToString("0.##", System.Globalization.CultureInfo.CurrentCulture);
            chkWorking.Checked = _cupomExistente.Ativo;
        }
        

        private void btnSalvar_Click(object sender, EventArgs e)

        {
            // Verifica se o código foi preenchido.
            if (string.IsNullOrWhiteSpace(txtCod.Text))
            {
                MessageBox.Show(
                    "Informe o código do cupom.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCod.Focus();
                return;
            }

            // Verifica se a porcentagem foi preenchida.
            if (string.IsNullOrWhiteSpace(txtPorcent.Text))
            {
                MessageBox.Show(
                    "Informe a porcentagem do desconto.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPorcent.Focus();
                return;
            }

            // Converte a porcentagem para número.
            if (!decimal.TryParse(
                    txtPorcent.Text,
                    out decimal percentual))
            {
                MessageBox.Show(
                    "Informe uma porcentagem válida.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPorcent.Focus();
                return;
            }

            // Verifica se a porcentagem está entre 1 e 100.
            if (percentual <= 0 || percentual > 100)
            {
                MessageBox.Show(
                    "A porcentagem deve estar entre 1 e 100.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPorcent.Focus();
                return;
            }

            // ================================================================
            // NOVO CUPOM
            // ================================================================

            if (_cupomExistente == null)
            {
                CupomDto = new CreateCupomDto
                {
                    Codigo = txtCod.Text.Trim(),
                    PercentualDesconto = percentual,
                    Ativo = chkWorking.Checked
                };
            }

            // ================================================================
            // EDITAR CUPOM
            // ================================================================

            else
            {
                UpdateDto = new UpdateCupomDto
                {
                    Codigo = txtCod.Text.Trim(),
                    PercentualDesconto = percentual,
                    Ativo = chkWorking.Checked
                };
            }

            // Informa ao UserControl que o formulário foi salvo.
            DialogResult = DialogResult.OK;

            // Fecha o formulário.
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Fecha o formulário sem salvar.
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

}

