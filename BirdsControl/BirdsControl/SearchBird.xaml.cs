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


        private void HomePage_btn_Click(object sender, RoutedEventArgs e)
        {
            MainPage newWindow = new MainPage();
            this.Visibility = Visibility.Hidden;
            newWindow.Show();
        }
    }
}