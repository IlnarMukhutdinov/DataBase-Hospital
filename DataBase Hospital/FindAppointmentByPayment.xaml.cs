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
    /// <summary>
    /// Логика взаимодействия для FindAppointmentByPayment.xaml
    /// </summary>
    public partial class FindAppointmentByPayment : Window
    {
        public FindAppointmentByPayment()
        {
            InitializeComponent();
            ComboBox.ItemsSource = new List<bool> { true, false };
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            bool b = bool.Parse(ComboBox.Text);
            MainWindow mw = Owner as MainWindow;
            try
            {
                mw.MainGrid.ItemsSource =
                    StaticDataContext.HospitalContext.Appointments.Where(a => a.IsPaid == b).ToList();
                Close();
            }
            catch (FormatException)
            {
                new TryAgainWindow().Show();
            }
        }
    }
}
