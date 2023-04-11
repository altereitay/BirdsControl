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

namespace BirdsControl
{
    /// <summary>
    /// Interaction logic for SearchBird.xaml
    /// </summary>
    public partial class SearchBird : Window
    {
        public SearchBird()
        {
            InitializeComponent();
        }

        private void Search_bird_Click(object sender, RoutedEventArgs e)
        {
            var query = "SELECT * From Bird";
            var specie = this.species_tb.Text;
            var sub = this.subspecies_tb.Text;
            var date = this.datePicker.Text;
            var sex = this.sex_tb.Text;
            var cage = this.cage_tb.Text;

            if (specie != "")
            {
                query += " WHERE Specie = '" + specie + "' ";
            }

            if (sub != "")
            {
                query += " WHERE SubSpice = '" + sub + "' ";
            }

            if (date != "")
            {
                query += " WHERE HatchingDay = '" + date + "' ";
            }

            if (sex != "")
            {
                query += " WHERE Sex = '" + sex + "' ";
            }

            if (cage != "")
            {
                query += " WHERE Cage = '" + cage + "' ";
            }

            using (BirdsControlDBEntities db = new BirdsControlDBEntities())
            {
                Console.WriteLine(query);
                var results = db.Bird.SqlQuery(query).ToList();
                this.gridBird.ItemsSource = results.ToList();
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