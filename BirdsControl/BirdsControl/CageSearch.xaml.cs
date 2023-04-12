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
    /// Interaction logic for CageSearch.xaml
    /// </summary>
    public partial class CageSearch : Window
    {
        public CageSearch()
        {
            InitializeComponent();
        }

        private void Search_bird_Click(object sender, RoutedEventArgs e)
        {
            var query = "SELECT * FROM Bird";
            var material = SanitizeInput(this.material_tb.Text);
            var serial = SanitizeInput(this.serialnumber_tb.Text);
            var whereClause = "";

            if (!string.IsNullOrEmpty(material))
            {
                whereClause += "WHERE Material = @material";
            }

            if (!string.IsNullOrEmpty(serial))
            {
                if (string.IsNullOrEmpty(whereClause))
                {
                    whereClause += "WHERE ";
                }
                else
                {
                    whereClause += " AND ";
                }

                whereClause += "SerialNumber = @serial";

                using (BirdsControlDBEntities db = new BirdsControlDBEntities())
                {
                    var results = db.Cage.SqlQuery(query,
                        new SqlParameter("@material", material),
                        new SqlParameter("@serial", serial)).ToList();
                    this.gridBird.ItemsSource = results.ToList();
                }
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