namespace Catteria.Desktop.UserControls
{
    partial class CupomUserControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtPesquisa = new Guna.UI2.WinForms.Guna2TextBox();
            btnEditar = new Guna.UI2.WinForms.Guna2Button();
            btnDesabilitar = new Guna.UI2.WinForms.Guna2Button();
            btnAtualizar = new Guna.UI2.WinForms.Guna2Button();
            lblTitulo = new Label();
            gridPedidos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colClient = new DataGridViewTextBoxColumn();
            btnNovo = new Guna.UI2.WinForms.Guna2Button();
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
            txtPesquisa.Location = new Point(15, 85);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.PlaceholderForeColor = Color.Gray;
            txtPesquisa.PlaceholderText = "Pesquisa por nome";
            txtPesquisa.SelectedText = "";
            txtPesquisa.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtPesquisa.Size = new Size(284, 36);
            txtPesquisa.TabIndex = 19;
            // 
            // btnEditar
            // 
            btnEditar.BorderRadius = 5;
            btnEditar.CustomizableEdges = customizableEdges3;
            btnEditar.DisabledState.BorderColor = Color.DarkGray;
            btnEditar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEditar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEditar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEditar.FillColor = Color.FromArgb(53, 109, 202);
            btnEditar.Font = new Font("Segoe UI", 9F);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(431, 76);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnEditar.Size = new Size(106, 45);
            btnEditar.TabIndex = 16;
            btnEditar.Text = "✏️ Editar";
            // 
            // btnDesabilitar
            // 
            btnDesabilitar.BorderRadius = 5;
            btnDesabilitar.CustomizableEdges = customizableEdges5;
            btnDesabilitar.DisabledState.BorderColor = Color.DarkGray;
            btnDesabilitar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDesabilitar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDesabilitar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDesabilitar.FillColor = Color.FromArgb(223, 77, 72);
            btnDesabilitar.Font = new Font("Segoe UI", 9F);
            btnDesabilitar.ForeColor = Color.White;
            btnDesabilitar.Location = new Point(554, 76);
            btnDesabilitar.Name = "btnDesabilitar";
            btnDesabilitar.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnDesabilitar.Size = new Size(105, 45);
            btnDesabilitar.TabIndex = 17;
            btnDesabilitar.Text = "🗑️ Desabilitar";
            btnDesabilitar.Click += btnExcluir_Click;
            // 
            // btnAtualizar
            // 
            btnAtualizar.BorderRadius = 5;
            btnAtualizar.CustomizableEdges = customizableEdges7;
            btnAtualizar.DisabledState.BorderColor = Color.DarkGray;
            btnAtualizar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAtualizar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAtualizar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAtualizar.FillColor = Color.FromArgb(199, 209, 69);
            btnAtualizar.Font = new Font("Segoe UI", 9F);
            btnAtualizar.ForeColor = Color.White;
            btnAtualizar.Location = new Point(678, 76);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnAtualizar.Size = new Size(101, 45);
            btnAtualizar.TabIndex = 18;
            btnAtualizar.Text = "🔄️ Atualizar";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitulo.Location = new Point(15, 27);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(249, 25);
            lblTitulo.TabIndex = 15;
            lblTitulo.Text = "Gerenciador de Cupons 🎟️";
            // 
            // gridPedidos
            // 
            gridPedidos.BackgroundColor = SystemColors.ActiveCaption;
            gridPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPedidos.Columns.AddRange(new DataGridViewColumn[] { colId, colDate, colPrice, colStatus, colClient });
            gridPedidos.GridColor = SystemColors.InactiveCaption;
            gridPedidos.Location = new Point(15, 136);
            gridPedidos.Name = "gridPedidos";
            gridPedidos.Size = new Size(764, 332);
            gridPedidos.TabIndex = 14;
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
            colDate.Width = 200;
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
            colStatus.Width = 140;
            // 
            // colClient
            // 
            colClient.HeaderText = "Cliente";
            colClient.Name = "colClient";
            colClient.Width = 200;
            // 
            // btnNovo
            // 
            btnNovo.BorderRadius = 5;
            btnNovo.CustomizableEdges = customizableEdges9;
            btnNovo.DisabledState.BorderColor = Color.DarkGray;
            btnNovo.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNovo.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNovo.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNovo.FillColor = Color.FromArgb(47, 179, 77);
            btnNovo.Font = new Font("Segoe UI", 9F);
            btnNovo.ForeColor = Color.White;
            btnNovo.Location = new Point(305, 76);
            btnNovo.Name = "btnNovo";
            btnNovo.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnNovo.Size = new Size(106, 45);
            btnNovo.TabIndex = 16;
            btnNovo.Text = "+ Novo Cupom";
            // 
            // CupomUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 248, 241);
            Controls.Add(txtPesquisa);
            Controls.Add(btnNovo);
            Controls.Add(btnEditar);
            Controls.Add(btnDesabilitar);
            Controls.Add(btnAtualizar);
            Controls.Add(lblTitulo);
            Controls.Add(gridPedidos);
            Name = "CupomUserControl";
            Size = new Size(793, 482);
            Load += CupomUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)gridPedidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtPesquisa;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnDesabilitar;
        private Guna.UI2.WinForms.Guna2Button btnAtualizar;
        private Label lblTitulo;
        private DataGridView gridPedidos;
        private Guna.UI2.WinForms.Guna2Button btnNovo;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colClient;
    }
}
