using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for SearchBirdPage.xaml
    /// </summary>
    public partial class SearchBirdPage : Page
    {
        MainPage m1;
        public SearchBirdPage(MainPage m1)
        {
            this.m1 = m1;
            InitializeComponent();
            
        }
        private void Search_bird_Click(object sender, RoutedEventArgs e)
        {
            var query = "SELECT * FROM Bird";
            var specie = SanitizeInput(this.species_tb.Text);
            var id = SanitizeInput(this.id_tb.Text);
            var dateString = SanitizeInput(this.datePicker.Text);
            DateTime date = default;
            var sex = SanitizeInput(this.sex_tb.Text);
            var cage = SanitizeInput(this.cage_tb.Text);
            var whereClause = "";

            if (!string.IsNullOrEmpty(specie))
            {
                whereClause += "WHERE Specie = @specie";
            }

            if (!string.IsNullOrEmpty(id))
            {
                if (string.IsNullOrEmpty(whereClause))
                {
                    whereClause += "WHERE ";
                }
                else
                {
                    whereClause += " AND ";
                }

                whereClause += "Id = @id";
            }

            if (!string.IsNullOrEmpty(dateString))
            {
                date = DateTime.Parse(dateString);
                if (string.IsNullOrEmpty(whereClause))
                {
                    whereClause += "WHERE ";
                }
                else
                {
                    whereClause += " AND ";
                }

                whereClause += "HatchingDate = @date";
            }

            if (!string.IsNullOrEmpty(sex))
            {
                if (string.IsNullOrEmpty(whereClause))
                {
                    whereClause += "WHERE ";
                }
                else
                {
                    whereClause += " AND ";
                }

                whereClause += "Sex = @sex";
            }

            if (!string.IsNullOrEmpty(cage))
            {
                if (string.IsNullOrEmpty(whereClause))
                {
                    whereClause += "WHERE ";
                }
                else
                {
                    whereClause += " AND ";
                }

                whereClause += "CageNumber = @cage";
            }

            if (!string.IsNullOrEmpty(whereClause))
            {
                query += " " + whereClause;
            }

            if (date == default)
            {
                using (BirdsControlDBEntities db = new BirdsControlDBEntities())
                {
                    var results = db.Bird.SqlQuery(query,
                        new SqlParameter("@specie", specie),
                        new SqlParameter("@id", id),
                        new SqlParameter("@date", dateString),
                        new SqlParameter("@sex", sex),
                        new SqlParameter("@cage", cage)).ToList();
                    this.gridBird.ItemsSource = results.ToList();
                }
                return;
            }
            using (BirdsControlDBEntities db = new BirdsControlDBEntities())
            {
                var results = db.Bird.SqlQuery(query,
                    new SqlParameter("@specie", specie),
                    new SqlParameter("@id", id),
                    new SqlParameter("@date", date),
                    new SqlParameter("@sex", sex),
                    new SqlParameter("@cage", cage)).ToList();
                this.gridBird.ItemsSource = results.ToList();
            }
        }

        private string SanitizeInput(string input)
        {
            return input.Replace("'", "''");
        }

        private void gridBird_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.gridBird.SelectedIndex >= 0 && this.gridBird.SelectedItems.Count >= 0)
            {
                if (this.gridBird.SelectedItems[0].GetType() == typeof(Bird))
                {
                   
                    Bird t = (Bird)this.gridBird.SelectedItems[0];
                    BirdInfoPage page = new BirdInfoPage(t, m1);
                    m1.mainFrame.Content = page;
                }
            }
        }
    }
}
