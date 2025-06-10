using System;
using System.Data.SQLite;
using System.Windows.Forms;
using DentistApp.Data;

namespace DentistApp
{
    public partial class PatientForm : Form
    {
        private readonly ApplicationContext _context;
        private readonly int _patientId;
        public PatientForm(ApplicationContext context, int patientId)
        {
            _context = context;
            _patientId = patientId;
            InitializeComponent();
            LoadAppointments();
        }

        private void addAppointmentButton_Click(object sender, EventArgs e)
        {
            using var connection = _context.GetConnection();
            connection.Open();
            var cmd = new SQLiteCommand("INSERT INTO Appointments(PatientId,Date) VALUES(@p,@d)", connection);
            cmd.Parameters.AddWithValue("@p", _patientId);
            cmd.Parameters.AddWithValue("@d", datePicker.Value);
            cmd.ExecuteNonQuery();
            LoadAppointments();
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

        private void LoadAppointments()
        {
            appointmentsListBox.Items.Clear();
            using var connection = _context.GetConnection();
            connection.Open();
            var cmd = new SQLiteCommand("SELECT Id, Date FROM Appointments WHERE PatientId=@p", connection);
            cmd.Parameters.AddWithValue("@p", _patientId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                appointmentsListBox.Items.Add(new ListItem
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Text = reader["Date"].ToString() ?? ""
                });
            }
        }
    }
}
