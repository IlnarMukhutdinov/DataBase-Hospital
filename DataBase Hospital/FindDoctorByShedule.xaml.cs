using System;
using System.Linq;
using System.Windows;

namespace DataBase_Hospital
{
    /// <summary>
    /// Логика взаимодействия для FindDoctorByShedule.xaml
    /// </summary>
    public partial class FindDoctorByShedule
    {
        public FindDoctorByShedule()
        {
            InitializeComponent();
            ComboBox.ItemsSource = StaticDataContext.HospitalContext.Shedules.Select(s => s.SheduleId).ToList();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(ComboBox.Text);
            MainWindow mw = Owner as MainWindow;
            try
            {
                mw.MainGrid.ItemsSource =
                    StaticDataContext.HospitalContext.Doctors.Where(d => d.SheduleId == num).ToList();
                Close();
            }
            catch (FormatException)
            {
                new TryAgainWindow().Show();
            }
        }
    }
}
