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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZeleznicaSrbije
{
    /// <summary>
    /// Interaction logic for ReservationPage.xaml
    /// </summary>
    public partial class ReservationPage : Page
    {
        public ReservationPage()
        {
            InitializeComponent();
            OriginPicker.ItemsSource = SystemData.getStationNames();
            DestinationPicker.ItemsSource = SystemData.getStationNames();
        }

        public void Search()
        {
            String origin = OriginPicker.SelectedItem.ToString();
            String destination = DestinationPicker.SelectedItem.ToString();
        }
        
    }
}
