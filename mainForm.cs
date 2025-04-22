    using System.Drawing.Text;

    namespace facebook_clone
    {
    public partial class mainForm : Form

    {
        PrivateFontCollection fbFont = new PrivateFontCollection();
        public mainForm()
        {
            InitializeComponent();

            // Set initial panel visibility
            mainPanel.Visible = true;
            createAccountPanel.Visible = false;
            forgotPasswordPanel.Visible = false;
            loginPanel.Visible = false;

            // Add click handlers
            createaccountLabel.Click += (s, e) =>
            {
                mainPanel.Visible = false;
                createAccountPanel.Visible = true;
            };


            alreadyHaveAccountLabel.Click += (s, e) =>
            {
                createAccountPanel.Visible = false;
                loginPanel.Visible = true;
            };

            forgotPassword.Click += (s, e) =>
            {
                forgotPasswordPanel.Visible = true;
                mainPanel.Visible = false;
            };

            cancelLabel.Click += (s, e) =>
            {
                forgotPasswordPanel.Visible = false;
                loginPanel.Visible = true;
            };

            forgotAccountLabel.Click += (s, e) =>
            {
                forgotPasswordPanel.Visible = true;
                loginPanel.Visible = false;
            };

            signUpLabel.Click += (s, e) =>
            {
                createAccountPanel.Visible = true;
                loginPanel.Visible = false;
            };


            // Set hand cursor for the label
            alreadyHaveAccountLabel.Cursor = Cursors.Hand;

            loginLabel.Cursor = Cursors.Hand;
            createaccountLabel.Cursor = Cursors.Hand;
            cancelLabel.Cursor = Cursors.Hand;



            string fontPath = Path.Combine(Application.StartupPath, "Fonts", "font.ttf");
            fbFont.AddFontFile(fontPath);

            // Apply to a control
            loginLabel.Font = new Font(fbFont.Families[0], 12f, FontStyle.Bold);
            createaccountLabel.Font = new Font(fbFont.Families[0], 10f, FontStyle.Bold);
            taglineLabel.Font = new Font(fbFont.Families[0], 14f);

            emailInput.Font = new Font(fbFont.Families[0], 10f);
            passwordInput.Font = new Font(fbFont.Families[0], 10f);

            // Assume fbFont is already loaded
            passwordInput.Click += (s, e) =>
            {
                passwordInput.Font = new Font(fbFont.Families[0], 14f); // Bigger font on focus
            };

            passwordInput.Click += (s, e) =>
            {
                passwordInput.Font = new Font(fbFont.Families[0], 9f); // Back to default
            };

            emailInput.Enter += (s, e) =>
            {
                emailPanel.BorderColor = ColorTranslator.FromHtml("#1877F2");
                passwordPanel.BorderColor = Color.FromArgb(221, 223, 226);
            };

            passwordInput.Enter += (s, e) =>
            {
                passwordPanel.BorderColor = ColorTranslator.FromHtml("#1877F2");
                emailPanel.BorderColor = Color.FromArgb(221, 223, 226);
            };



            // Optionally, handle Leave if you want to reset on blur
            emailInput.Leave += (s, e) =>
            {
                emailPanel.BorderColor = Color.FromArgb(221, 223, 226);
            };

            passwordInput.Leave += (s, e) =>
            {
                passwordPanel.BorderColor = Color.FromArgb(221, 223, 226);
            };

            loginLabel.MouseEnter += (s, e) =>
            LoginBtn.BackColor = ColorTranslator.FromHtml("#1877f2");
            loginLabel.MouseLeave += (s, e) => LoginBtn.BackColor = Color.FromArgb(153, 24, 119, 242);

            cancelLabel.MouseEnter += (s, e) =>
            cancelBtn.BackColor = ColorTranslator.FromHtml("#E4E6EB");
            cancelLabel.MouseLeave += (s, e) => cancelBtn.BackColor = Color.FromArgb(80, 228, 230, 235);

            createaccountLabel.MouseEnter += (s, e) =>
            createAccountBtn.BackColor = ColorTranslator.FromHtml("#36a420");
            createaccountLabel.MouseLeave += (s, e) => createAccountBtn.BackColor = Color.FromArgb(153, 54, 164, 32);
        }

        private void taglineLabel_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void alreadyHaveAccountLabel_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void roundedPanel17_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
