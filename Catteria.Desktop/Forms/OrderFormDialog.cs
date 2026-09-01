using Catteria.Desktop.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Catteria.Desktop.Forms
{
    public partial class OrderFormDialog : Form
    {
        public UpdateOrderStatusDto? UpdateDto { get; private set; }
        private List<OrderStatusResponseDto> _status = new();
        private OrdersResponseDto? _orderExistente;
        public OrderFormDialog()
        {
            InitializeComponent();
        }

        public OrderFormDialog(List<OrderStatusResponseDto> status, OrdersResponseDto? pedidos)
        {
            _status = status;
            _orderExistente = pedidos;
            InitializeComponent();
        }

        private void OrderFormDialog_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            // Configura título baseado no modo (criação/edição)
            this.Text = "Editar Status";
            lblTituloForm.Text = "✏️ Editar Status";

            //Popula o ComboBox de categorias
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Selecione uma categoria...");
            foreach (var stat in _status)
                cmbStatus.Items.Add(stat.StatusId);
            cmbStatus.SelectedIndex = 0;

            //Preenche campos se estiver no modo edição
            PreencherCampos();
        }

        private void PreencherCampos()
        {
            if (_orderExistente == null) return;

            var idx = _status.FindIndex(s => s.StatusId == _orderExistente.StatusId);
            if (idx >= 0) cmbStatus.SelectedIndex = idx + 1;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var statusIdx = cmbStatus.SelectedIndex - 1;
            var statusId = _status[statusIdx].Id;
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();

    }
}
