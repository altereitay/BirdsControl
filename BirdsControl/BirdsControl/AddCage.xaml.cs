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
using System.Windows.Shapes;

namespace BirdsControl
{
    /// <summary>
    /// Interaction logic for AddCage.xaml
    /// </summary>
    public partial class AddCage : Window
    {
        public AddCage()
        {
            InitializeComponent();
        }

        private void AddCage_btn_Click(object sender, RoutedEventArgs e)
        {
            BirdsControlDBEntities db = new BirdsControlDBEntities();

            Cage cageObject = new Cage()
            {
                SerialNumber = SerialNumber_tb.Text,
                Length = int.Parse(Length_tb.Text),
                Width = int.Parse(Width_tb.Text),
                Height = int.Parse(Height_tb.Text),
                Material = Material_drop.SelectedItem.ToString().Split(':')[1]
                };
            db.Cage.Add(cageObject);
            db.SaveChanges();

            this.gridCage.ItemsSource = db.Cage.ToList();
        }

        private void HomePage_btn_Click(object sender, RoutedEventArgs e)
        {
            MainPage newWindow = new MainPage();
            this.Visibility = Visibility.Hidden;
            newWindow.Show();
        }
    }
}
