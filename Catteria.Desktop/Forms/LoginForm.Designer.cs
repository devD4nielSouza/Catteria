namespace Catteria.Desktop.Forms
{
    partial class LoginForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pbLogo = new PictureBox();
            lblLogin = new Label();
            lblEmail = new Label();
            lblSenha = new Label();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            txtSenha = new Guna.UI2.WinForms.Guna2TextBox();
            btnEntrar = new Guna.UI2.WinForms.Guna2Button();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            btnSair = new Guna.UI2.WinForms.Guna2ImageRadioButton();
            lblErro = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblCarregando = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // pbLogo
            // 
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(105, 45);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(161, 127);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 0;
            pbLogo.TabStop = false;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogin.ForeColor = Color.FromArgb(64, 64, 64);
            lblLogin.Location = new Point(141, 188);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(90, 15);
            lblLogin.TabIndex = 1;
            lblLogin.Text = "Faça seu Login!";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.ForeColor = Color.FromArgb(64, 64, 64);
            lblEmail.Location = new Point(57, 225);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(41, 15);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "E-mail";
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.ForeColor = Color.FromArgb(64, 64, 64);
            lblSenha.Location = new Point(57, 288);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(39, 15);
            lblSenha.TabIndex = 1;
            lblSenha.Text = "Senha";
            // 
            // txtEmail
            // 
            txtEmail.BorderColor = Color.FromArgb(164, 188, 233);
            txtEmail.BorderRadius = 5;
            txtEmail.CustomizableEdges = customizableEdges1;
            txtEmail.DefaultText = "";
            txtEmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.FillColor = Color.FromArgb(164, 188, 233);
            txtEmail.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEmail.Location = new Point(57, 249);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderForeColor = Color.FromArgb(64, 64, 64);
            txtEmail.PlaceholderText = "Digite seu E-mail";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtEmail.Size = new Size(260, 36);
            txtEmail.TabIndex = 2;
            txtEmail.KeyDown += txtEmail_KeyDown;
            // 
            // txtSenha
            // 
            txtSenha.BorderRadius = 5;
            txtSenha.CustomizableEdges = customizableEdges3;
            txtSenha.DefaultText = "";
            txtSenha.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSenha.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSenha.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSenha.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSenha.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSenha.Font = new Font("Segoe UI", 9F);
            txtSenha.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSenha.Location = new Point(57, 306);
            txtSenha.Name = "txtSenha";
            txtSenha.PlaceholderForeColor = Color.Gray;
            txtSenha.PlaceholderText = ". . . . . . . . ";
            txtSenha.SelectedText = "";
            txtSenha.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSenha.Size = new Size(260, 36);
            txtSenha.TabIndex = 2;
            txtSenha.UseSystemPasswordChar = true;
            txtSenha.KeyDown += txtSenha_KeyDown;
            // 
            // btnEntrar
            // 
            btnEntrar.Animated = true;
            btnEntrar.BorderRadius = 5;
            btnEntrar.CustomizableEdges = customizableEdges5;
            btnEntrar.DisabledState.BorderColor = Color.DarkGray;
            btnEntrar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEntrar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEntrar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEntrar.FillColor = Color.FromArgb(76, 120, 178);
            btnEntrar.Font = new Font("Segoe UI", 9F);
            btnEntrar.ForeColor = Color.White;
            btnEntrar.Location = new Point(116, 348);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnEntrar.Size = new Size(135, 31);
            btnEntrar.TabIndex = 3;
            btnEntrar.Text = "Login";
            btnEntrar.Click += btnEntrar_Click;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 10;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // btnSair
            // 
            btnSair.CheckedState.Image = (Image)resources.GetObject("resource.Image");
            btnSair.Image = (Image)resources.GetObject("btnSair.Image");
            btnSair.ImageOffset = new Point(0, 0);
            btnSair.ImageRotate = 0F;
            btnSair.ImageSize = new Size(40, 40);
            btnSair.Location = new Point(307, 5);
            btnSair.Name = "btnSair";
            btnSair.ShadowDecoration.CustomizableEdges = customizableEdges7;
            btnSair.Size = new Size(57, 48);
            btnSair.TabIndex = 4;
            btnSair.CheckedChanged += btnSair_CheckedChanged;
            // 
            // lblErro
            // 
            lblErro.BackColor = Color.Transparent;
            lblErro.ForeColor = Color.Maroon;
            lblErro.Location = new Point(169, 392);
            lblErro.Name = "lblErro";
            lblErro.Size = new Size(24, 17);
            lblErro.TabIndex = 8;
            lblErro.Text = "Erro";
            lblErro.TextAlignment = ContentAlignment.TopCenter;
            lblErro.Visible = false;
            // 
            // lblCarregando
            // 
            lblCarregando.BackColor = Color.Transparent;
            lblCarregando.ForeColor = SystemColors.ControlDark;
            lblCarregando.Location = new Point(144, 207);
            lblCarregando.Name = "lblCarregando";
            lblCarregando.Size = new Size(84, 17);
            lblCarregando.TabIndex = 9;
            lblCarregando.Text = "Autenticando...";
            lblCarregando.TextAlignment = ContentAlignment.TopCenter;
            lblCarregando.Visible = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(253, 247, 242);
            ClientSize = new Size(372, 430);
            Controls.Add(lblCarregando);
            Controls.Add(lblErro);
            Controls.Add(btnSair);
            Controls.Add(btnEntrar);
            Controls.Add(txtSenha);
            Controls.Add(txtEmail);
            Controls.Add(lblSenha);
            Controls.Add(lblEmail);
            Controls.Add(lblLogin);
            Controls.Add(pbLogo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbLogo;
        private Label lblLogin;
        private Label lblEmail;
        private Label lblSenha;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtSenha;
        private Guna.UI2.WinForms.Guna2Button btnEntrar;
     
     
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ImageRadioButton btnSair;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblErro;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCarregando;
    }
}