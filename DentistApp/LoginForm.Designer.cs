using System.Windows.Forms;

namespace DentistApp
{
    partial class LoginForm
    {
        private TextBox nameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Label nameLabel;
        private Label passwordLabel;

        private void InitializeComponent()
        {
            nameTextBox = new TextBox { Left = 100, Top = 20, Width = 200 };
            passwordTextBox = new TextBox { Left = 100, Top = 60, Width = 200, PasswordChar = '*' };
            loginButton = new Button { Left = 100, Top = 100, Text = "Zaloguj" };
            loginButton.Click += loginButton_Click;
            nameLabel = new Label { Left = 20, Top = 20, Text = "Nazwa" };
            passwordLabel = new Label { Left = 20, Top = 60, Text = "Hasło" };
            Controls.Add(nameLabel);
            Controls.Add(passwordLabel);
            Controls.Add(nameTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(loginButton);
            Text = "Logowanie";
        }
    }
}
