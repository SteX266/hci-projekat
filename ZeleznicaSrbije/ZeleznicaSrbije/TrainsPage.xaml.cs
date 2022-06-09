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
    /// Interaction logic for TrainsPage.xaml
    /// </summary>
    public partial class TrainsPage : Page
    {
        public TrainsPage()
        {
            InitializeComponent();
        }
        public void OpenCreateModal(object sender, RoutedEventArgs e)
        {
            CreateModal.IsOpen = true;
        }

        public void CloseCreateModal(object sender, RoutedEventArgs e)
        {
            CreateModal.IsOpen = false;
        }

        public void CreateTrain(object sender, RoutedEventArgs e)
        {
            // ovde ide logika za kreiranje voza
        }


        public void OpenEditModal(object sender, RoutedEventArgs e)
        {
            EditModal.IsOpen = true;
        }

        public void CloseEditModal(object sender, RoutedEventArgs e)
        {
            EditModal.IsOpen = false;
        }

        public void EditTrain(object sender, RoutedEventArgs e)
        {
            // ovde ide logika za azuriranje voza
        }

        public void OpenDeleteModal(object sender, RoutedEventArgs e)
        {
            DeleteModal.IsOpen = true;  
        }

        public void CloseDeleteModal(object sender, RoutedEventArgs e)
        {
            DeleteModal.IsOpen = false;
        }
        public void DeleteTrain(object sender, RoutedEventArgs e)
        {
            // ovde ide logika za brisanje voza
        }
    }
}
