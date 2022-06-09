﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ZeleznicaSrbije
{
    public partial class ClientWindow : Window
    {
        MainWindow mainWindow;
        public ClientWindow(MainWindow mw)
        {
            mainWindow = mw;
        //    mainWindow.Hide();
            InitializeComponent();

            ClientContentFrame.Content = new TicketsPage();
        }

        public void OnReservationClick(object sender, RoutedEventArgs e)
        {
            ClientContentFrame.Content = new ReservationPage();
        }
        public void OnTicketsClick(object sender, RoutedEventArgs e)
        {
            ClientContentFrame.Content = new TicketsPage();
        }
        public void OnTimetableClick(object sender, RoutedEventArgs e)
        {
            ClientContentFrame.Content = new TimetablePage();
        }
        public void OnRoutesClick(object sender, RoutedEventArgs e)
        {
            ClientContentFrame.Content = new RoutesPage();
        }

        private void tickets_selected(object sender, RoutedEventArgs e)
        {
            ClientContentFrame.Content = new TicketsPage();

        }
        private void reservations_selected(object sender, RoutedEventArgs e)
        {
            ClientContentFrame.Content = new ReservationPage();
        }
        private void timetable_selected(object sender, RoutedEventArgs e)
        {
            ClientContentFrame.Content = new TimetablePage();
        }
        private void lines_selected(object sender, RoutedEventArgs e)
        {
            //LinesPage
        }
        private void logout_selected(object sender, RoutedEventArgs e)
        {
            this.Close();
            mainWindow.Show();
        }
    }

    
}
