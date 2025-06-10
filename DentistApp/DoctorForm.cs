using System;
using System.Data.SQLite;
using System.Windows.Forms;
using DentistApp.Data;

namespace DentistApp
{
    public partial class DoctorForm : Form
    {
        private readonly ApplicationContext _context;
        public DoctorForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
            LoadPatients();
            LoadAppointments();
        }

        private void addPatientButton_Click(object sender, EventArgs e)
        {
            using var connection = _context.GetConnection();
            connection.Open();
            var cmd = new SQLiteCommand("INSERT INTO Users(Name,Password,Role) VALUES(@n,@p,'patient')", connection);
            cmd.Parameters.AddWithValue("@n", patientNameTextBox.Text);
            cmd.Parameters.AddWithValue("@p", patientPassTextBox.Text);
            cmd.ExecuteNonQuery();
            LoadPatients();
        }

        private void deletePatientButton_Click(object sender, EventArgs e)
        {
            if (patientsListBox.SelectedItem is ListItem item)
            {
                using var connection = _context.GetConnection();
                connection.Open();
                var cmd = new SQLiteCommand("DELETE FROM Users WHERE Id=@id", connection);
                cmd.Parameters.AddWithValue("@id", item.Id);
                cmd.ExecuteNonQuery();
                cmd = new SQLiteCommand("DELETE FROM Appointments WHERE PatientId=@id", connection);
                cmd.Parameters.AddWithValue("@id", item.Id);
                cmd.ExecuteNonQuery();
                LoadPatients();
                LoadAppointments();
            }
        }

        private void deleteAppointmentButton_Click(object sender, EventArgs e)
        {
            if (appointmentsListBox.SelectedItem is ListItem item)
            {
                using var connection = _context.GetConnection();
                connection.Open();
                var cmd = new SQLiteCommand("DELETE FROM Appointments WHERE Id=@id", connection);
                cmd.Parameters.AddWithValue("@id", item.Id);
                cmd.ExecuteNonQuery();
                LoadAppointments();
            }
        }

        private void LoadPatients()
        {
            patientsListBox.Items.Clear();
            using var connection = _context.GetConnection();
            connection.Open();
            var cmd = new SQLiteCommand("SELECT Id, Name FROM Users WHERE Role='patient'", connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                patientsListBox.Items.Add(new ListItem
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Text = reader["Name"].ToString() ?? ""
                });
            }
        }

        private void LoadAppointments()
        {
            appointmentsListBox.Items.Clear();
            using var connection = _context.GetConnection();
            connection.Open();
            var cmd = new SQLiteCommand("SELECT Appointments.Id, Users.Name, Appointments.Date FROM Appointments JOIN Users ON Users.Id=Appointments.PatientId", connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                appointmentsListBox.Items.Add(new ListItem
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Text = $"{reader["Name"]} - {reader["Date"]}"
                });
            }
        }
    }

    class ListItem
    {
        public int Id { get; set; }
        public string Text { get; set; } = "";
        public override string ToString() => Text;
    }
}
