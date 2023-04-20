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
    /// Interaction logic for BirdInfoPage.xaml
    /// </summary>
    public partial class BirdInfoPage : Page
    {
        Bird temp = new Bird();
        MainPage mainPage;
        public BirdInfoPage(Bird bird, MainPage mainPage)
        {
            InitializeComponent();

            this.species_tb.Text = bird.Specie;
            this.subspecies_tb.Text = bird.SubSpecie;
            this.datePicker.Text = bird.HatchingDate.ToString();
            this.sex_tb.Text = bird.Sex;
            this.cage_tb.Text = bird.CageNumber;
            this.id_tb.Text = bird.Id.ToString();

            temp = bird;
            this.mainPage = mainPage;
        }
        private void AddChick_Click(object sender, RoutedEventArgs e)
        {
            AddChickPage page = new AddChickPage(temp);

            // Set the content of a Frame control on the parent window or page
            mainPage.mainFrame.Content = page;
        }
    }
}
