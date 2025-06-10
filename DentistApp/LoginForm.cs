using System;
using System.Data.SQLite;
using System.Windows.Forms;
using DentistApp.Data;

namespace DentistApp
{
    public partial class LoginForm : Form
    {
        private readonly ApplicationContext _context;
        public LoginForm()
        {
            InitializeComponent();
            _context = new ApplicationContext("Data Source=dentist.db");
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            using var connection = _context.GetConnection();
            connection.Open();
            var command = new SQLiteCommand("SELECT * FROM Users WHERE Name=@name AND Password=@pass", connection);
            command.Parameters.AddWithValue("@name", nameTextBox.Text);
            command.Parameters.AddWithValue("@pass", passwordTextBox.Text);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                string role = reader["Role"].ToString() ?? "";
                int id = Convert.ToInt32(reader["Id"]);
                if (role == "doctor")
                {
                    Hide();
                    new DoctorForm(_context).ShowDialog();
                    Show();
                }
                else
                {
                    Hide();
                    new PatientForm(_context, id).ShowDialog();
                    Show();
                }
            }
            else
            {
                MessageBox.Show("Błędne dane logowania");
            }
        }
    }
}
