using System;
using System.Windows.Forms;

namespace DentistApp
{
    partial class PatientForm
    {
        private ListBox appointmentsListBox;
        private Button addAppointmentButton;
        private Button deleteAppointmentButton;
        private DateTimePicker datePicker;

        private void InitializeComponent()
        {
            Text = "Panel pacjenta";
            Width = 400;
            Height = 300;

            appointmentsListBox = new ListBox { Left = 20, Top = 20, Width = 340, Height = 150 };
            datePicker = new DateTimePicker { Left = 20, Top = 180, Width = 200 };
            addAppointmentButton = new Button { Left = 240, Top = 180, Text = "Umów" };
            deleteAppointmentButton = new Button { Left = 240, Top = 220, Text = "Odwołaj" };

            addAppointmentButton.Click += addAppointmentButton_Click;
            deleteAppointmentButton.Click += deleteAppointmentButton_Click;

            Controls.Add(appointmentsListBox);
            Controls.Add(datePicker);
            Controls.Add(addAppointmentButton);
            Controls.Add(deleteAppointmentButton);
        }
    }
}
