using System;
using System.Windows;

namespace DataBase_Hospital
{
    public partial class AddNewCabinet : Window
    {

        private readonly Cabinet _cabinet = new Cabinet();

        public AddNewCabinet()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _cabinet.Shedule = TextBoxShedule.Text;
                _cabinet.CabinetBound = TextBoxCabinetBound.Text;
                _cabinet.Phone = int.Parse(TextBoxPhone.Text);
                StaticDataContext.HospitalContext.Cabinets.Add(_cabinet);
                new MainWindow().UpdateCabinetDataGrid();
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
