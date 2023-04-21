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

namespace BirdsControl
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class AddBirdPage : Page
    {
        public AddBirdPage()
        {
            InitializeComponent();
        }
        private void AddBird_btn_Click(object sender, RoutedEventArgs e)
        {
            BirdsControlDBEntities db = new BirdsControlDBEntities();

            Bird birdObject = new Bird()
            {
                Specie = species_tb.Text,
                SubSpecie = subspecies_tb.Text,
                HatchingDate = datePicker.SelectedDate.Value,
                Sex = sex_tb.Text,
                CageNumber = cage_tb.Text
            };
            var result = from cage in db.Cage
                         where (cage_tb.Text == cage.SerialNumber)
                         select cage;

            if (!result.Any())
            {
                MessageBox.Show("The cage number Does not exist");
            }
            else
            {
                db.Bird.Add(birdObject);
                db.SaveChanges();
                this.gridBird.ItemsSource = db.Bird.ToList();
            }
        }

        private void HomePage_btn_Click(object sender, RoutedEventArgs e)
        {
            MainPage newWindow = new MainPage();
            this.Visibility = Visibility.Hidden;
            newWindow.Show();

        }
    }
}