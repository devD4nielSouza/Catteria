namespace Catteria.Desktop.Forms
{
    partial class CupomFormDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
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
            lblTituloForm = new Label();
            lblCampTitulo = new Label();
            txtTitulo = new Guna.UI2.WinForms.Guna2TextBox();
            txtAno = new Guna.UI2.WinForms.Guna2TextBox();
            lblCampCover = new Label();
            chkDestaque = new CheckBox();
            btnSalvar = new Guna.UI2.WinForms.Guna2Button();
            btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // lblTituloForm
            // 
            lblTituloForm.Font = new Font("Gill Sans MT", 16.25F, FontStyle.Bold);
            lblTituloForm.ForeColor = Color.Gray;
            lblTituloForm.Location = new Point(39, 18);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Size = new Size(123, 33);
            lblTituloForm.TabIndex = 28;
            lblTituloForm.Text = "Cupom";
            // 
            // lblCampTitulo
            // 
            lblCampTitulo.Font = new Font("Gill Sans MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCampTitulo.ForeColor = Color.FromArgb(76, 120, 178);
            lblCampTitulo.Location = new Point(39, 65);
            lblCampTitulo.Name = "lblCampTitulo";
            lblCampTitulo.Size = new Size(460, 20);
            lblCampTitulo.TabIndex = 29;
            lblCampTitulo.Text = "CODIGO DO CUPOM *";
            // 
            // txtTitulo
            // 
            txtTitulo.BorderColor = Color.FromArgb(224, 228, 235);
            txtTitulo.BorderRadius = 6;
            txtTitulo.CustomizableEdges = customizableEdges1;
            txtTitulo.DefaultText = "";
            txtTitulo.Font = new Font("Segoe UI", 9.5F);
            txtTitulo.Location = new Point(39, 90);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.PlaceholderText = "Ex: CUPOM123";
            txtTitulo.SelectedText = "";
            txtTitulo.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtTitulo.Size = new Size(460, 40);
            txtTitulo.TabIndex = 30;
            // 
            // txtAno
            // 
            txtAno.BorderColor = Color.FromArgb(224, 228, 235);
            txtAno.BorderRadius = 6;
            txtAno.CustomizableEdges = customizableEdges3;
            txtAno.DefaultText = "";
            txtAno.Font = new Font("Segoe UI", 9.5F);
            txtAno.Location = new Point(39, 167);
            txtAno.Name = "txtAno";
            txtAno.PlaceholderText = "Ex: 20";
            txtAno.SelectedText = "";
            txtAno.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtAno.Size = new Size(121, 40);
            txtAno.TabIndex = 34;
            txtAno.KeyPress += txtAno_KeyPress;
            // 
            // lblCampCover
            // 
            lblCampCover.Font = new Font("Gill Sans MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCampCover.ForeColor = Color.FromArgb(76, 120, 178);
            lblCampCover.Location = new Point(39, 145);
            lblCampCover.Name = "lblCampCover";
            lblCampCover.Size = new Size(460, 20);
            lblCampCover.TabIndex = 35;
            lblCampCover.Text = "PORCENTAGEM DO DESCONTO *";
            // 
            // chkDestaque
            // 
            chkDestaque.AutoSize = true;
            chkDestaque.Font = new Font("Gill Sans MT", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkDestaque.ForeColor = Color.FromArgb(51, 61, 75);
            chkDestaque.Location = new Point(39, 225);
            chkDestaque.Name = "chkDestaque";
            chkDestaque.Size = new Size(115, 22);
            chkDestaque.TabIndex = 39;
            chkDestaque.Text = "⭐ Cupom Ativo";
            // 
            // btnSalvar
            // 
            btnSalvar.BorderRadius = 8;
            btnSalvar.CustomizableEdges = customizableEdges5;
            btnSalvar.FillColor = Color.FromArgb(164, 188, 223);
            btnSalvar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.Location = new Point(39, 284);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnSalvar.Size = new Size(140, 42);
            btnSalvar.TabIndex = 40;
            btnSalvar.Text = "💾 Salvar";
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BorderColor = Color.Gray;
            btnCancelar.BorderRadius = 8;
            btnCancelar.BorderThickness = 1;
            btnCancelar.CustomizableEdges = customizableEdges7;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.FillColor = Color.FromArgb(245, 247, 250);
            btnCancelar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.FromArgb(51, 61, 75);
            btnCancelar.Location = new Point(215, 284);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnCancelar.Size = new Size(115, 42);
            btnCancelar.TabIndex = 41;
            btnCancelar.Text = "Cancelar";
            // 
            // CupomFormDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(253, 247, 242);
            ClientSize = new Size(558, 344);
            Controls.Add(btnCancelar);
            Controls.Add(lblTituloForm);
            Controls.Add(lblCampTitulo);
            Controls.Add(txtTitulo);
            Controls.Add(txtAno);
            Controls.Add(lblCampCover);
            Controls.Add(chkDestaque);
            Controls.Add(btnSalvar);
            Name = "CupomFormDialog";
            Text = "Cupom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloForm;
        private Label lblCampTitulo;
        private Guna.UI2.WinForms.Guna2TextBox txtTitulo;
        private Guna.UI2.WinForms.Guna2TextBox txtAno;
        private Label lblCampCover;
        private CheckBox chkDestaque;
        private Guna.UI2.WinForms.Guna2Button btnSalvar;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
    }
}