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
    /// Interaction logic for AddChickPage.xaml
    /// </summary>
    public partial class AddChickPage : Page
    {
        Bird temp = new Bird();

        public AddChickPage(Bird bird)
        {
            InitializeComponent();

            this.species_tb.Text = bird.Specie;
            this.subspecies_tb.Text = bird.SubSpecie;
            this.cage_tb.Text = bird.CageNumber;

            if (sex_tb.Text != "Male" && sex_tb.Text != "male" && sex_tb.Text != "Female" && sex_tb.Text != "female")
            {
                MessageBox.Show("Enter M/male or F/female");
                return;
            }
            temp = bird;
        }

        private void AddBird_btn_Click(object sender, RoutedEventArgs e)
        {
            BirdsControlDBEntities db = new BirdsControlDBEntities();
            if (string.IsNullOrWhiteSpace(species_tb.Text) || string.IsNullOrWhiteSpace(subspecies_tb.Text) ||
                datePicker.SelectedDate == null || string.IsNullOrWhiteSpace(sex_tb.Text) || string.IsNullOrWhiteSpace(cage_tb.Text))
            {
                MessageBox.Show("Please fill in all the fields before adding a bird.");
                return;
            }

            Bird birdObject = new Bird()
            {
                Specie = species_tb.Text,
                SubSpecie = subspecies_tb.Text,
                HatchingDate = datePicker.SelectedDate.Value,
                Sex = sex_tb.Text,
                CageNumber = cage_tb.Text,
                DadID = int.Parse(dadId_tb.Text),
                MomID = int.Parse(momId_tb.Text)
            };
            db.Bird.Add(birdObject);
            db.SaveChanges();

        }
    }
}
