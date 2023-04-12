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
            var query = "SELECT * FROM Cage ";
            string material = "";
            if (Material_drop.SelectedIndex != -1) 
            {
                material = Material_drop.SelectedItem.ToString().Split(':')[1].TrimStart();
            }
            
            var serial = this.serialnumber_tb.Text;
            var whereClause = "";

            if (!string.IsNullOrEmpty(material))
            {
                if (material == "Iron")
                {
                    whereClause += "WHERE Material LIKE '%Iron%'";
                } else if (material == "Wood")
                {
                    whereClause += "WHERE Material LIKE '%Wood%'";
                } else
                {
                    whereClause += "WHERE Material LIKE '%Plastic%'";
                }
                
            }

            if (!string.IsNullOrEmpty(serial))
            {
                if (whereClause == "")
                {
                    Console.WriteLine("DEBUG");
                    whereClause += "WHERE ";
                }
                else
                {
                    whereClause += " AND ";
                }

                whereClause += "SerialNumber = @serial";

                if (!string.IsNullOrEmpty(whereClause))
                {
                    query += " " + whereClause;
                }
            }
                BirdsControlDBEntities db = new BirdsControlDBEntities();
                Console.WriteLine(query);
                var results = db.Cage.SqlQuery(query,
                    new SqlParameter("@material", material),
                    new SqlParameter("@serial", serial)).ToList();

                this.gridBird.ItemsSource = results.ToList();
                
            
        }

        private void HomePage_btn_Click(object sender, RoutedEventArgs e)
        {
            MainPage newWindow = new MainPage();
            this.Visibility = Visibility.Hidden;
            newWindow.Show();
        }
    }
}