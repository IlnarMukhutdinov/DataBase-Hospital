using System.Windows;

namespace DataBase_Hospital
{
    public partial class TryAgainWindow
    {
        public TryAgainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
