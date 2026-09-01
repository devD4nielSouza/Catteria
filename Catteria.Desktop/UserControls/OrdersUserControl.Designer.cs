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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtPesquisa = new Guna.UI2.WinForms.Guna2TextBox();
            btnEditar = new Guna.UI2.WinForms.Guna2Button();
            btnExcluir = new Guna.UI2.WinForms.Guna2Button();
            btnAtualizar = new Guna.UI2.WinForms.Guna2Button();
            lblTitulo = new Label();
            gridPedidos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colClient = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)gridPedidos).BeginInit();
            SuspendLayout();
            // 
            // txtPesquisa
            // 
            txtPesquisa.BorderRadius = 5;
            txtPesquisa.CustomizableEdges = customizableEdges1;
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
            txtPesquisa.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtPesquisa.Size = new Size(293, 36);
            txtPesquisa.TabIndex = 13;
            txtPesquisa.TextChanged += txtPesquisa_TextChanged;
            // 
            // btnEditar
            // 
            btnEditar.BorderRadius = 5;
            btnEditar.CustomizableEdges = customizableEdges3;
            btnEditar.DisabledState.BorderColor = Color.DarkGray;
            btnEditar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEditar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEditar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEditar.FillColor = Color.FromArgb(64, 162, 66);
            btnEditar.Font = new Font("Segoe UI", 9F);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(337, 63);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnEditar.Size = new Size(115, 45);
            btnEditar.TabIndex = 10;
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.BorderRadius = 5;
            btnExcluir.CustomizableEdges = customizableEdges5;
            btnExcluir.DisabledState.BorderColor = Color.DarkGray;
            btnExcluir.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExcluir.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExcluir.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExcluir.FillColor = Color.FromArgb(209, 73, 63);
            btnExcluir.Font = new Font("Segoe UI", 9F);
            btnExcluir.ForeColor = Color.White;
            btnExcluir.Location = new Point(458, 63);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnExcluir.Size = new Size(114, 45);
            btnExcluir.TabIndex = 11;
            btnExcluir.Text = "Excluir";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnAtualizar
            // 
            btnAtualizar.BorderRadius = 5;
            btnAtualizar.CustomizableEdges = customizableEdges7;
            btnAtualizar.DisabledState.BorderColor = Color.DarkGray;
            btnAtualizar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAtualizar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAtualizar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAtualizar.FillColor = Color.FromArgb(219, 209, 89);
            btnAtualizar.Font = new Font("Segoe UI", 9F);
            btnAtualizar.ForeColor = Color.White;
            btnAtualizar.Location = new Point(578, 63);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnAtualizar.Size = new Size(112, 45);
            btnAtualizar.TabIndex = 12;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.Click += btnAtualizar_Click;
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
            // gridPedidos
            // 
            gridPedidos.BackgroundColor = SystemColors.ActiveCaption;
            gridPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPedidos.Columns.AddRange(new DataGridViewColumn[] { colId, colDate, colPrice, colStatus, colClient });
            gridPedidos.GridColor = SystemColors.InactiveCaption;
            gridPedidos.Location = new Point(20, 114);
            gridPedidos.Name = "gridPedidos";
            gridPedidos.Size = new Size(670, 340);
            gridPedidos.TabIndex = 7;
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
            // colClient
            // 
            colClient.HeaderText = "Cliente";
            colClient.Name = "colClient";
            colClient.Width = 200;
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
            Controls.Add(gridPedidos);
            Name = "OrdersUserControl";
            Size = new Size(793, 482);
            Load += OrdersUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)gridPedidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtPesquisa;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnExcluir;
        private Guna.UI2.WinForms.Guna2Button btnAtualizar;
        private Label lblTitulo;
        private DataGridView gridPedidos;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colClient;
    }
}
