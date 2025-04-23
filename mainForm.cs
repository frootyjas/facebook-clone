    using System.Drawing.Text;

    namespace facebook_clone
    {
    public partial class mainForm : Form
    {

        private PanelManager _panelManager;
        private List<Tuple<RoundedPanel, RadioButton>> _genderOptions = new List<Tuple<RoundedPanel, RadioButton>>();

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
            ConfigureHoverEffect(lblSignUp_crtAcctSec, rpSignUpContainer_crtAcctSec,
             StyleConstants.DarkGreen, StyleConstants.SecondaryColor);
            ApplyFonts();
            ConfigureInputFields();

         

            // Remove blue highlight
            ConfigureComboBoxAppearance(cbbBirthday_crtAcctSec, 0);
            ConfigureComboBoxAppearance(cbbDay_crtAcctSec, 0);
            ConfigureComboBoxAppearance(cbbYear_crtAcctSec, 0);

            InitializeGenderOptions();
            SetupGenderSelection();


        }

        private void InitializeGenderOptions()
        {
            // Add all gender options to the list
            _genderOptions.Add(Tuple.Create(rpFemaleRadioContainer_crtAcctSec, rdFemale_crtAcctSec));
            _genderOptions.Add(Tuple.Create(rpMaleRadioContainer_crtAcctSec, rdMale_crtAcctSec));
            //_genderOptions.Add(Tuple.Create(rpCustomRadioContainer_crtAcctSec, rdCustom_crtAcctSec));

            // Set initial state
            SetGenderSelection(rdFemale_crtAcctSec);
        }

        private void SetupGenderSelection()
        {
            foreach (var option in _genderOptions)
            {
                // Handle panel clicks
                option.Item1.Click += (s, e) => SelectGender(option.Item2);

                // Handle radio button clicks
                option.Item2.Click += (s, e) => SelectGender(option.Item2);

                // Prevent automatic checking so we can control the behavior
                option.Item2.AutoCheck = false;
            }
        }

        private void SelectGender(RadioButton selectedRadio)
        {
            foreach (var option in _genderOptions)
            {
                bool isSelected = option.Item2 == selectedRadio;

                // Update radio button state
                option.Item2.Checked = isSelected;

                // Update panel appearance
                option.Item1.BorderColor = isSelected ? Color.LightGray : Color.LightGray;
                option.Item1.BackColor = isSelected ? ColorTranslator.FromHtml("#00000000") : Color.White;
            }
        }

        private void SetGenderSelection(RadioButton defaultSelection)
        {
            defaultSelection.Checked = true;
            SelectGender(defaultSelection);
        }

        // Usage example: To get selected gender
        private string GetSelectedGender()
        {
            if (rdFemale_crtAcctSec.Checked) return "Female";
            if (rdMale_crtAcctSec.Checked) return "Male";
            if (rdCustom_crtAcctSec.Checked) return "Custom";
            return string.Empty;
        }

        private void ConfigureComboBoxAppearance(ComboBox combobox, int selected)
        {
            // Select first item automatically
            if (combobox.Items.Count > 0)
            {
                combobox.SelectedIndex = selected;
            }

            // Set these properties
            combobox.DrawMode = DrawMode.OwnerDrawFixed;
            combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox.DrawItem += Cbb_DrawItem;
        }

        private void Cbb_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ComboBox combo = sender as ComboBox;

            // Custom colors example
            Color backColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                ? ColorTranslator.FromHtml("#00000000")  // Transparent
                : ColorTranslator.FromHtml("#FFFFFF"); // White

            Color textColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                ? ColorTranslator.FromHtml("#383a3c")  // 
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
            txtFirstNameInput_crtAcctSec.Font = FontHelper.GetFont(StyleConstants.InputFontSize - 1);
            txtLastNameInput_crtAcctSec.Font = FontHelper.GetFont(StyleConstants.InputFontSize - 1);
            cbbBirthday_crtAcctSec.Font = FontHelper.GetFont(StyleConstants.InputFontSize - 1);
            cbbDay_crtAcctSec.Font = FontHelper.GetFont(StyleConstants.InputFontSize - 1);
            cbbYear_crtAcctSec.Font = FontHelper.GetFont(StyleConstants.InputFontSize - 1);
            lblFemale_crtAcctSec.Font = FontHelper.GetFont(StyleConstants.InputFontSize - 1);
            lblMale_crtAcctSec.Font = FontHelper.GetFont(StyleConstants.InputFontSize - 1);
            lblCustom_crtAcctSec.Font = FontHelper.GetFont(StyleConstants.InputFontSize - 1);
            txtEmailInput_crtAcctSec.Font = FontHelper.GetFont(StyleConstants.InputFontSize - 1);
            txtPasswordInput_crtAcctSec.Font = FontHelper.GetFont(StyleConstants.InputFontSize - 1);
            lnkAlreadyHaveAnAccount_crtAcctSec.Font = FontHelper.GetFont(StyleConstants.LinkFontSize + 1);
            lblSignUp_crtAcctSec.Font = FontHelper.GetFont(StyleConstants.ButtonFontSize - 1, FontStyle.Bold);
            lblContactInfoNotice.Font = FontHelper.GetFont(StyleConstants.NoticeFontSize);
            lblSignupAgreement.Font = FontHelper.GetFont(StyleConstants.NoticeFontSize);
        }

        private void ConfigureInputFields()
        {
            ConfigurePasswordField(txtPasswordInput_lgnSec);
            ConfigurePasswordField(txtPasswordInput_wlcSec);
            ConfigurePasswordField(txtPasswordInput_fgtSec);
            ConfigurePasswordField(txtPasswordInput_crtAcctSec);
        }

        private void SetupEventHandlers()
        {
            // Panel navigation
            lblCreateAccount.Click += (s, e) => _panelManager.ShowPanel(createAccountPanel);
            lnkAlreadyHaveAnAccount_crtAcctSec.Click += (s, e) => _panelManager.ShowPanel(pnlLoginSection);
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
