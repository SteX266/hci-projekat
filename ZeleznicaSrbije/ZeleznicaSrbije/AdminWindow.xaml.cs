using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        MainWindow mainWindow;
        public AdminWindow(MainWindow mw)
        {
            this.mainWindow = mw;
            mainWindow.Hide();
            InitializeComponent();
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
            //TimetablePage
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
