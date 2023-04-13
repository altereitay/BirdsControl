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
    /// Interaction logic for AddChick.xaml
    /// </summary>
    public partial class AddChick : Window
    {
        Bird temp = new Bird();
        public AddChick(Bird bird)
        {
            InitializeComponent();

            this.species_tb.Text = bird.Specie;
            this.subspecies_tb.Text = bird.SubSpecie;
            this.cage_tb.Text = bird.CageNumber;
            
            if(bird.Sex == "Male" || bird.Sex == "male")
                this.dadId_tb.Text = bird.Id.ToString();

            if (bird.Sex == "Female" || bird.Sex == "female")
                this.momId_tb.Text = bird.Id.ToString();
            temp = bird;
        }

        private void AddBird_btn_Click(object sender, RoutedEventArgs e)
        {
            BirdsControlDBEntities db = new BirdsControlDBEntities();

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

        private void HomePage_btn_Click(object sender, RoutedEventArgs e)
        {
            MainPage newWindow = new MainPage();
            this.Visibility = Visibility.Hidden;
            newWindow.Show();
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            BirdInfo newWindow = new BirdInfo(temp);
            this.Visibility = Visibility.Hidden;
            newWindow.Show();
        }
    }
}
