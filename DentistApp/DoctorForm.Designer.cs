using System;
using System.Windows.Forms;

namespace DentistApp
{
    partial class DoctorForm
    {
        private ListBox patientsListBox;
        private ListBox appointmentsListBox;
        private TextBox patientNameTextBox;
        private TextBox patientPassTextBox;
        private Button addPatientButton;
        private Button deletePatientButton;
        private Button deleteAppointmentButton;

        private void InitializeComponent()
        {
            Text = "Panel lekarza";
            Width = 600;
            Height = 400;

            patientsListBox = new ListBox { Left = 20, Top = 20, Width = 200, Height = 250 };
            appointmentsListBox = new ListBox { Left = 240, Top = 20, Width = 320, Height = 250 };

            patientNameTextBox = new TextBox { Left = 20, Top = 280, Width = 100 };
            patientPassTextBox = new TextBox { Left = 130, Top = 280, Width = 100 };
            addPatientButton = new Button { Left = 240, Top = 280, Text = "Dodaj pacjenta" };
            deletePatientButton = new Button { Left = 370, Top = 280, Text = "Usuń pacjenta" };
            deleteAppointmentButton = new Button { Left = 240, Top = 320, Text = "Usuń wizytę" };

            addPatientButton.Click += addPatientButton_Click;
            deletePatientButton.Click += deletePatientButton_Click;
            deleteAppointmentButton.Click += deleteAppointmentButton_Click;

            Controls.Add(patientsListBox);
            Controls.Add(appointmentsListBox);
            Controls.Add(patientNameTextBox);
            Controls.Add(patientPassTextBox);
            Controls.Add(addPatientButton);
            Controls.Add(deletePatientButton);
            Controls.Add(deleteAppointmentButton);
        }
    }
}
