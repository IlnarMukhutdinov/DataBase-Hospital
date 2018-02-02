using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace DataBase_Hospital
{
    public partial class FindDoctorBySecondName
    {
        public FindDoctorBySecondName()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow mw = Owner as MainWindow;
                mw.MainGrid.ItemsSource = StaticDataContext.HospitalContext.Doctors
                    .Where(d => d.SecondName == TextBox.Text).ToList();
                Close();
            }
            catch (FormatException)
            {
                new TryAgainWindow().Show();
            }
        }
    }
}
