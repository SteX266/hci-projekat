﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window


    {
        public Frame Frame { get; set; }
        public MainWindow()
        {
            SystemData.fillData();
            InitializeComponent();
        }

        private void LocalLoginButton_Click(object sender, RoutedEventArgs e)
        {

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            foreach (Client c in SystemData.clients)
            {
                if (c.username == username && c.password == password)
                {
                    SystemData.setUser(c);
                    ClientWindow clientWindow = new ClientWindow();
                    clientWindow.Show();
                }

            }
            foreach(Admin a in SystemData.admins)
            {
                if (a.username == username && a.password == password)
                {
                    SystemData.setUser(a);
                    //TODO SHOW ADMIN WINDOW
                }
            }


        }

        private void CheckBoxChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
