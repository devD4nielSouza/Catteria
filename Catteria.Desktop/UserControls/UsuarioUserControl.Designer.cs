namespace Catteria.Desktop.UserControls
{
    partial class UsuarioUserControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gridUsuarios = new DataGridView();
            pnlToolbar = new Panel();
            txtPesquisa = new Guna.UI2.WinForms.Guna2TextBox();
            btnNovo = new Guna.UI2.WinForms.Guna2Button();
            btnAtualizar = new Guna.UI2.WinForms.Guna2Button();
            btnEditar = new Guna.UI2.WinForms.Guna2Button();
            btnExcluir = new Guna.UI2.WinForms.Guna2Button();
            lblTitulo = new Label();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colAddress = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)gridUsuarios).BeginInit();
            pnlToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // gridUsuarios
            // 
            gridUsuarios.BackgroundColor = Color.FromArgb(164, 188, 233);
            gridUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridUsuarios.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colEmail, colPhone, colType, colAddress });
            gridUsuarios.Location = new Point(14, 154);
            gridUsuarios.Name = "gridUsuarios";
            gridUsuarios.Size = new Size(764, 313);
            gridUsuarios.TabIndex = 0;
            // 
            // pnlToolbar
            // 
            pnlToolbar.Controls.Add(txtPesquisa);
            pnlToolbar.Controls.Add(btnNovo);
            pnlToolbar.Controls.Add(btnAtualizar);
            pnlToolbar.Controls.Add(btnEditar);
            pnlToolbar.Controls.Add(btnExcluir);
            pnlToolbar.Location = new Point(14, 70);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(764, 78);
            pnlToolbar.TabIndex = 2;
            // 
            // txtPesquisa
            // 
            txtPesquisa.BorderRadius = 5;
            txtPesquisa.CustomizableEdges = customizableEdges11;
            txtPesquisa.DefaultText = "";
            txtPesquisa.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPesquisa.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPesquisa.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPesquisa.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPesquisa.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPesquisa.Font = new Font("Segoe UI", 9F);
            txtPesquisa.ForeColor = Color.DimGray;
            txtPesquisa.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPesquisa.Location = new Point(13, 24);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.PlaceholderForeColor = Color.Gray;
            txtPesquisa.PlaceholderText = "Pesquisa por nome";
            txtPesquisa.SelectedText = "";
            txtPesquisa.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtPesquisa.Size = new Size(205, 36);
            txtPesquisa.TabIndex = 11;
            // 
            // btnNovo
            // 
            btnNovo.BorderRadius = 5;
            btnNovo.CustomizableEdges = customizableEdges13;
            btnNovo.DisabledState.BorderColor = Color.DarkGray;
            btnNovo.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNovo.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNovo.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNovo.FillColor = Color.FromArgb(87, 97, 213);
            btnNovo.Font = new Font("Segoe UI", 9F);
            btnNovo.ForeColor = Color.White;
            btnNovo.Location = new Point(233, 15);
            btnNovo.Name = "btnNovo";
            btnNovo.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnNovo.Size = new Size(107, 45);
            btnNovo.TabIndex = 7;
            btnNovo.Text = "Novo Usuário";
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
            btnAtualizar.Location = new Point(614, 15);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnAtualizar.Size = new Size(112, 45);
            btnAtualizar.TabIndex = 10;
            btnAtualizar.Text = "Atualizar";
            // 
            // btnEditar
            // 
            btnEditar.BorderRadius = 5;
            btnEditar.CustomizableEdges = customizableEdges17;
            btnEditar.DisabledState.BorderColor = Color.DarkGray;
            btnEditar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEditar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEditar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEditar.FillColor = Color.FromArgb(64, 162, 66);
            btnEditar.Font = new Font("Segoe UI", 9F);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(358, 15);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnEditar.Size = new Size(115, 45);
            btnEditar.TabIndex = 8;
            btnEditar.Text = "Editar";
            // 
            // btnExcluir
            // 
            btnExcluir.BorderRadius = 5;
            btnExcluir.CustomizableEdges = customizableEdges19;
            btnExcluir.DisabledState.BorderColor = Color.DarkGray;
            btnExcluir.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExcluir.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExcluir.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExcluir.FillColor = Color.FromArgb(209, 73, 63);
            btnExcluir.Font = new Font("Segoe UI", 9F);
            btnExcluir.ForeColor = Color.White;
            btnExcluir.Location = new Point(489, 15);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnExcluir.Size = new Size(114, 45);
            btnExcluir.TabIndex = 9;
            btnExcluir.Text = "Excluir";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitulo.Location = new Point(14, 21);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(258, 25);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "Gerenciador de Usuários 👤";
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.Width = 50;
            // 
            // colName
            // 
            colName.HeaderText = "Nome";
            colName.Name = "colName";
            colName.Width = 150;
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.Name = "colEmail";
            colEmail.Width = 150;
            // 
            // colPhone
            // 
            colPhone.HeaderText = "Telefone";
            colPhone.Name = "colPhone";
            colPhone.Width = 140;
            // 
            // colType
            // 
            colType.HeaderText = "Tipo";
            colType.Name = "colType";
            // 
            // colAddress
            // 
            colAddress.HeaderText = "Endereço";
            colAddress.Name = "colAddress";
            colAddress.Width = 130;
            // 
            // UsuarioUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(253, 247, 242);
            Controls.Add(lblTitulo);
            Controls.Add(pnlToolbar);
            Controls.Add(gridUsuarios);
            ForeColor = SystemColors.ControlText;
            Name = "UsuarioUserControl";
            Size = new Size(793, 482);
            ((System.ComponentModel.ISupportInitialize)gridUsuarios).EndInit();
            pnlToolbar.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridUsuarios;
        private Panel pnlToolbar;
        private Guna.UI2.WinForms.Guna2TextBox txtPesquisa;
        private Guna.UI2.WinForms.Guna2Button btnNovo;
        private Guna.UI2.WinForms.Guna2Button btnAtualizar;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnExcluir;
        private Label lblTitulo;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colAddress;
    }
}
