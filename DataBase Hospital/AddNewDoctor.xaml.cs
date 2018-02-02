using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace DataBase_Hospital
{
    public partial class AddNewDoctor : Window
    {
        private readonly Doctor _doctor = new Doctor();

        public AddNewDoctor()
        {
            InitializeComponent();
            ComboBoxGender.ItemsSource = new List<string> { "Мужской", "Женский" };
            ComboBoxShedule.ItemsSource = StaticDataContext.HospitalContext.Shedules
                .Select(s => s.SheduleId)
                .ToList();
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _doctor.FirstName = TextBoxFirstName.Text;
                _doctor.SecondName = TextBoxSecondName.Text;
                _doctor.LastName = TextBoxLastName.Text;
                _doctor.Gender = ComboBoxGender.Text;
                _doctor.Speciality = TextBoxSpeciality.Text;
                _doctor.SheduleId = int.Parse(ComboBoxShedule.Text);
                _doctor.Education = TextBoxEducation.Text;
                _doctor.BirthDay = new DateTime(int.Parse(TextBoxBirthYear.Text), int.Parse(TextBoxBirthMonth.Text), int.Parse(TextBoxBirthDay.Text));
                _doctor.StartDate = new DateTime(int.Parse(TextBoxJobYear.Text), int.Parse(TextBoxJobMonth.Text), int.Parse(TextBoxJobDay.Text));
                StaticDataContext.HospitalContext.Doctors.Add(_doctor);
                new MainWindow().UpdateDoctorDataGrid();
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
