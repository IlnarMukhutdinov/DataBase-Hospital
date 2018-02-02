using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataBase_Hospital
{
    public partial class FindPatientBySecondName : Window
    {
        public FindPatientBySecondName()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow mw = Owner as MainWindow;
                mw.MainGrid.ItemsSource = StaticDataContext.HospitalContext.Patients
                    .Where(p => p.SecondName == TextBox.Text).ToList();
                Close();
            }
            catch (FormatException)
            {
                new TryAgainWindow().Show();
            }
        }
    }
}
