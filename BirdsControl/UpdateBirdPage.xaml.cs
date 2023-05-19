using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for UpdateBirdPage.xaml
    /// </summary>
    public partial class UpdateBirdPage : Page
    {
        public UpdateBirdPage()
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





        private void Update_bird_Click(object sender, RoutedEventArgs e)
        {
            BirdsControlDBEntities db = new BirdsControlDBEntities();
            if (speciesComboBox.SelectedItem == null || subComboBox.SelectedItem == null ||
                datePicker.SelectedDate == null ||  string.IsNullOrWhiteSpace(cage_tb.Text))
            {
                MessageBox.Show("Please fill in all the fields before adding a bird.");
                return;
            }

            var r = from d in db.Bird
                    where d.Id == this.updatingTableId
                    select d;


            var result = from cage in db.Cage
                         where (cage_tb.Text == cage.SerialNumber)
                         select cage;

            if (!result.Any())
            {
                MessageBox.Show("The cage number Does not exist");
            }

            else
            {
                Bird obj = r.SingleOrDefault();
                if (obj != null)
                {
                    obj.Specie = speciesComboBox.SelectedItem.ToString().Split(':')[1];
                    obj.SubSpecie = subComboBox.SelectedItem.ToString().Split(':')[1];
                    obj.HatchingDate = this.datePicker.SelectedDate.Value; 
                    if (this.sexComboBox.SelectedItem != null)
                    {
                        obj.Sex = this.sexComboBox.SelectedItem.ToString().Split(':')[1].TrimStart();
                    }
                    obj.CageNumber = this.cage_tb.Text;
                }
                db.SaveChanges();
                this.gridBird.ItemsSource = db.Bird.ToList();
            }

        }

        private void Load_Birds_Click(object sender, RoutedEventArgs e)
        {

            BirdsControlDBEntities db = new BirdsControlDBEntities();
            this.gridBird.ItemsSource = db.Bird.ToList();

        }
        private int updatingTableId = 0;
        private void gridBird_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.gridBird.SelectedIndex >= 0 && this.gridBird.SelectedItems.Count >= 0)
            {
                if (this.gridBird.SelectedItems[0] is Bird selectedBird)
                {
                    int indexspe = -1;

                    foreach (ComboBoxItem item in speciesComboBox.Items)
                    {
                        if (item.Content.ToString() == selectedBird.Specie.TrimStart())
                        {
                            indexspe = speciesComboBox.Items.IndexOf(item);
                            break;
                        }
                    }
                    speciesComboBox.SelectedIndex = indexspe;

                    int indexsub = -1;

                    foreach (ComboBoxItem item in subComboBox.Items)
                    {
                        if (item.Content.ToString() == selectedBird.SubSpecie.TrimStart())
                        {
                            indexsub = subComboBox.Items.IndexOf(item);
                            break;
                        }
                    }
                    subComboBox.SelectedIndex = indexsub;
                    datePicker.Text = selectedBird.HatchingDate.ToString();
                    //sex_tb.Text = selectedBird.Sex;
                    cage_tb.Text = selectedBird.CageNumber;
                    updatingTableId = selectedBird.Id;
                }
            
            }

        }

        private void HomePage_btn_Click(object sender, RoutedEventArgs e)
        {
            MainPage newWindow = new MainPage();
            this.Visibility = Visibility.Hidden;
            newWindow.Show();
        }

        private void Delete_bird_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msg = MessageBox.Show("Are you sure?",
              "Deletre bird",
              MessageBoxButton.YesNo,
              MessageBoxImage.Warning,
              MessageBoxResult.No
              );
            if (msg == MessageBoxResult.Yes)
            {
                BirdsControlDBEntities db = new BirdsControlDBEntities();

                var r = from d in db.Bird
                        where d.Id == this.updatingTableId
                        select d;

                Bird obj = r.SingleOrDefault();
                if (obj != null)
                {
                    db.Bird.Remove(obj);
                    db.SaveChanges();
                }
                this.gridBird.ItemsSource = db.Bird.ToList();
            }
        }
    }
}
