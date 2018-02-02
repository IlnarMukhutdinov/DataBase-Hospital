using System;
using System.Collections.Generic;
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
    public partial class FindDoctorBySpeciality : Window
    {
        public FindDoctorBySpeciality()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mw = Owner as MainWindow;
            try
            {
                mw.MainGrid.ItemsSource = StaticDataContext.HospitalContext.Doctors
                    .Where(d => d.Speciality == TextBox.Text).ToList();
            }
            catch (FormatException)
            {
                new TryAgainWindow().Show();
            }
        }
    }
}
