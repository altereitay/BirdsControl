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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class AddBirdPage : Page
    {
        public AddBirdPage()
        {
            InitializeComponent();
        }
        private void datePicker_Loaded(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = DateTime.Today;
            datePicker.DisplayDateStart = DateTime.Today.AddYears(-15);
            datePicker.DisplayDateEnd = DateTime.Today;
        }
        private void speciesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (speciesComboBox.SelectedItem != null)
            {
                string selectedSpecies = (speciesComboBox.SelectedItem as ComboBoxItem).Content.ToString();

                // Clear the items of the subComboBox
                subComboBox.Items.Clear();

                // Enable or disable options in the subComboBox based on the selected species
                if (selectedSpecies == "American Gouldian")
                {
                    subComboBox.IsEnabled = true;
                    subComboBox.Items.Add(new ComboBoxItem() { Content = "North America" });
                    subComboBox.Items.Add(new ComboBoxItem() { Content = "Central America" });
                    subComboBox.Items.Add(new ComboBoxItem() { Content = "South America" });
                }
                else if (selectedSpecies == "European Gouldian")
                {
                    subComboBox.IsEnabled = true;
                    subComboBox.Items.Add(new ComboBoxItem() { Content = "East Europe" });
                    subComboBox.Items.Add(new ComboBoxItem() { Content = "Western Europe" });
                }
                else if (selectedSpecies == "Australian Gouldian")
                {
                    subComboBox.IsEnabled = true;
                    subComboBox.Items.Add(new ComboBoxItem() { Content = "Central Australia" });
                    subComboBox.Items.Add(new ComboBoxItem() { Content = "Coastal Cities" });
                }
                else
                {
                    subComboBox.IsEnabled = false;
                }
            }
        }

        public void AddBird_btn_Click(object sender, RoutedEventArgs e)
        {

            if (speciesComboBox.SelectedItem==null || subComboBox.SelectedItem==null ||
                datePicker.SelectedDate == null || string.IsNullOrWhiteSpace(sex_tb.Text) || string.IsNullOrWhiteSpace(cage_tb.Text))
            {
                MessageBox.Show("Please fill in all the fields before adding a bird.");
                return;
            }
         
            if (sex_tb.Text != "Male" && sex_tb.Text != "male" && sex_tb.Text != "Female" && sex_tb.Text != "female")
            {
                MessageBox.Show("Enter M/male or F/female");
                return;
            }
            else
            {

                BirdsControlDBEntities db = new BirdsControlDBEntities();

                Bird birdObject = new Bird()
                {
                    Specie = speciesComboBox.SelectedItem.ToString().Split(':')[1].TrimStart(),
                    SubSpecie = subComboBox.SelectedItem.ToString().Split(':')[1],
                    HatchingDate = datePicker.SelectedDate.Value,
                    Sex = sex_tb.Text,
                    CageNumber = cage_tb.Text
                };
                var result = from cage in db.Cage
                             where (cage_tb.Text == cage.SerialNumber)
                             select cage;

                if (!result.Any())
                {
                    MessageBox.Show("The cage number does not exist.");
                }
                else
                {
                    db.Bird.Add(birdObject);
                    db.SaveChanges();
                    this.gridBird.ItemsSource = db.Bird.ToList();
                }
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
