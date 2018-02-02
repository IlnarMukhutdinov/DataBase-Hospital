using System;
using System.Collections.Generic;
using System.Windows;

namespace DataBase_Hospital
{
    public partial class AddNewPatient
    {

        private readonly Patient _patient = new Patient();
        
        public AddNewPatient()
        {
            InitializeComponent();
            ComboBoxGender.ItemsSource = new List<string> {"Мужской", "Женский"};
            ComboBoxIsHaveCard.ItemsSource = new List<bool> {true, false};
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _patient.FirstName = TextBoxFirstName.Text;
                _patient.SecondName = TextBoxSecondName.Text;
                _patient.LastName = TextBoxLastName.Text;
                _patient.Gender = ComboBoxGender.Text;
                _patient.BirthDay = new DateTime(int.Parse(TextBoxBirthYear.Text), int.Parse(TextBoxBirthMonth.Text), int.Parse(TextBoxBirthDay.Text));
                StaticDataContext.HospitalContext.Patients.Add(_patient);
                new MainWindow().UpdateDoctorDataGrid();
            }
            catch (NullReferenceException)
            {
                new TryAgainWindow().Show();
            }
        }
    }
}
