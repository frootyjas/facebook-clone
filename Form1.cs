using System.Drawing.Text;

namespace facebook_clone
{
    public partial class Form1 : Form

    {
        PrivateFontCollection fbFont = new PrivateFontCollection();
        public Form1()
        {
            InitializeComponent();
            LoginBtn.Cursor = Cursors.Hand;
            createaccountBtn.Cursor = Cursors.Hand;


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

            emailInput.Enter += (s, e) => {
                emailPanel.BorderColor = ColorTranslator.FromHtml("#1877F2");
                passwordPanel.BorderColor = Color.FromArgb(221, 223, 226);
            };

            passwordInput.Enter += (s, e) => {
                passwordPanel.BorderColor = ColorTranslator.FromHtml("#1877F2");
                emailPanel.BorderColor = Color.FromArgb(221, 223, 226);
            };

            // Optionally, handle Leave if you want to reset on blur
            emailInput.Leave += (s, e) => {
                emailPanel.BorderColor = Color.FromArgb(221, 223, 226);
            };

            passwordInput.Leave += (s, e) => {
                passwordPanel.BorderColor = Color.FromArgb(221, 223, 226);
            };

            LoginBtn.MouseEnter += (s, e) =>
            LoginBtn.BackColor =  ColorTranslator.FromHtml("#1877f2");
            LoginBtn.MouseLeave += (s, e) => LoginBtn.BackColor = Color.FromArgb(153, 24, 119, 242);


            createaccountBtn.MouseEnter += (s, e) =>
            createaccountBtn.BackColor =  ColorTranslator.FromHtml("#36a420");
            createaccountBtn.MouseLeave += (s, e) => createaccountBtn.BackColor = Color.FromArgb(153, 54, 164, 32);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void taglineLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
