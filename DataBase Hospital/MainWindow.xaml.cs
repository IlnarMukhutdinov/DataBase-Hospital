using System.ComponentModel;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;

namespace DataBase_Hospital
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<HospitalContext>());
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            StaticDataContext.HospitalContext.Dispose();
        }


        private void ItemDoctor_OnSelected(object sender, RoutedEventArgs e)
        {
            BtnAddNewData.IsEnabled = true;
            BtnUpdateDb.IsEnabled = true;
            StaticDataContext.HospitalContext.Doctors.Load();
            MainGrid.ItemsSource = StaticDataContext.HospitalContext.Doctors
                .Local
                .ToBindingList();
        }

        private void ItemPatient_OnSelected(object sender, RoutedEventArgs e)
        {
            BtnAddNewData.IsEnabled = true;
            BtnUpdateDb.IsEnabled = true;
            StaticDataContext.HospitalContext.Patients.Load();
            MainGrid.ItemsSource = StaticDataContext.HospitalContext.Patients
                .Local
                .ToBindingList();
        }

        private void ItemShedule_OnSelected(object sender, RoutedEventArgs e)
        {
            BtnAddNewData.IsEnabled = true;
            BtnUpdateDb.IsEnabled = true;
            StaticDataContext.HospitalContext.Shedules.Load();
            MainGrid.ItemsSource = StaticDataContext.HospitalContext.Shedules
                .Local
                .ToBindingList();
        }

        private void ItemCabinet_OnSelected(object sender, RoutedEventArgs e)
        {
            BtnAddNewData.IsEnabled = true;
            BtnUpdateDb.IsEnabled = true;
            StaticDataContext.HospitalContext.Cabinets.Load();
            MainGrid.ItemsSource = StaticDataContext.HospitalContext.Cabinets
                .Local
                .ToBindingList();
        }

        private void ItemAppointment_OnSelected(object sender, RoutedEventArgs e)
        {
            BtnAddNewData.IsEnabled = true;
            BtnUpdateDb.IsEnabled = true;
            StaticDataContext.HospitalContext.Appointments.Load();
            MainGrid.ItemsSource = StaticDataContext.HospitalContext.Appointments
                .Local
                .ToBindingList();
        }

        private void MainGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string displayName = GetPropertyDisplayName(e.PropertyDescriptor);
            if (!string.IsNullOrEmpty(displayName))
            {
                e.Column.Header = displayName;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private string GetPropertyDisplayName(object ePropertyDescriptor)
        {
            if (ePropertyDescriptor is PropertyDescriptor pd)
            {
                if (pd.Attributes[typeof(DisplayNameAttribute)] is DisplayNameAttribute displayName && displayName != DisplayNameAttribute.Default)
                {
                    return displayName.DisplayName;
                }
            }

            return null;
        }

        public void UpdateDoctorDataGrid()
        {
            MainGrid.ItemsSource = StaticDataContext.HospitalContext.Doctors.Local.ToBindingList();
        }

        public void UpdatePatientDataGrid()
        {
            MainGrid.ItemsSource = StaticDataContext.HospitalContext.Patients.Local.ToBindingList();
        }

        public void UpdateSheduleDataGrid()
        {
            MainGrid.ItemsSource = StaticDataContext.HospitalContext.Shedules.Local.ToBindingList();
        }

        public void UpdateCabinetDataGrid()
        {
            MainGrid.ItemsSource = StaticDataContext.HospitalContext.Cabinets.Local.ToBindingList();
        }

        public void UpdateAppointmentDataGrid()
        {
            MainGrid.ItemsSource = StaticDataContext.HospitalContext.Appointments.Local.ToBindingList();
        }

        private void BtnAddNewData_OnClick(object sender, RoutedEventArgs e)
        {
            if (ItemDoctor.IsSelected)
            {
                new AddNewDoctor().Show();
            }
            else if (ItemPatient.IsSelected)
            {
                new AddNewPatient().Show();
            }
            else if (ItemShedule.IsSelected)
            {
                new AddNewShedule().Show();
            }
            else if (ItemCabinet.IsSelected)
            {
                new AddNewCabinet().Show();
            }
            else
            {
                new AddNewAppointment().Show();
            }
        }

        private void BtnUpdateDb_OnClick(object sender, RoutedEventArgs e)
        {
            StaticDataContext.HospitalContext.SaveChanges();
        }

        private void ItemFindDoctorBySecondName_OnSelected(object sender, RoutedEventArgs e)
        {
            new FindDoctorBySecondName { Owner = this }.Show();
        }

        private void ItemFindDoctorBySpeciality_OnSelected(object sender, RoutedEventArgs e)
        {
            new FindDoctorBySpeciality { Owner = this }.Show();
        }

        private void ItemFindDoctorByShedule_OnSelected(object sender, RoutedEventArgs e)
        {
            new FindDoctorByShedule { Owner = this }.Show();
        }

        private void ItemFindPatientBySecondName_OnSelected(object sender, RoutedEventArgs e)
        {
            new FindPatientBySecondName { Owner = this }.Show();
        }

        private void ItemFindPatientByGender_OnSelected(object sender, RoutedEventArgs e)
        {
            new FindPatientByGender { Owner = this }.Show();
        }

        private void ItemFindAppointmentByPayment_OnSelected(object sender, RoutedEventArgs e)
        {
            new FindAppointmentByPayment { Owner = this }.Show();
        }

        private void ItemFinAppointmentByDiagnosis_OnSelected(object sender, RoutedEventArgs e)
        {
            new FindAppointmentByDiagnosis { Owner = this }.Show();
        }
    }
}
