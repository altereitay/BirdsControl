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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void addBird_Click(object sender, RoutedEventArgs e)
        {
            AddBird newWindow = new AddBird();
            this.Visibility = Visibility.Hidden;
            newWindow.Show();



        }

        private void addCage_Click(object sender, RoutedEventArgs e)
        {
            AddCage newWindow = new AddCage();
            this.Visibility = Visibility.Hidden;
            newWindow.Show();

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchBird newWindow = new SearchBird();
            this.Visibility = Visibility.Hidden;
            newWindow.Show();

        }

        private void UpdateBird_Click(object sender, RoutedEventArgs e)
        {
            UpdateBird newWindow = new UpdateBird();
            this.Visibility = Visibility.Hidden;
            newWindow.Show();
        }

        private void UpdateCage_Click(object sender, RoutedEventArgs e)
        {
            UpdateCage newWindow = new UpdateCage();
            this.Visibility = Visibility.Hidden;
            newWindow.Show();
        }
    }
}
