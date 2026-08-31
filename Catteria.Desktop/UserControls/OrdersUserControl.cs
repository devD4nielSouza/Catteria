using Catteria.Desktop.DTOs;
using Catteria.Desktop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Catteria.Desktop.UserControls
{
    public partial class OrdersUserControl : UserControl
    {
        // =====================================================================
        // SERVIÇO E DADOS
        // =====================================================================

        /// <summary>
        /// Serviço responsável por conversar com a API de pedidos.
        /// </summary>
        private OrdersApiService _ordersService = null!;

        /// <summary>
        /// Lista com todos os pedidos carregados da API.
        /// </summary>
        private List<OrdersResponseDto> _todosPedidos = new();

        public OrdersUserControl()
        {
            InitializeComponent();
        }

        private async void OrdersUserControl_Load(object sender, EventArgs e)
        {
            // Cria o serviço que irá conversar com a API.
            _ordersService = new OrdersApiService();

            // Carrega os pedidos.
            await CarregarDadosAsync();
        }


        /// <summary>
        /// Busca os pedidos na API e coloca os dados no grid.
        /// </summary>
        private async Task CarregarDadosAsync()
        {
            // Limpa as linhas antigas.
            gridPedidos.Rows.Clear();

            try
            {
                // Busca todos os pedidos através da API.
                _todosPedidos = await _ordersService.GetAllAsync();

                // Coloca os pedidos no grid.
                PopularGrid(_todosPedidos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao carregar pedidos: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // POPULAR GRID
        // =====================================================================

        /// <summary>
        /// Mostra uma lista de pedidos no DataGridView.
        /// </summary>
        private void PopularGrid(List<OrdersResponseDto> pedidos)
        {
            gridPedidos.Rows.Clear();

            foreach (var pedido in pedidos)
            {
                gridPedidos.Rows.Add(
                    pedido.Id,
                    pedido.Date.ToString("dd/MM/yyyy HH:mm"),
                    pedido.TotalValue.ToString("C2"),
                    pedido.Status,
                    pedido.IdUser
                );
            }
        }



    }
    
}
