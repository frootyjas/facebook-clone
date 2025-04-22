    using System.Drawing.Text;

    namespace facebook_clone
    {
    public partial class mainForm : Form
    {

        private PanelManager _panelManager;

        public mainForm()
        {
            InitializeComponent();
            InitializePanelManager();
            SetupEventHandlers();
            ConfigureHoverEffect(lblLogin_lgnSec, rpLoginContainer_lgnSec,
                StyleConstants.TransparentBlue, StyleConstants.PrimaryColor);
            ConfigureHoverEffect(lblLogin_wlcSec, rpLoginContainer_wlcSec,
                StyleConstants.TransparentBlue, StyleConstants.PrimaryColor);
            ConfigureHoverEffect(lblCreateAccount, rpCreateAccountContainer_wlcSec,
                StyleConstants.DarkGreen, StyleConstants.SecondaryColor);
            ConfigureHoverEffect(lblLogin_fgtSec, rpLoginContainer_fgtSec,
                StyleConstants.TransparentBlue, StyleConstants.PrimaryColor);
            ConfigureHoverEffect(lblSearch_fgtSec, rpSearchContainer_fgtSec,
                StyleConstants.TransparentBlue, StyleConstants.PrimaryColor);
            ConfigureHoverEffect(lblCancel_fgtSec, rpCancelContainer_fgtSec,
                StyleConstants.LightGray, StyleConstants.LightGray);
            ApplyFonts();
            ConfigureInputFields();

            // Select first item automatically
            if (cbbBirthday_crtAcctSec.Items.Count > 0)
            {
                cbbBirthday_crtAcctSec.SelectedIndex = 0;
            }

            // Remove blue highlight
            ConfigureComboBoxAppearance();


        }
        private void ConfigureComboBoxAppearance()
        {
            // Set these properties
            cbbBirthday_crtAcctSec.DrawMode = DrawMode.OwnerDrawFixed;
            cbbBirthday_crtAcctSec.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbBirthday_crtAcctSec.DrawItem += CbbBirthday_crtAcctSec_DrawItem;
        }

        private void CbbBirthday_crtAcctSec_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ComboBox combo = sender as ComboBox;

            // Custom colors example
            Color backColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                ? ColorTranslator.FromHtml("#00000000")  // Light gray
                : ColorTranslator.FromHtml("#FFFFFF"); // White

            Color textColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                ? ColorTranslator.FromHtml("#383a3c")  // Facebook blue
                : ColorTranslator.FromHtml("#444444"); // Dark gray

            // Draw background
            using (Brush backBrush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }

            // Draw text
            using (Brush textBrush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(
                    combo.Items[e.Index].ToString(),
                    e.Font,
                    textBrush,
                    e.Bounds);
            }

            // Remove focus rectangle if desired
            // e.DrawFocusRectangle();
        }
        private void InitializePanelManager()
        {
            _panelManager = new PanelManager(
                defaultPanel: pnlWelcomeSection,  // default panel
                pnlWelcomeSection,
                createAccountPanel,
                forgotPasswordPanel,
                pnlLoginSection
            );

        }
        private void ApplyFonts()
        {

            // Welcome Section
            txtEmailInput_wlcSec.Font = FontHelper.GetFont(StyleConstants.InputFontSize);
            txtPasswordInput_wlcSec.Font = FontHelper.GetFont(StyleConstants.InputFontSize);
            lblFacebookTagline.Font = FontHelper.GetFont(StyleConstants.TaglineFontSize);
            lnkForgotPassword.Font = FontHelper.GetFont(StyleConstants.LinkFontSize);
            lblLogin_wlcSec.Font = FontHelper.GetFont(StyleConstants.ButtonFontSize, FontStyle.Bold);
            lblCreateAccount.Font = FontHelper.GetFont(StyleConstants.CreateAccountFontSize, FontStyle.Bold);

            // Login Section
            lblLoginIntoFb.Font = FontHelper.GetFont(StyleConstants.HeaderFontSize);
            txtEmailInput_lgnSec.Font = FontHelper.GetFont(StyleConstants.InputFontSize);
            txtPasswordInput_lgnSec.Font = FontHelper.GetFont(StyleConstants.InputFontSize);
            lblLogin_lgnSec.Font = FontHelper.GetFont(StyleConstants.ButtonFontSize, FontStyle.Bold);
            lnkForgotAccount.Font = FontHelper.GetFont(StyleConstants.LinkFontSize);
            lnkSignupForFb.Font = FontHelper.GetFont(StyleConstants.LinkFontSize);

            // Forgot Password Section
            txtEmailInput_fgtSec.Font = FontHelper.GetFont(StyleConstants.InputFontSize);
            txtPasswordInput_fgtSec.Font = FontHelper.GetFont(StyleConstants.InputFontSize);
            lblLogin_fgtSec.Font = FontHelper.GetFont(StyleConstants.SecondaryButtonFontSize, FontStyle.Bold);
            lnkForgotPassword_fgtSec.Font = FontHelper.GetFont(StyleConstants.LinkFontSize, FontStyle.Bold);
            lblInstruction.Font = FontHelper.GetFont(StyleConstants.InputFontSize);
            lblFindYourAccount.Font = FontHelper.GetFont(StyleConstants.HeaderFontSize, FontStyle.Bold);
            lblCancel_fgtSec.Font = FontHelper.GetFont(StyleConstants.SecondaryButtonFontSize, FontStyle.Bold);
            lblSearch_fgtSec.Font = FontHelper.GetFont(StyleConstants.SecondaryButtonFontSize, FontStyle.Bold);
            txtEmailInputSearch_fgtSec.Font = FontHelper.GetFont(StyleConstants.InputFontSize);

            // Create Account Section
            lblTagline_crtAcctSec.Font = FontHelper.GetFont(StyleConstants.InputFontSize - 1);
            lblCreateANewAccount.Font = FontHelper.GetFont(StyleConstants.HeaderFontSize + 4, FontStyle.Bold);
        }

        private void ConfigureInputFields()
        {
            ConfigurePasswordField(txtPasswordInput_lgnSec);
            ConfigurePasswordField(txtPasswordInput_wlcSec);
            ConfigurePasswordField(txtPasswordInput_fgtSec);
        }

        private void SetupEventHandlers()
        {
            // Panel navigation
            lblCreateAccount.Click += (s, e) => _panelManager.ShowPanel(createAccountPanel);
            lnkAlreadyHaveAnAccount.Click += (s, e) => _panelManager.ShowPanel(pnlLoginSection);
            lnkForgotPassword.Click += (s, e) => _panelManager.ShowPanel(forgotPasswordPanel);
            lblCancel_fgtSec.Click += (s, e) => _panelManager.ShowPanel(pnlLoginSection);
            lnkForgotAccount.Click += (s, e) => _panelManager.ShowPanel(forgotPasswordPanel);
            lnkSignupForFb.Click += (s, e) => _panelManager.ShowPanel(createAccountPanel);

            // Input field focus handling
            SetupInputFieldFocus(txtEmailInput_lgnSec, rpEmailContainer_lgnSec, rpEmailContainer_lgnSec, rpPasswordContainer_lgnSec);
            SetupInputFieldFocus(txtPasswordInput_lgnSec, rpPasswordContainer_lgnSec, rpEmailContainer_lgnSec, rpPasswordContainer_lgnSec);

            SetupInputFieldFocus(txtEmailInput_wlcSec, rpEmailContainer_wlcSec, rpEmailContainer_wlcSec, rpPasswordContainer_wlcSec);
            SetupInputFieldFocus(txtPasswordInput_wlcSec, rpPasswordContainer_wlcSec, rpEmailContainer_wlcSec, rpPasswordContainer_wlcSec);

            SetupInputFieldFocus(txtEmailInput_fgtSec, rpEmailContainer_fgtSec, rpEmailContainer_fgtSec, rpPasswordContainer_fgtSec, rpEmailContainerSearch_fgtSec);
            SetupInputFieldFocus(txtPasswordInput_fgtSec, rpPasswordContainer_fgtSec, rpEmailContainer_fgtSec, rpPasswordContainer_fgtSec, rpEmailContainerSearch_fgtSec);
        }
        private void SetupInputFieldFocus(TextBox textBox, RoundedPanel container, params RoundedPanel[] allPanels)
        {
            textBox.Enter += (s, e) =>
            {
                container.BorderColor = StyleConstants.PrimaryColor;
                ResetOtherBorders(container, allPanels);
            };

            textBox.Leave += (s, e) =>
            {
                container.BorderColor = StyleConstants.BorderColor;
            };
        }

        private void ConfigureHoverEffect(Control triggerControl, Control container, Color hoverColor, Color leaveColor)
        {
            triggerControl.Cursor = Cursors.Hand;
            triggerControl.MouseEnter += (s, e) =>
                container.BackColor = hoverColor;
            triggerControl.MouseLeave += (s, e) =>
                container.BackColor = leaveColor;
        }


        private void ResetOtherBorders(RoundedPanel activePanel, params RoundedPanel[] allPanels)
        {
            foreach (var panel in allPanels)
            {
                if (panel != activePanel)
                {
                    panel.BorderColor = StyleConstants.BorderColor;
                }
            }
        }

        private void ConfigurePasswordField(TextBox passwordField)
        {
            passwordField.Enter += (s, e) =>
                passwordField.Font = new Font("Segoe UI", StyleConstants.InputFontSize);

            passwordField.Leave += (s, e) =>
            {
                if (string.IsNullOrEmpty(passwordField.Text))
                {
                    passwordField.Font = FontHelper.GetFont(StyleConstants.InputFontSize);
                }
            };

            passwordField.TextChanged += (s, e) =>
            {
                if (string.IsNullOrEmpty(passwordField.Text) && !passwordField.Focused)
                {
                    passwordField.Font = FontHelper.GetFont(StyleConstants.InputFontSize);
                }
            };
        }


    }

}
