namespace Catteria.Desktop.Forms
{
    partial class OrderFormDialog
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
            btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            lblTituloForm = new Label();
            lblCampTitulo = new Label();
            btnSalvar = new Guna.UI2.WinForms.Guna2Button();
            cmbStatus = new ComboBox();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.BorderColor = Color.Gray;
            btnCancelar.BorderRadius = 8;
            btnCancelar.BorderThickness = 1;
            btnCancelar.CustomizableEdges = customizableEdges1;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.FillColor = Color.FromArgb(245, 247, 250);
            btnCancelar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.FromArgb(51, 61, 75);
            btnCancelar.Location = new Point(212, 590);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnCancelar.Size = new Size(115, 42);
            btnCancelar.TabIndex = 49;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblTituloForm
            // 
            lblTituloForm.Font = new Font("Gill Sans MT", 16.25F, FontStyle.Bold);
            lblTituloForm.ForeColor = Color.Gray;
            lblTituloForm.Location = new Point(31, 28);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Size = new Size(123, 33);
            lblTituloForm.TabIndex = 42;
            lblTituloForm.Text = "Pedido";
            // 
            // lblCampTitulo
            // 
            lblCampTitulo.Font = new Font("Gill Sans MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCampTitulo.ForeColor = Color.FromArgb(76, 120, 178);
            lblCampTitulo.Location = new Point(31, 75);
            lblCampTitulo.Name = "lblCampTitulo";
            lblCampTitulo.Size = new Size(460, 20);
            lblCampTitulo.TabIndex = 43;
            lblCampTitulo.Text = "STATUS PEDIDO *";
            // 
            // btnSalvar
            // 
            btnSalvar.BorderRadius = 8;
            btnSalvar.CustomizableEdges = customizableEdges3;
            btnSalvar.FillColor = Color.FromArgb(164, 188, 223);
            btnSalvar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.Location = new Point(36, 590);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSalvar.Size = new Size(140, 42);
            btnSalvar.TabIndex = 48;
            btnSalvar.Text = "💾 Salvar";
            btnSalvar.Click += btnSalvar_Click;
            // 
            // cmbStatus
            // 
            cmbStatus.BackColor = SystemColors.ControlLight;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FlatStyle = FlatStyle.Flat;
            cmbStatus.Font = new Font("Segoe UI", 9.5F);
            cmbStatus.Location = new Point(31, 115);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(460, 25);
            cmbStatus.TabIndex = 50;
            // 
            // OrderFormDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 658);
            Controls.Add(cmbStatus);
            Controls.Add(btnCancelar);
            Controls.Add(lblTituloForm);
            Controls.Add(lblCampTitulo);
            Controls.Add(btnSalvar);
            Name = "OrderFormDialog";
            Text = "OrderFormDialog";
            Load += OrderFormDialog_Load;
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private Label lblTituloForm;
        private Label lblCampTitulo;
        private Guna.UI2.WinForms.Guna2Button btnSalvar;
        private ComboBox cmbStatus;
    }
}