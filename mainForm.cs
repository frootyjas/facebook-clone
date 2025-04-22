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
                StyleConstants.PrimaryColor, StyleConstants.TransparentBlue);
            ApplyFonts();
            ConfigureInputFields();

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
            lblLoginIntoFb.Font = FontHelper.GetFont(StyleConstants.HeaderFontSize);
            txtEmailInput_lgnSec.Font = FontHelper.GetFont(StyleConstants.InputFontSize);
            txtPasswordInput_lgnSec.Font = FontHelper.GetFont(StyleConstants.InputFontSize);
            lblLogin_lgnSec.Font = FontHelper.GetFont(StyleConstants.ButtonFontSize, FontStyle.Bold);
            lnkForgotAccount.Font = FontHelper.GetFont(StyleConstants.LinkFontSize);
            lnkSignupForFb.Font = FontHelper.GetFont(StyleConstants.LinkFontSize);
        }
        private void ConfigureInputFields()
        {
            ConfigurePasswordField(txtPasswordInput_lgnSec);
        }

        private void SetupEventHandlers()
        {
            // Panel navigation
            lblCreateAccount.Click += (s, e) => _panelManager.ShowPanel(createAccountPanel);
            alreadyHaveAccountLabel.Click += (s, e) => _panelManager.ShowPanel(pnlLoginSection);
            lnkForgotPassword.Click += (s, e) => _panelManager.ShowPanel(forgotPasswordPanel);
            cancelLabel.Click += (s, e) => _panelManager.ShowPanel(pnlLoginSection);
            lnkForgotAccount.Click += (s, e) => _panelManager.ShowPanel(forgotPasswordPanel);
            lnkSignupForFb.Click += (s, e) => _panelManager.ShowPanel(createAccountPanel);

            // Input field focus handling
            SetupInputFieldFocus(txtEmailInput_lgnSec, rpEmailContainer_lgnSec, rpEmailContainer_lgnSec, rpPasswordContainer_lgnSec);
            SetupInputFieldFocus(txtPasswordInput_lgnSec, rpPasswordContainer_lgnSec, rpEmailContainer_lgnSec, rpPasswordContainer_lgnSec);
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
