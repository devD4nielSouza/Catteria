using Catteria.Desktop.DTOs;
using Catteria.Desktop.Forms;
using Catteria.Desktop.Helpers;
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
        private List<OrderStatusResponseDto> _statusList = new();

        public OrdersUserControl()
        {
            InitializeComponent();
        }

        private async void OrdersUserControl_Load(object sender, EventArgs e)
        {
            // Cria o serviço que irá conversar com a API.
            _ordersService = new OrdersApiService();


            // carregar lista de status (ver método no service)
            _statusList = await _ordersService.GetStatusesAsync();

            // Carrega os pedidos.
            await CarregarDadosAsync();

            ConfigurarPermissoes();

        }

        /// <summary>
        /// Mostra/esconde os botões de acordo com o perfil do usuário logado,
        /// igual ao que é feito no ProductsUserControl. Aqui não existe "Novo"
        /// porque pedidos não são criados manualmente pela tela do Desktop.
        /// </summary>
        private void ConfigurarPermissoes()
        {
            bool isAdmin = SessionManager.Instance.IsAdmin;
            btnEditar.Visible = isAdmin;
            btnExcluir.Visible = isAdmin;
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

        private void FiltrarPedidos()
        {
            // Pega o texto digitado na pesquisa.
            string termo = txtPesquisa.Text.Trim();

            // Se não foi digitado nada, mostra todos os pedidos.
            if (string.IsNullOrEmpty(termo))
            {
                PopularGrid(_todosPedidos);
                return;
            }

            // Procura o termo nos campos do pedido.
            var pedidosFiltrados = _todosPedidos
                .Where(p =>
                    // ID do pedido
                    p.Id.ToString().Contains(termo, StringComparison.OrdinalIgnoreCase)

                    // Data
                    || p.Date.ToString("dd/MM/yyyy HH:mm")
                        .Contains(termo, StringComparison.OrdinalIgnoreCase)

                    // Valor
                    || p.TotalValue.ToString("C2")
                        .Contains(termo, StringComparison.OrdinalIgnoreCase)

                    // Status
                    || (p.Status ?? "")
                        .Contains(termo, StringComparison.OrdinalIgnoreCase)

                    // Nome do cliente
                    || (p.CustomerName ?? "")
                        .Contains(termo, StringComparison.OrdinalIgnoreCase)
                )
                .ToList();

            // Mostra somente os pedidos encontrados.
            PopularGrid(pedidosFiltrados);
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e) => FiltrarPedidos();

        private OrdersResponseDto? ObterPedidoSelecionado()
        {
            if (gridPedidos.SelectedRows.Count == 0) return null;
            var row = gridPedidos.SelectedRows[0];
            var id = Convert.ToInt32(row.Cells["colId"].Value); // ajuste o nome da coluna se for diferente
            return _todosPedidos.FirstOrDefault(p => p.Id == id);
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            var pedido = ObterPedidoSelecionado();
            if (pedido == null)
            {
                MessageBox.Show("Selecione um pedido para editar",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Dialog simples que só deixa escolher o novo status (ver OrderStatusFormDialog).
            using var form = new OrderFormDialog(_statusList, pedido);
            if (form.ShowDialog() == DialogResult.OK && form.UpdateDto != null)
            {
                // Mapear para o DTO que o OrdersApiService espera (ex.: UpdateOrderDto)
                var updateDto = new UpdateOrderDto
                {
                    Status = form.UpdateDto.Status // ajuste conforme nomes reais
                };
                var (success, errorUpd, error) = await _ordersService.UpdateAsync(pedido.Id, updateDto);
                if (success)
                {
                    MessageBox.Show("Status do pedido atualizado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    await CarregarDadosAsync();
                }
                else
                {
                    MessageBox.Show($"{error}", "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            var pedido = ObterPedidoSelecionado();
            if (pedido == null)
            {
                MessageBox.Show("Selecione um pedido para excluir.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var conf = MessageBox.Show(
                $"Tem certeza que deseja excluir o pedido \"{pedido.Id}\"?",
                "Confirmar Exclusão", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (conf != DialogResult.Yes) return;

            var (success, error) = await _ordersService.DeleteAsync(pedido.Id);
            if (success)
            {
                MessageBox.Show("Pedido excluído com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CarregarDadosAsync();
            }
            else
            {
                MessageBox.Show($"{error}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAtualizar_Click(object sender, EventArgs e) => await CarregarDadosAsync();
    }

}


