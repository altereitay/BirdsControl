using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
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

            if(bird.Sex == "Male" || bird.Sex == "male")
            {
                this.dadId_tb.Text = bird.Id.ToString();
            }
            else if(bird.Sex == "Female" || bird.Sex == "female")
            {
                this.momId_tb.Text = bird.Id.ToString();
            }

          
            temp = bird;
        }
        private void datePicker_Loaded(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = DateTime.Today;
            datePicker.DisplayDateStart = DateTime.Today.AddYears(-15);
            datePicker.DisplayDateEnd = DateTime.Today;
        }
        private void AddBird_btn_Click(object sender, RoutedEventArgs e)
        {
            BirdsControlDBEntities db = new BirdsControlDBEntities();
            if (string.IsNullOrWhiteSpace(species_tb.Text) || string.IsNullOrWhiteSpace(subspecies_tb.Text) ||
                datePicker.SelectedDate == null || string.IsNullOrWhiteSpace(cage_tb.Text) ||
                    string.IsNullOrWhiteSpace(dadId_tb.Text) || string.IsNullOrWhiteSpace(momId_tb.Text) || sexComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all the fields before adding a bird.");
                return;
            }
            if (!int.TryParse(momId_tb.Text, out int length))
            {
                MessageBox.Show("Mom Id should contain a valid number.");
                return;
            }
            if (!int.TryParse(dadId_tb.Text, out int width))
            {
                MessageBox.Show("Dad ID should contain a valid number.");
                return;
            }
            if (int.Parse(dadId_tb.Text)< 0 || int.Parse(momId_tb.Text)<0)
            {
                MessageBox.Show("Invalid Id");
                return;
            }
            bool dad=false;
            bool mom = false;

            foreach(Bird b in db.Bird)
            {
                if(b.Id == int.Parse(dadId_tb.Text))
                { dad = true; }
                if (b.Id == int.Parse(momId_tb.Text))
                { mom = true; }
            }
            if(dad && mom) {
                Bird birdObject = new Bird()
                {
                    Specie = species_tb.Text,
                    SubSpecie = subspecies_tb.Text,
                    HatchingDate = datePicker.SelectedDate.Value,
                    Sex = sexComboBox.SelectedItem.ToString().Split(':')[1].TrimStart(),
                    CageNumber = cage_tb.Text,
                    DadID = int.Parse(dadId_tb.Text),
                    MomID = int.Parse(momId_tb.Text)
                };
                db.Bird.Add(birdObject);
                db.SaveChanges();
                MessageBox.Show("Chick Added Successfully");
            }
            else
            {
                if (!dad)
                {
                    MessageBox.Show("Dad Id doesnt exist");
                    return;
                }
                else
                {
                    MessageBox.Show("Mom Id doesnt exist");
                    return;
                }
            }
        }
    }
}
