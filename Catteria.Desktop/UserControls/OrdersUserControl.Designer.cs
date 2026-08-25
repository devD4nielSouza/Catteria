namespace Catteria.Desktop.UserControls
{
    partial class OrdersUserControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtPesquisa = new Guna.UI2.WinForms.Guna2TextBox();
            btnEditar = new Guna.UI2.WinForms.Guna2Button();
            btnExcluir = new Guna.UI2.WinForms.Guna2Button();
            btnAtualizar = new Guna.UI2.WinForms.Guna2Button();
            lblTitulo = new Label();
            gridProdutos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colPayment = new DataGridViewTextBoxColumn();
            colObservation = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)gridProdutos).BeginInit();
            SuspendLayout();
            // 
            // txtPesquisa
            // 
            txtPesquisa.BorderRadius = 5;
            txtPesquisa.CustomizableEdges = customizableEdges9;
            txtPesquisa.DefaultText = "";
            txtPesquisa.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPesquisa.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPesquisa.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPesquisa.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPesquisa.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPesquisa.Font = new Font("Segoe UI", 9F);
            txtPesquisa.ForeColor = Color.DimGray;
            txtPesquisa.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPesquisa.Location = new Point(20, 72);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.PlaceholderForeColor = Color.Gray;
            txtPesquisa.PlaceholderText = "Pesquisa por nome";
            txtPesquisa.SelectedText = "";
            txtPesquisa.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtPesquisa.Size = new Size(293, 36);
            txtPesquisa.TabIndex = 13;
            // 
            // btnEditar
            // 
            btnEditar.BorderRadius = 5;
            btnEditar.CustomizableEdges = customizableEdges11;
            btnEditar.DisabledState.BorderColor = Color.DarkGray;
            btnEditar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEditar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEditar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEditar.FillColor = Color.FromArgb(64, 162, 66);
            btnEditar.Font = new Font("Segoe UI", 9F);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(390, 63);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnEditar.Size = new Size(115, 45);
            btnEditar.TabIndex = 10;
            btnEditar.Text = "Editar";
            // 
            // btnExcluir
            // 
            btnExcluir.BorderRadius = 5;
            btnExcluir.CustomizableEdges = customizableEdges13;
            btnExcluir.DisabledState.BorderColor = Color.DarkGray;
            btnExcluir.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExcluir.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExcluir.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExcluir.FillColor = Color.FromArgb(209, 73, 63);
            btnExcluir.Font = new Font("Segoe UI", 9F);
            btnExcluir.ForeColor = Color.White;
            btnExcluir.Location = new Point(511, 63);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnExcluir.Size = new Size(114, 45);
            btnExcluir.TabIndex = 11;
            btnExcluir.Text = "Excluir";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnAtualizar
            // 
            btnAtualizar.BorderRadius = 5;
            btnAtualizar.CustomizableEdges = customizableEdges15;
            btnAtualizar.DisabledState.BorderColor = Color.DarkGray;
            btnAtualizar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAtualizar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAtualizar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAtualizar.FillColor = Color.FromArgb(219, 209, 89);
            btnAtualizar.Font = new Font("Segoe UI", 9F);
            btnAtualizar.ForeColor = Color.White;
            btnAtualizar.Location = new Point(631, 63);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnAtualizar.Size = new Size(112, 45);
            btnAtualizar.TabIndex = 12;
            btnAtualizar.Text = "Atualizar";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitulo.Location = new Point(14, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(251, 25);
            lblTitulo.TabIndex = 8;
            lblTitulo.Text = "Gerenciador de Pedidos 📩";
            // 
            // gridProdutos
            // 
            gridProdutos.BackgroundColor = SystemColors.ActiveCaption;
            gridProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridProdutos.Columns.AddRange(new DataGridViewColumn[] { colId, colDate, colPrice, colStatus, colPayment, colObservation });
            gridProdutos.GridColor = SystemColors.InactiveCaption;
            gridProdutos.Location = new Point(3, 120);
            gridProdutos.Name = "gridProdutos";
            gridProdutos.Size = new Size(787, 340);
            gridProdutos.TabIndex = 7;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.Width = 80;
            // 
            // colDate
            // 
            colDate.HeaderText = "DataPedido";
            colDate.Name = "colDate";
            colDate.Width = 120;
            // 
            // colPrice
            // 
            colPrice.HeaderText = "Valor Total";
            colPrice.Name = "colPrice";
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.Width = 110;
            // 
            // colPayment
            // 
            colPayment.HeaderText = "MetodoPagamento";
            colPayment.Name = "colPayment";
            colPayment.Width = 134;
            // 
            // colObservation
            // 
            colObservation.HeaderText = "Observação";
            colObservation.Name = "colObservation";
            colObservation.Width = 200;
            // 
            // OrdersUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtPesquisa);
            Controls.Add(btnEditar);
            Controls.Add(btnExcluir);
            Controls.Add(btnAtualizar);
            Controls.Add(lblTitulo);
            Controls.Add(gridProdutos);
            Name = "OrdersUserControl";
            Size = new Size(793, 482);
            ((System.ComponentModel.ISupportInitialize)gridProdutos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtPesquisa;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnExcluir;
        private Guna.UI2.WinForms.Guna2Button btnAtualizar;
        private Label lblTitulo;
        private DataGridView gridProdutos;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colPayment;
        private DataGridViewTextBoxColumn colObservation;
    }
}
