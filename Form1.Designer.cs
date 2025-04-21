namespace facebook_clone
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            roundedPanel1 = new RoundedPanel();
            emailPanel = new RoundedPanel();
            emailInput = new TextBox();
            passwordPanel = new RoundedPanel();
            passwordInput = new TextBox();
            createAccountBtn = new RoundedPanel();
            createaccountLabel = new Label();
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            LoginBtn = new RoundedPanel();
            loginLabel = new Label();
            loginPanel = new Panel();
            panel2 = new Panel();
            taglineLabel = new Label();
            pictureBox1 = new PictureBox();
            createAccountPanel = new Panel();
            alreadyHaveAccountLabel = new Label();
            roundedPanel1.SuspendLayout();
            emailPanel.SuspendLayout();
            passwordPanel.SuspendLayout();
            createAccountBtn.SuspendLayout();
            LoginBtn.SuspendLayout();
            loginPanel.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            createAccountPanel.SuspendLayout();
            SuspendLayout();
            // 
            // roundedPanel1
            // 
            roundedPanel1.BackColor = Color.White;
            roundedPanel1.BorderColor = Color.Gray;
            roundedPanel1.Controls.Add(emailPanel);
            roundedPanel1.Controls.Add(passwordPanel);
            roundedPanel1.Controls.Add(createAccountBtn);
            roundedPanel1.Controls.Add(label1);
            roundedPanel1.Controls.Add(linkLabel1);
            roundedPanel1.Controls.Add(LoginBtn);
            roundedPanel1.Location = new Point(609, 35);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(365, 392);
            roundedPanel1.TabIndex = 0;
            // 
            // emailPanel
            // 
            emailPanel.BackColor = Color.Transparent;
            emailPanel.BorderColor = Color.FromArgb(221, 223, 226);
            emailPanel.BorderThickness = 1;
            emailPanel.Controls.Add(emailInput);
            emailPanel.CornerRadius = 8;
            emailPanel.Location = new Point(13, 18);
            emailPanel.Name = "emailPanel";
            emailPanel.Size = new Size(340, 60);
            emailPanel.TabIndex = 4;
            // 
            // emailInput
            // 
            emailInput.BorderStyle = BorderStyle.None;
            emailInput.Location = new Point(18, 19);
            emailInput.Name = "emailInput";
            emailInput.PlaceholderText = "Email or phone number";
            emailInput.Size = new Size(305, 20);
            emailInput.TabIndex = 0;
            // 
            // passwordPanel
            // 
            passwordPanel.BackColor = Color.Transparent;
            passwordPanel.BorderColor = Color.FromArgb(221, 223, 226);
            passwordPanel.BorderThickness = 1;
            passwordPanel.Controls.Add(passwordInput);
            passwordPanel.CornerRadius = 8;
            passwordPanel.Location = new Point(12, 91);
            passwordPanel.Name = "passwordPanel";
            passwordPanel.Size = new Size(340, 60);
            passwordPanel.TabIndex = 2;
            // 
            // passwordInput
            // 
            passwordInput.BorderStyle = BorderStyle.None;
            passwordInput.Location = new Point(18, 21);
            passwordInput.Name = "passwordInput";
            passwordInput.PasswordChar = '●';
            passwordInput.PlaceholderText = "Password";
            passwordInput.Size = new Size(305, 20);
            passwordInput.TabIndex = 0;
            // 
            // createAccountBtn
            // 
            createAccountBtn.BackColor = Color.FromArgb(153, 54, 164, 32);
            createAccountBtn.BorderColor = Color.Gray;
            createAccountBtn.Controls.Add(createaccountLabel);
            createAccountBtn.CornerRadius = 8;
            createAccountBtn.Location = new Point(70, 308);
            createAccountBtn.Name = "createAccountBtn";
            createAccountBtn.Size = new Size(227, 50);
            createAccountBtn.TabIndex = 1;
            // 
            // createaccountLabel
            // 
            createaccountLabel.BackColor = Color.Transparent;
            createaccountLabel.Font = new Font("FiraCode Nerd Font", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createaccountLabel.ForeColor = Color.White;
            createaccountLabel.Location = new Point(0, 0);
            createaccountLabel.Name = "createaccountLabel";
            createaccountLabel.Size = new Size(224, 50);
            createaccountLabel.TabIndex = 0;
            createaccountLabel.Text = "Create new account";
            createaccountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(218, 221, 225);
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(23, 278);
            label1.Name = "label1";
            label1.Size = new Size(315, 1);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel1.LinkColor = Color.FromArgb(23, 102, 255);
            linkLabel1.Location = new Point(113, 235);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(153, 19);
            linkLabel1.TabIndex = 1;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Forgot Password?";
            // 
            // LoginBtn
            // 
            LoginBtn.BackColor = Color.FromArgb(153, 24, 119, 242);
            LoginBtn.BorderColor = Color.Gray;
            LoginBtn.Controls.Add(loginLabel);
            LoginBtn.CornerRadius = 8;
            LoginBtn.Location = new Point(12, 166);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(340, 50);
            LoginBtn.TabIndex = 0;
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.BackColor = Color.Transparent;
            loginLabel.Font = new Font("FiraCode Nerd Font", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginLabel.ForeColor = Color.White;
            loginLabel.Location = new Point(131, 12);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(88, 24);
            loginLabel.TabIndex = 0;
            loginLabel.Text = "Log In";
            // 
            // loginPanel
            // 
            loginPanel.Controls.Add(panel2);
            loginPanel.Controls.Add(roundedPanel1);
            loginPanel.Dock = DockStyle.Fill;
            loginPanel.Location = new Point(0, 0);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(1059, 495);
            loginPanel.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(taglineLabel);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(45, 74);
            panel2.Name = "panel2";
            panel2.Size = new Size(386, 265);
            panel2.TabIndex = 3;
            // 
            // taglineLabel
            // 
            taglineLabel.BackColor = Color.Transparent;
            taglineLabel.Location = new Point(13, 137);
            taglineLabel.Name = "taglineLabel";
            taglineLabel.Size = new Size(359, 116);
            taglineLabel.TabIndex = 2;
            taglineLabel.Text = "Connect with friends and the world around you on Facebook.";
            taglineLabel.Click += taglineLabel_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 52);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(207, 115);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // createAccountPanel
            // 
            createAccountPanel.Controls.Add(alreadyHaveAccountLabel);
            createAccountPanel.Dock = DockStyle.Fill;
            createAccountPanel.Location = new Point(0, 0);
            createAccountPanel.Name = "createAccountPanel";
            createAccountPanel.Size = new Size(1059, 495);
            createAccountPanel.TabIndex = 4;
            createAccountPanel.Paint += panel3_Paint;
            // 
            // alreadyHaveAccountLabel
            // 
            alreadyHaveAccountLabel.AutoSize = true;
            alreadyHaveAccountLabel.Location = new Point(437, 254);
            alreadyHaveAccountLabel.Name = "alreadyHaveAccountLabel";
            alreadyHaveAccountLabel.Size = new Size(225, 19);
            alreadyHaveAccountLabel.TabIndex = 0;
            alreadyHaveAccountLabel.Text = "Already have an account?";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 244, 247);
            ClientSize = new Size(1059, 495);
            Controls.Add(loginPanel);
            Controls.Add(createAccountPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            TransparencyKey = Color.FromArgb(0, 0, 0, 1);
            roundedPanel1.ResumeLayout(false);
            roundedPanel1.PerformLayout();
            emailPanel.ResumeLayout(false);
            emailPanel.PerformLayout();
            passwordPanel.ResumeLayout(false);
            passwordPanel.PerformLayout();
            createAccountBtn.ResumeLayout(false);
            LoginBtn.ResumeLayout(false);
            LoginBtn.PerformLayout();
            loginPanel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            createAccountPanel.ResumeLayout(false);
            createAccountPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel roundedPanel1;
        private RoundedPanel LoginBtn;
        private Label loginLabel;
        private Panel loginPanel;
        private Label taglineLabel;
        private PictureBox pictureBox1;
        private Panel panel2;
        private LinkLabel linkLabel1;
        private Label label1;
        private RoundedPanel createAccountBtn;
        private Label createaccountLabel;
        private RoundedPanel passwordPanel;
        private TextBox passwordInput;
        private RoundedPanel emailPanel;
        private TextBox emailInput;
        private Panel createAccountPanel;
        private Label alreadyHaveAccountLabel;
    }
}
