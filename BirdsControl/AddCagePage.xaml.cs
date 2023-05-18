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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BirdsControl
{
    /// <summary>
    /// Interaction logic for AddCagePage.xaml
    /// </summary>
    public partial class AddCagePage : Page
    {
        public AddCagePage()
        {
            InitializeComponent();
        }
        private void AddCage_btn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SerialNumber_tb.Text) || string.IsNullOrWhiteSpace(Length_tb.Text) ||
                string.IsNullOrWhiteSpace(Width_tb.Text) || string.IsNullOrWhiteSpace(Height_tb.Text) ||
                Material_drop.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all the fields before adding a cage.");
                return;
            }
            if (!float.TryParse(Length_tb.Text, out float length))
            {
                MessageBox.Show("The length should contain a valid number.");
                return;
            }
            if (!float.TryParse(Width_tb.Text, out float width))
            {
                MessageBox.Show("The length should contain a valid number.");
                return;
            }
            if (!float.TryParse(Height_tb.Text, out float height))
            {
                MessageBox.Show("The length should contain a valid number.");
                return;
            }



            if (length<0)
            {
                MessageBox.Show("The length should be positive.");
                return;
            }
            if (width<0)
            {
                MessageBox.Show("The width should be positive.");
                return;
            }
            if (height<0)
            {
                MessageBox.Show("The height should be positive.");
                return;
            }



            BirdsControlDBEntities db = new BirdsControlDBEntities();

            var result = from cage in db.Cage
                         where (SerialNumber_tb.Text == cage.SerialNumber)
                         select cage;

            if (!result.Any())
            {
                Cage cageObject = new Cage()
                {
                    SerialNumber = SerialNumber_tb.Text,
                    Length = (int)length,
                    Width =(int)width,
                    Height=  (int)height,
                    Material = Material_drop.SelectedItem.ToString().Split(':')[1]
                };
                db.Cage.Add(cageObject);
                db.SaveChanges();

                this.gridCage.ItemsSource = db.Cage.ToList();
            }
            else
            {
                MessageBox.Show("Cage already exists.");
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
