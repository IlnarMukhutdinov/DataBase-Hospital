﻿using System;
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
    /// Логика взаимодействия для FindAppointmentByDiagnosis.xaml
    /// </summary>
    public partial class FindAppointmentByDiagnosis : Window
    {
        public FindAppointmentByDiagnosis()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mw = Owner as MainWindow;

            try
            {
                mw.MainGrid.ItemsSource = StaticDataContext.HospitalContext.Appointments
                    .Where(a => a.Diagnosis == TextBox.Text).ToList();
                Close();
            }
            catch (FormatException)
            {
                new TryAgainWindow().Show();
            }
        }
    }
}
