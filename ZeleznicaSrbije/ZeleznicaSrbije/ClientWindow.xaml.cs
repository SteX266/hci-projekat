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
    public partial class ClientWindow : Window
    {
        
        public ClientWindow()
        {
            InitializeComponent();
            ClientContentFrame.Content = new TicketsPage();
        }

        public void OnReservationClick(object sender, RoutedEventArgs e)
        {
            ClientContentFrame.Content = new ReservationPage();
        }

        private void HamburgerMenuItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }

    
}
