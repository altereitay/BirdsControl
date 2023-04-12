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
    /// Interaction logic for BirdInfo.xaml
    /// </summary>
    public partial class BirdInfo : Window
    {
        Bird temp = new Bird();
        public BirdInfo(Bird bird)
        {
            InitializeComponent();
       
            this.species_tb.Text = bird.Specie;
            this.subspecies_tb.Text = bird.SubSpecie;
            this.datePicker.Text = bird.HatchingDate.ToString();
            this.sex_tb.Text = bird.Sex;
            this.cage_tb.Text = bird.CageNumber;
            this.id_tb.Text = bird.Id.ToString();

            temp = bird;
        }

        private void AddChick_Click(object sender, RoutedEventArgs e)
        {
            AddChick newWindow = new AddChick(temp);
            this.Visibility = Visibility.Hidden;
            newWindow.Show();
        }
    }
}
