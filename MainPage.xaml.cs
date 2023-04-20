using BirdsControl.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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

            AddBirdPage page = new AddBirdPage();

            // Set the content of a Frame control on the parent window or page
            mainFrame.Content = page;
        }

        private void addCage_Click(object sender, RoutedEventArgs e)
        {
            AddCagePage page = new AddCagePage();

            // Set the content of a Frame control on the parent window or page
            mainFrame.Content = page;
        }

        private void SearchBird_Click(object sender, RoutedEventArgs e)
        {
            SearchBirdPage page = new SearchBirdPage(this);

            // Set the content of a Frame control on the parent window or page
            mainFrame.Content = page;
        }

        private void UpdateBird_Click(object sender, RoutedEventArgs e)
        {
            UpdateBirdPage page = new UpdateBirdPage();

            // Set the content of a Frame control on the parent window or page
            mainFrame.Content = page;
        }

        private void UpdateCage_Click(object sender, RoutedEventArgs e)
        {
            UpdateCagePage page = new UpdateCagePage();

            // Set the content of a Frame control on the parent window or page
            mainFrame.Content = page;
        }

        private void SearchCage_Click(object sender, RoutedEventArgs e)
        {
            CageSearchPage page = new CageSearchPage(this);

            // Set the content of a Frame control on the parent window or page
            mainFrame.Content = page;
        }

        private void logout_btn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}