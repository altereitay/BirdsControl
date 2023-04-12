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

        /*private void Search_bird_Click(object sender, RoutedEventArgs e)
        {
            var query = "SELECT * From Bird";
            var specie = this.species_tb.Text;
            var sub = this.subspecies_tb.Text;
            var date = this.datePicker.Text;
            var sex = this.sex_tb.Text;
            var cage = this.cage_tb.Text;
            var whereClause = "";

            if (!string.IsNullOrEmpty(specie))
            {
                whereClause += "WHERE Specie = '" + specie + "'";
            }

            if (!string.IsNullOrEmpty(sub))
            {
                if (string.IsNullOrEmpty(whereClause))
                {
                    whereClause += "WHERE ";
                }
                else
                {
                    whereClause += " AND ";
                }
                whereClause += "SubSpice = '" + sub + "'";
            }
            
            if (!string.IsNullOrEmpty(date))
            {
                if (string.IsNullOrEmpty(whereClause))
                {
                    whereClause += "WHERE ";
                }
                else
                {
                    whereClause += " AND ";
                }
                whereClause += "HatchingDay = '" + date + "'";
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
                whereClause += "Sex = '" + sex + "'";
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
                whereClause += "Cage = '" + cage + "'";
            }
            
            if (!string.IsNullOrEmpty(whereClause))
            {
                query += " " + whereClause;
            }


            using (BirdsControlDBEntities db = new BirdsControlDBEntities())
            {
                // Console.WriteLine(query);
                var results = db.Bird.SqlQuery(query).ToList();
                this.gridBird.ItemsSource = results.ToList();
            }
        }*/
        private void Search_bird_Click(object sender, RoutedEventArgs e)
{
    var query = "SELECT * FROM Bird";
    var specie = SanitizeInput(this.species_tb.Text);
    var sub = SanitizeInput(this.subspecies_tb.Text);
    var date = SanitizeInput(this.datePicker.Text);
    var sex = SanitizeInput(this.sex_tb.Text);
    var cage = SanitizeInput(this.cage_tb.Text);
    var whereClause = "";

    if (!string.IsNullOrEmpty(specie))
    {
        whereClause += "WHERE Specie = @specie";
    }

    if (!string.IsNullOrEmpty(sub))
    {
        if (string.IsNullOrEmpty(whereClause))
        {
            whereClause += "WHERE ";
        }
        else
        {
            whereClause += " AND ";
        }
        whereClause += "SubSpecie = @sub";
    }

    if (!string.IsNullOrEmpty(date))
    {
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

    using (BirdsControlDBEntities db = new BirdsControlDBEntities())
    {
        var results = db.Bird.SqlQuery(query,
            new SqlParameter("@specie", specie),
            new SqlParameter("@sub", sub),
            new SqlParameter("@date", date),
            new SqlParameter("@sex", sex),
            new SqlParameter("@cage", cage)).ToList();
        Console.WriteLine(results);
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