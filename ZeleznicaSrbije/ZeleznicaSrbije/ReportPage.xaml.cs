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
    /// Interaction logic for ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        public ReportPage()
        {
            InitializeComponent();
        }
        private void OpenLineChoiceModal(object sender, RoutedEventArgs e)
        {
            LineChoiceModal.IsOpen = true;
        }

        private void CloseLineChoiceModal(object sender, RoutedEventArgs e)
        {
            LineChoiceModal.IsOpen = false;
        }

        private void LineReport(object sender, RoutedEventArgs e)
        {
            // ovde ide logika za izvestaj po liniji
        }

        private void MonthlyReport(object sender, RoutedEventArgs e)
        {
            // ovde ide logika za mesecni izvestaj
        }
    }
}
