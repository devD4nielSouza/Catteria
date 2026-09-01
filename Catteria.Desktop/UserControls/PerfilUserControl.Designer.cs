namespace Catteria.Desktop.UserControls
{
    partial class PerfilUserControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerfilUserControl));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            card = new Guna.UI2.WinForms.Guna2Panel();
            pnlAvatar = new Guna.UI2.WinForms.Guna2Panel();
            lblEmailLabel = new Label();
            lblEmailValor = new Label();
            lblRolesLabel = new Label();
            lblRolesValor = new Label();
            lblNome = new Label();
            lblBadge = new Label();
            sep = new Panel();
            lblTitulo = new Label();
            card.SuspendLayout();
            SuspendLayout();
            // 
            // card
            // 
            card.BackColor = Color.Transparent;
            card.BorderRadius = 12;
            card.Controls.Add(pnlAvatar);
            card.Controls.Add(lblEmailLabel);
            card.Controls.Add(lblEmailValor);
            card.Controls.Add(lblRolesLabel);
            card.Controls.Add(lblRolesValor);
            card.Controls.Add(lblNome);
            card.Controls.Add(lblBadge);
            card.Controls.Add(sep);
            card.CustomizableEdges = customizableEdges3;
            card.FillColor = Color.White;
            card.Location = new Point(128, 61);
            card.Name = "card";
            card.ShadowDecoration.Color = Color.FromArgb(10, 0, 0, 0);
            card.ShadowDecoration.CustomizableEdges = customizableEdges4;
            card.ShadowDecoration.Depth = 10;
            card.ShadowDecoration.Enabled = true;
            card.Size = new Size(520, 380);
            card.TabIndex = 2;
            // 
            // pnlAvatar
            // 
            pnlAvatar.BackgroundImage = (Image)resources.GetObject("pnlAvatar.BackgroundImage");
            pnlAvatar.BackgroundImageLayout = ImageLayout.Stretch;
            pnlAvatar.CustomizableEdges = customizableEdges1;
            pnlAvatar.Location = new Point(40, 22);
            pnlAvatar.Name = "pnlAvatar";
            pnlAvatar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlAvatar.Size = new Size(137, 147);
            pnlAvatar.TabIndex = 16;
            // 
            // lblEmailLabel
            // 
            lblEmailLabel.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblEmailLabel.ForeColor = Color.FromArgb(150, 160, 175);
            lblEmailLabel.Location = new Point(25, 221);
            lblEmailLabel.Name = "lblEmailLabel";
            lblEmailLabel.Size = new Size(460, 18);
            lblEmailLabel.TabIndex = 10;
            lblEmailLabel.Text = "E-MAIL";
            // 
            // lblEmailValor
            // 
            lblEmailValor.Font = new Font("Segoe UI", 9.5F);
            lblEmailValor.ForeColor = Color.FromArgb(51, 61, 75);
            lblEmailValor.Location = new Point(25, 239);
            lblEmailValor.Name = "lblEmailValor";
            lblEmailValor.Size = new Size(460, 22);
            lblEmailValor.TabIndex = 11;
            lblEmailValor.Text = "...";
            // 
            // lblRolesLabel
            // 
            lblRolesLabel.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblRolesLabel.ForeColor = Color.FromArgb(150, 160, 175);
            lblRolesLabel.Location = new Point(25, 282);
            lblRolesLabel.Name = "lblRolesLabel";
            lblRolesLabel.Size = new Size(460, 18);
            lblRolesLabel.TabIndex = 14;
            lblRolesLabel.Text = "PERMISSÕES";
            // 
            // lblRolesValor
            // 
            lblRolesValor.Font = new Font("Segoe UI", 9.5F);
            lblRolesValor.ForeColor = Color.FromArgb(51, 61, 75);
            lblRolesValor.Location = new Point(25, 300);
            lblRolesValor.Name = "lblRolesValor";
            lblRolesValor.Size = new Size(460, 22);
            lblRolesValor.TabIndex = 15;
            lblRolesValor.Text = "...";
            // 
            // lblNome
            // 
            lblNome.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNome.ForeColor = Color.DimGray;
            lblNome.Location = new Point(96, 57);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(411, 30);
            lblNome.TabIndex = 5;
            lblNome.Text = "Usuário";
            lblNome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBadge
            // 
            lblBadge.BackColor = Color.FromArgb(76, 120, 178);
            lblBadge.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBadge.ForeColor = Color.White;
            lblBadge.Location = new Point(220, 99);
            lblBadge.Name = "lblBadge";
            lblBadge.Size = new Size(160, 28);
            lblBadge.TabIndex = 6;
            lblBadge.Text = "Perfil";
            lblBadge.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sep
            // 
            sep.BackColor = Color.FromArgb(224, 228, 235);
            sep.Location = new Point(26, 189);
            sep.Name = "sep";
            sep.Size = new Size(460, 1);
            sep.TabIndex = 7;
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(76, 120, 178);
            lblTitulo.Location = new Point(309, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(157, 36);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "⚙️ Meu Perfil";
            // 
            // PerfilUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(253, 247, 242);
            Controls.Add(lblTitulo);
            Controls.Add(card);
            Name = "PerfilUserControl";
            Size = new Size(788, 484);
            Load += PerfilUserControl_Load;
            card.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel card;
        private Label lblTitulo;
        private Label lblEmailLabel;
        private Label lblEmailValor;
        private Label lblRolesLabel;
        private Label lblRolesValor;
        private Label lblNome;
        private Label lblBadge;
        private Panel sep;
        private Guna.UI2.WinForms.Guna2Panel pnlAvatar;
    }
}
