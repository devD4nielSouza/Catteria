using Catteria.Desktop.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Catteria.Desktop.Forms
{
    public partial class OrderFormDialog : Form
    {
        public UpdateOrderStatusDto? UpdateDto { get; private set; }

        private List<OrderStatusResponseDto> _status = new();
        private OrdersResponseDto? _pedidoExistente;

        public OrderFormDialog()
        {
            InitializeComponent();
        }

        public OrderFormDialog(List<OrderStatusResponseDto> status, OrdersResponseDto? pedido)
        {
            _status = status ?? new List<OrderStatusResponseDto>();
            _pedidoExistente = pedido;
            InitializeComponent();
        }

        private void OrderFormDialog_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            this.Text = "Editar Status";
            lblTituloForm.Text = "✏️ Editar Status";

            if (_status == null || _status.Count == 0)
            {
                // Sem status carregados: desabilita o combo em vez de deixar vazio "quieto".
                cmbStatus.DataSource = null;
                cmbStatus.Items.Clear();
                cmbStatus.Enabled = false;
                PreencherCampos();
                return;
            }

            // Liga o combo diretamente na lista de objetos (não em strings),
            // assim o SelectedItem já sai como OrderStatusResponseDto.
            cmbStatus.DisplayMember = nameof(OrderStatusResponseDto.Name);
            cmbStatus.ValueMember = nameof(OrderStatusResponseDto.Id);
            cmbStatus.DataSource = _status;
            cmbStatus.Enabled = true;

            PreencherCampos();
        }

        private void PreencherCampos()
        {
            if (_pedidoExistente == null) return;

            var idx = _status.FindIndex(c => c.Id == _pedidoExistente.StatusId);
            if (idx >= 0)
                cmbStatus.SelectedIndex = idx;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!cmbStatus.Enabled)
            {
                MessageBox.Show("Não há status disponíveis para selecionar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbStatus.SelectedItem is not OrderStatusResponseDto selecionado)
            {
                MessageBox.Show("Selecione um status válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateDto = new UpdateOrderStatusDto
            {
                Id = _pedidoExistente?.Id ?? 0,
                StatusId = selecionado.Id,
                Status = string.IsNullOrWhiteSpace(selecionado.Status) ? selecionado.Name : selecionado.Status
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();
    }
}