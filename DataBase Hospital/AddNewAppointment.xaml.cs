using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DataBase_Hospital
{
    public partial class AddNewAppointment : Window
    {
        private readonly Appointment _appointment = new Appointment();

        public AddNewAppointment()
        {
            InitializeComponent();
            ComboBoxCabinet.ItemsSource =
                StaticDataContext.HospitalContext.Cabinets
                    .Select(c => c.CabinetId)
                    .ToList();
            ComboBoxDoctor.ItemsSource =
                StaticDataContext.HospitalContext.Doctors
                    .Select(d => d.DoctorId)
                    .ToList();
            ComboBoxPatient.ItemsSource =
                StaticDataContext.HospitalContext.Patients
                    .Select(p => p.PatientId)
                    .ToList();
            ComboBoxIsHaveInfo.ItemsSource = new List<bool> { true, false };
            ComboBoxIsPaid.ItemsSource = new List<bool> { true, false };
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _appointment.StartDate = new DateTime(int.Parse(TextBoxYear.Text), int.Parse(TextBoxMonth.Text),
                    int.Parse(TextBoxDay.Text), int.Parse(TextBoxHour.Text), int.Parse(TextBoxMinute.Text), 0);
                _appointment.CabinetId = int.Parse(ComboBoxCabinet.Text);
                _appointment.Diagnosis = TextBoxDiagnose.Text;
                _appointment.IsExtendedInfo = bool.Parse(ComboBoxIsHaveInfo.Text);
                _appointment.IsPaid = bool.Parse(ComboBoxIsPaid.Text);
                _appointment.DoctorId = int.Parse(ComboBoxDoctor.Text);
                _appointment.PatientId = int.Parse(ComboBoxPatient.Text);
                _appointment.Sum = int.Parse(TextBoxPayment.Text);
                StaticDataContext.HospitalContext.Appointments.Add(_appointment);
                new MainWindow().UpdateAppointmentDataGrid();
            }
            catch (FormatException)
            {
                new TryAgainWindow().Show();
            }
            catch (NullReferenceException)
            {
                new TryAgainWindow().Show();
            }
        }
    }
}
