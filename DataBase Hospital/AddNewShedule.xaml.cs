using System;
using System.Windows;

namespace DataBase_Hospital
{
    /// <summary>
    /// Логика взаимодействия для AddNewShedule.xaml
    /// </summary>
    public partial class AddNewShedule : Window
    {
        private readonly Shedule _shedule = new Shedule();

        public AddNewShedule()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _shedule.WorkDays = TextBoxWorkDays.Text;
                _shedule.Weekend = TextBoxWeekend.Text;
                _shedule.Notes = TextBoxNote.Text;
                StaticDataContext.HospitalContext.Shedules.Add(_shedule);
                new MainWindow().UpdateSheduleDataGrid();
            }
            catch (NullReferenceException)
            {
                new TryAgainWindow().Show();
            }
        }
    }
}
