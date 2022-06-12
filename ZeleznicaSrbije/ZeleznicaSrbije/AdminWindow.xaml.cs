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
          //  mainWindow.Hide();
            InitializeComponent();
        }

        private void reports_selected(object sender, RoutedEventArgs e)
        {
            ClientContentFrame.Content = new ReportPage();

        }
        private void trains_selected(object sender, RoutedEventArgs e)
        {
            ClientContentFrame.Content = new TrainsPage();
        }
        private void timetable_selected(object sender, RoutedEventArgs e)
        {
            ClientContentFrame.Content = new AdminTimeTablePage();
        }
        private void lines_selected(object sender, RoutedEventArgs e)
        {
            
            ClientContentFrame.Content = new AdminRoutesPage(ClientContentFrame);
        }
        private void logout_selected(object sender, RoutedEventArgs e)
        {
            this.Close();
            mainWindow.Show();
        }

    }
}
