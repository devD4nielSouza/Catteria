namespace Catteria.Desktop.UserControls
{
    partial class CategoriesUserControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlForm = new Guna.UI2.WinForms.Guna2Panel();
            btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            btnSalvar = new Guna.UI2.WinForms.Guna2Button();
            txtNome = new Guna.UI2.WinForms.Guna2TextBox();
            lblNome = new Label();
            lblFormTitulo = new Label();
            gridCategorias = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colProductCount = new DataGridViewTextBoxColumn();
            pnlToolbar = new Panel();
            btnAtualizar = new Guna.UI2.WinForms.Guna2Button();
            btnExcluir = new Guna.UI2.WinForms.Guna2Button();
            btnEditar = new Guna.UI2.WinForms.Guna2Button();
            btnNova = new Guna.UI2.WinForms.Guna2Button();
            lblTitulo = new Label();
            pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridCategorias).BeginInit();
            pnlToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlForm
            // 
            pnlForm.BackColor = Color.White;
            pnlForm.BorderRadius = 10;
            pnlForm.Controls.Add(btnCancelar);
            pnlForm.Controls.Add(btnSalvar);
            pnlForm.Controls.Add(txtNome);
            pnlForm.Controls.Add(lblNome);
            pnlForm.Controls.Add(lblFormTitulo);
            pnlForm.CustomizableEdges = customizableEdges7;
            pnlForm.Location = new Point(575, 227);
            pnlForm.Name = "pnlForm";
            pnlForm.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnlForm.Size = new Size(200, 246);
            pnlForm.TabIndex = 8;
            pnlForm.Visible = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BorderRadius = 5;
            btnCancelar.CustomizableEdges = customizableEdges1;
            btnCancelar.DisabledState.BorderColor = Color.DarkGray;
            btnCancelar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancelar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancelar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancelar.FillColor = Color.Gray;
            btnCancelar.Font = new Font("Segoe UI", 9F);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(106, 123);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnCancelar.Size = new Size(91, 31);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "❌ Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.BorderRadius = 5;
            btnSalvar.CustomizableEdges = customizableEdges3;
            btnSalvar.DisabledState.BorderColor = Color.DarkGray;
            btnSalvar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSalvar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSalvar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSalvar.FillColor = Color.FromArgb(47, 179, 77);
            btnSalvar.Font = new Font("Segoe UI", 9F);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.Location = new Point(3, 123);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSalvar.Size = new Size(98, 31);
            btnSalvar.TabIndex = 2;
            btnSalvar.Text = "💾 Salvar";
            btnSalvar.Click += btnSalvar_Click;
            // 
            // txtNome
            // 
            txtNome.BorderRadius = 10;
            txtNome.CustomizableEdges = customizableEdges5;
            txtNome.DefaultText = "";
            txtNome.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtNome.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtNome.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtNome.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtNome.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNome.Font = new Font("Segoe UI", 9F);
            txtNome.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNome.Location = new Point(3, 81);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Ex: Doces, Salgados..";
            txtNome.SelectedText = "";
            txtNome.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtNome.Size = new Size(194, 36);
            txtNome.TabIndex = 1;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNome.Location = new Point(16, 55);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(115, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome da categoria:";
            // 
            // lblFormTitulo
            // 
            lblFormTitulo.AutoSize = true;
            lblFormTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFormTitulo.ForeColor = Color.FromArgb(39, 86, 118);
            lblFormTitulo.Location = new Point(16, 18);
            lblFormTitulo.Name = "lblFormTitulo";
            lblFormTitulo.Size = new Size(129, 21);
            lblFormTitulo.TabIndex = 0;
            lblFormTitulo.Text = "Nova Categoria";
            // 
            // gridCategorias
            // 
            gridCategorias.BackgroundColor = SystemColors.ActiveCaption;
            gridCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCategorias.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colProductCount });
            gridCategorias.Location = new Point(17, 155);
            gridCategorias.Name = "gridCategorias";
            gridCategorias.Size = new Size(552, 318);
            gridCategorias.TabIndex = 7;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.Name = "colId";
            // 
            // colName
            // 
            colName.HeaderText = "Nome da Categoria";
            colName.Name = "colName";
            colName.Width = 225;
            // 
            // colProductCount
            // 
            colProductCount.HeaderText = "Total de Produtos";
            colProductCount.Name = "colProductCount";
            // 
            // pnlToolbar
            // 
            pnlToolbar.Controls.Add(btnAtualizar);
            pnlToolbar.Controls.Add(btnExcluir);
            pnlToolbar.Controls.Add(btnEditar);
            pnlToolbar.Controls.Add(btnNova);
            pnlToolbar.Location = new Point(17, 49);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(552, 100);
            pnlToolbar.TabIndex = 6;
            // 
            // btnAtualizar
            // 
            btnAtualizar.BorderRadius = 10;
            btnAtualizar.CustomizableEdges = customizableEdges9;
            btnAtualizar.DisabledState.BorderColor = Color.DarkGray;
            btnAtualizar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAtualizar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAtualizar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAtualizar.FillColor = Color.FromArgb(199, 209, 69);
            btnAtualizar.Font = new Font("Segoe UI", 9F);
            btnAtualizar.ForeColor = Color.White;
            btnAtualizar.Location = new Point(415, 25);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnAtualizar.Size = new Size(108, 45);
            btnAtualizar.TabIndex = 1;
            btnAtualizar.Text = "🔄️ Atualizar";
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.BorderRadius = 10;
            btnExcluir.CustomizableEdges = customizableEdges11;
            btnExcluir.DisabledState.BorderColor = Color.DarkGray;
            btnExcluir.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExcluir.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExcluir.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExcluir.FillColor = Color.FromArgb(223, 77, 72);
            btnExcluir.Font = new Font("Segoe UI", 9F);
            btnExcluir.ForeColor = Color.White;
            btnExcluir.Location = new Point(268, 25);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnExcluir.Size = new Size(108, 45);
            btnExcluir.TabIndex = 1;
            btnExcluir.Text = "🗑️ Excluir";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.BorderRadius = 10;
            btnEditar.CustomizableEdges = customizableEdges13;
            btnEditar.DisabledState.BorderColor = Color.DarkGray;
            btnEditar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEditar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEditar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEditar.FillColor = Color.FromArgb(53, 109, 202);
            btnEditar.Font = new Font("Segoe UI", 9F);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(138, 25);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnEditar.Size = new Size(108, 45);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "✏️ Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnNova
            // 
            btnNova.BorderRadius = 10;
            btnNova.CustomizableEdges = customizableEdges15;
            btnNova.DisabledState.BorderColor = Color.DarkGray;
            btnNova.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNova.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNova.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNova.FillColor = Color.FromArgb(47, 179, 77);
            btnNova.Font = new Font("Segoe UI", 9F);
            btnNova.ForeColor = Color.White;
            btnNova.Location = new Point(7, 25);
            btnNova.Name = "btnNova";
            btnNova.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnNova.Size = new Size(108, 45);
            btnNova.TabIndex = 1;
            btnNova.Text = "+ Nova Categoria";
            btnNova.Click += btnNova_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblTitulo.ForeColor = SystemColors.ControlDarkDark;
            lblTitulo.Location = new Point(17, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(301, 25);
            lblTitulo.TabIndex = 5;
            lblTitulo.Text = "🏷️ Gerenciamento de Categorias";
            // 
            // CategoriesUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 248, 241);
            Controls.Add(pnlForm);
            Controls.Add(gridCategorias);
            Controls.Add(pnlToolbar);
            Controls.Add(lblTitulo);
            Name = "CategoriesUserControl";
            Size = new Size(793, 482);
            Load += CategoriesUserControl_Load;
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridCategorias).EndInit();
            pnlToolbar.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlForm;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private Guna.UI2.WinForms.Guna2Button btnSalvar;
        private Guna.UI2.WinForms.Guna2TextBox txtNome;
        private Label lblNome;
        private Label lblFormTitulo;
        private DataGridView gridCategorias;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colProductCount;
        private Panel pnlToolbar;
        private Guna.UI2.WinForms.Guna2Button btnAtualizar;
        private Guna.UI2.WinForms.Guna2Button btnExcluir;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnNova;
        private Label lblTitulo;
    }
}
