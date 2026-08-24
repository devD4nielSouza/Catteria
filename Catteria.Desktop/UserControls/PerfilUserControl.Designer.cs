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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            card = new Guna.UI2.WinForms.Guna2Panel();
            SuspendLayout();
            // 
            // card
            // 
            card.BackColor = Color.Transparent;
            card.BorderRadius = 12;
            card.CustomizableEdges = customizableEdges1;
            card.FillColor = Color.White;
            card.Location = new Point(119, 44);
            card.Name = "card";
            card.ShadowDecoration.Color = Color.FromArgb(10, 0, 0, 0);
            card.ShadowDecoration.CustomizableEdges = customizableEdges2;
            card.ShadowDecoration.Depth = 10;
            card.ShadowDecoration.Enabled = true;
            card.Size = new Size(520, 380);
            card.TabIndex = 2;
            // 
            // PerfilUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(253, 247, 242);
            Controls.Add(card);
            Name = "PerfilUserControl";
            Size = new Size(788, 484);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel card;
    }
}
