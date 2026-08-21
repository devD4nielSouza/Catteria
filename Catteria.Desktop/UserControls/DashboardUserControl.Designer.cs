namespace Catteria.Desktop.UserControls
{
    partial class DashboardUserControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            cardCategorias = new Panel();
            cardCategoriasLblNumero = new Label();
            cardCategoriasLblTitulo = new Label();
            cardCategoriasLblDesc = new Label();
            gridUltimosProdutos = new DataGridView();
            lblTitulo = new Label();
            lblSubTitulo = new Label();
            pnlCorCategorias = new Guna.UI2.WinForms.Guna2Panel();
            cardProdutos = new Panel();
            cardProdutosLblNumero = new Label();
            cardProdutosLblTitulo = new Label();
            cardProdutosLblDesc = new Label();
            pnlCorProdutos = new Guna.UI2.WinForms.Guna2Panel();
            lblUltimosProdutos = new Label();
            cardCategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridUltimosProdutos).BeginInit();
            cardProdutos.SuspendLayout();
            SuspendLayout();
            // 
            // cardCategorias
            // 
            cardCategorias.BackColor = Color.FromArgb(255, 248, 241);
            cardCategorias.Controls.Add(cardCategoriasLblNumero);
            cardCategorias.Controls.Add(cardCategoriasLblTitulo);
            cardCategorias.Controls.Add(cardCategoriasLblDesc);
            cardCategorias.Location = new Point(346, 59);
            cardCategorias.Name = "cardCategorias";
            cardCategorias.Size = new Size(253, 166);
            cardCategorias.TabIndex = 0;
            // 
            // cardCategoriasLblNumero
            // 
            cardCategoriasLblNumero.AutoSize = true;
            cardCategoriasLblNumero.BackColor = Color.FromArgb(255, 248, 241);
            cardCategoriasLblNumero.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cardCategoriasLblNumero.Location = new Point(31, 62);
            cardCategoriasLblNumero.Name = "cardCategoriasLblNumero";
            cardCategoriasLblNumero.Size = new Size(38, 45);
            cardCategoriasLblNumero.TabIndex = 5;
            cardCategoriasLblNumero.Text = "0";
            // 
            // cardCategoriasLblTitulo
            // 
            cardCategoriasLblTitulo.AutoSize = true;
            cardCategoriasLblTitulo.BackColor = Color.FromArgb(255, 248, 241);
            cardCategoriasLblTitulo.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            cardCategoriasLblTitulo.ForeColor = Color.FromArgb(164, 188, 233);
            cardCategoriasLblTitulo.Location = new Point(25, 43);
            cardCategoriasLblTitulo.Name = "cardCategoriasLblTitulo";
            cardCategoriasLblTitulo.Size = new Size(117, 19);
            cardCategoriasLblTitulo.TabIndex = 4;
            cardCategoriasLblTitulo.Text = "🏷️ Categorias";
            // 
            // cardCategoriasLblDesc
            // 
            cardCategoriasLblDesc.AutoSize = true;
            cardCategoriasLblDesc.BackColor = Color.FromArgb(255, 248, 241);
            cardCategoriasLblDesc.Font = new Font("Century Gothic", 8.25F);
            cardCategoriasLblDesc.ForeColor = SystemColors.ControlDarkDark;
            cardCategoriasLblDesc.Location = new Point(31, 107);
            cardCategoriasLblDesc.Name = "cardCategoriasLblDesc";
            cardCategoriasLblDesc.Size = new Size(111, 16);
            cardCategoriasLblDesc.TabIndex = 3;
            cardCategoriasLblDesc.Text = "Total de categorias";
            // 
            // gridUltimosProdutos
            // 
            gridUltimosProdutos.BackgroundColor = Color.FromArgb(164, 188, 233);
            gridUltimosProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridUltimosProdutos.Location = new Point(24, 260);
            gridUltimosProdutos.Name = "gridUltimosProdutos";
            gridUltimosProdutos.Size = new Size(671, 215);
            gridUltimosProdutos.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitulo.Location = new Point(24, 5);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(47, 25);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Olá!";
            // 
            // lblSubTitulo
            // 
            lblSubTitulo.AutoSize = true;
            lblSubTitulo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubTitulo.ForeColor = SystemColors.ControlDarkDark;
            lblSubTitulo.Location = new Point(24, 29);
            lblSubTitulo.Name = "lblSubTitulo";
            lblSubTitulo.Size = new Size(209, 17);
            lblSubTitulo.TabIndex = 3;
            lblSubTitulo.Text = "Bem-vindo ao Desktop da Catteria";
            // 
            // pnlCorCategorias
            // 
            pnlCorCategorias.CustomizableEdges = customizableEdges13;
            pnlCorCategorias.FillColor = Color.FromArgb(164, 188, 233);
            pnlCorCategorias.Location = new Point(346, 59);
            pnlCorCategorias.Name = "pnlCorCategorias";
            pnlCorCategorias.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pnlCorCategorias.Size = new Size(253, 18);
            pnlCorCategorias.TabIndex = 6;
            // 
            // cardProdutos
            // 
            cardProdutos.BackColor = Color.FromArgb(255, 248, 241);
            cardProdutos.Controls.Add(cardProdutosLblNumero);
            cardProdutos.Controls.Add(cardProdutosLblTitulo);
            cardProdutos.Controls.Add(cardProdutosLblDesc);
            cardProdutos.Location = new Point(24, 59);
            cardProdutos.Name = "cardProdutos";
            cardProdutos.Size = new Size(267, 166);
            cardProdutos.TabIndex = 0;
            // 
            // cardProdutosLblNumero
            // 
            cardProdutosLblNumero.AutoSize = true;
            cardProdutosLblNumero.BackColor = Color.FromArgb(255, 248, 241);
            cardProdutosLblNumero.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cardProdutosLblNumero.Location = new Point(31, 62);
            cardProdutosLblNumero.Name = "cardProdutosLblNumero";
            cardProdutosLblNumero.Size = new Size(38, 45);
            cardProdutosLblNumero.TabIndex = 5;
            cardProdutosLblNumero.Text = "0";
            // 
            // cardProdutosLblTitulo
            // 
            cardProdutosLblTitulo.AutoSize = true;
            cardProdutosLblTitulo.BackColor = Color.FromArgb(255, 248, 241);
            cardProdutosLblTitulo.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            cardProdutosLblTitulo.ForeColor = Color.FromArgb(76, 120, 178);
            cardProdutosLblTitulo.Location = new Point(31, 43);
            cardProdutosLblTitulo.Name = "cardProdutosLblTitulo";
            cardProdutosLblTitulo.Size = new Size(94, 19);
            cardProdutosLblTitulo.TabIndex = 4;
            cardProdutosLblTitulo.Text = "📦Produtos";
            // 
            // cardProdutosLblDesc
            // 
            cardProdutosLblDesc.AutoSize = true;
            cardProdutosLblDesc.BackColor = Color.FromArgb(255, 248, 241);
            cardProdutosLblDesc.Font = new Font("Century Gothic", 8.25F);
            cardProdutosLblDesc.ForeColor = SystemColors.ControlDarkDark;
            cardProdutosLblDesc.Location = new Point(31, 107);
            cardProdutosLblDesc.Name = "cardProdutosLblDesc";
            cardProdutosLblDesc.Size = new Size(102, 16);
            cardProdutosLblDesc.TabIndex = 3;
            cardProdutosLblDesc.Text = "Total de produtos";
            // 
            // pnlCorProdutos
            // 
            pnlCorProdutos.CustomizableEdges = customizableEdges15;
            pnlCorProdutos.FillColor = Color.FromArgb(76, 120, 178);
            pnlCorProdutos.Location = new Point(24, 59);
            pnlCorProdutos.Name = "pnlCorProdutos";
            pnlCorProdutos.ShadowDecoration.CustomizableEdges = customizableEdges16;
            pnlCorProdutos.Size = new Size(267, 18);
            pnlCorProdutos.TabIndex = 6;
            // 
            // lblUltimosProdutos
            // 
            lblUltimosProdutos.AutoSize = true;
            lblUltimosProdutos.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUltimosProdutos.ForeColor = Color.FromArgb(64, 64, 64);
            lblUltimosProdutos.Location = new Point(34, 238);
            lblUltimosProdutos.Name = "lblUltimosProdutos";
            lblUltimosProdutos.Size = new Size(246, 20);
            lblUltimosProdutos.TabIndex = 3;
            lblUltimosProdutos.Text = "💾 Últimos produtos cadastrados";
            // 
            // DashboardUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlCorProdutos);
            Controls.Add(pnlCorCategorias);
            Controls.Add(lblUltimosProdutos);
            Controls.Add(lblSubTitulo);
            Controls.Add(lblTitulo);
            Controls.Add(cardProdutos);
            Controls.Add(gridUltimosProdutos);
            Controls.Add(cardCategorias);
            Name = "DashboardUserControl";
            Size = new Size(788, 484);
            cardCategorias.ResumeLayout(false);
            cardCategorias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridUltimosProdutos).EndInit();
            cardProdutos.ResumeLayout(false);
            cardProdutos.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel cardCategorias;
        private DataGridView gridUltimosProdutos;
        private Label lblTitulo;
        private Label lblSubTitulo;
        private Label cardCategoriasLblNumero;
        private Label cardCategoriasLblDesc;
        private Guna.UI2.WinForms.Guna2Panel pnlCorCategorias;
        private Panel cardProdutos;
        private Label cardProdutosLblNumero;
        private Label cardProdutosLblTitulo;
        private Label cardProdutosLblDesc;
        private Guna.UI2.WinForms.Guna2Panel pnlCorProdutos;
        private Label cardCategoriasLblTitulo;
        private Label lblUltimosProdutos;
    }
}
