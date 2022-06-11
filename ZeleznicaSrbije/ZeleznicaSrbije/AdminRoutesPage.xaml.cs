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
using ZeleznicaSrbije.model;

namespace ZeleznicaSrbije
{
    /// <summary>
    /// Interaction logic for AdminRoutesPage.xaml
    /// </summary>
    public partial class AdminRoutesPage : Page
    {
        Frame f;
        public AdminRoutesPage(Frame f)
        {
            InitializeComponent();
            this.f = f;
        }

        public void NavigateToCreate(object sender, RoutedEventArgs e)
        {
            f.Content = new CreateRoutePage();
        }

        public void NavigateToEdit(object sender, RoutedEventArgs e)
        {

        }

        public void OpenDeleteModal(object sender, RoutedEventArgs e)
        {
            DeleteModal.IsOpen = true; 
        }
        public void CloseDeleteModal(object sender, RoutedEventArgs e)
        {
            DeleteModal.IsOpen = false;
        }

        public void DeleteRoute(object sender, RoutedEventArgs e)
        {
            // ovde ide kod za brisanje vozne linije
        }

    }
}
