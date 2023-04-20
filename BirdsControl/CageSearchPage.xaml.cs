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
    /// Interaction logic for CageSearchPage.xaml
    /// </summary>
    public partial class CageSearchPage : Page
    {
        MainPage mainPage;
        public CageSearchPage(MainPage mainPage)
        {
            InitializeComponent();
            this.mainPage = mainPage;
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
                }
                else if (material == "Wood")
                {
                    whereClause += "WHERE Material LIKE '%Wood%'";
                }
                else
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
            }
            if (!string.IsNullOrEmpty(whereClause))
            {
                query += " " + whereClause;
            }

            Console.WriteLine(query);
            BirdsControlDBEntities db = new BirdsControlDBEntities();
            Console.WriteLine(query);
            var results = db.Cage.SqlQuery(query,
                new SqlParameter("@material", material),
                new SqlParameter("@serial", serial)).ToList();

            this.gridBird.ItemsSource = results.ToList();
        }
        private void gridBird_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.gridBird.SelectedIndex >= 0 && this.gridBird.SelectedItems.Count >= 0)
            {
                if (this.gridBird.SelectedItems[0].GetType() == typeof(Cage))
                {
                    Cage t = (Cage)this.gridBird.SelectedItems[0];
                    CageInfoPage page = new CageInfoPage(t);

                    // Set the content of a Frame control on the parent window or page
                    mainPage.mainFrame.Content = page;
                }
            }

        }
    }
}
