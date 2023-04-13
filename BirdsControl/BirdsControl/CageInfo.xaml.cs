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
    /// Interaction logic for CageInfo.xaml
    /// </summary>
    public partial class CageInfo : Window
    {
        public CageInfo(Cage c)
        {
            InitializeComponent();
            this.SerialNumber_tb.Text = c.SerialNumber;
            this.Length_tb.Text = c.Length.ToString();
            this.Width_tb.Text = c.Width.ToString();
            this.Height_tb.Text = c.Height.ToString();
            this.Material_tb.Text = c.Material.ToString();
        }

        private void LoadBirds_btn_Click(object sender, RoutedEventArgs e)
        {

            BirdsControlDBEntities db = new BirdsControlDBEntities();
            var result =from bird in db.Bird where bird.CageNumber== this.SerialNumber_tb.Text
                        select bird;

            this.gridCage.ItemsSource = result.ToList();
        }

        private void HomePage_btn_Click(object sender, RoutedEventArgs e)
        {
            MainPage newWindow = new MainPage();
            this.Visibility = Visibility.Hidden;
            newWindow.Show();
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            CageSearch newWindow = new CageSearch();
            this.Visibility = Visibility.Hidden;
            newWindow.Show();
        }
    }
}
