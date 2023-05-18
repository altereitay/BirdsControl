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
    /// Interaction logic for UpdateCagePage.xaml
    /// </summary>
    public partial class UpdateCagePage : Page
    {
        string cagenum;
        public UpdateCagePage()
        {
            InitializeComponent();
        }
        private int updatingTableId = 0;
        private void gridCage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.gridCage.SelectedIndex >= 0 && this.gridCage.SelectedItems.Count >= 0)
            {
                if (this.gridCage.SelectedItems[0].GetType() == typeof(Cage))
                {
                    Cage t = (Cage)this.gridCage.SelectedItems[0];

                    int indexspe = -1;

                    foreach (ComboBoxItem item in Material_drop.Items)
                    {
                        if (item.Content.ToString() == t.Material.TrimStart())
                        {
                            indexspe = Material_drop.Items.IndexOf(item);
                            break;
                        }
                    }
                    Material_drop.SelectedIndex = indexspe;
                    this.SerialNumber_tb.Text = t.SerialNumber;
                    this.Length_tb.Text = t.Length.ToString();
                    this.Width_tb.Text = t.Width.ToString();
                    this.Height_tb.Text = t.Height.ToString();
                    this.updatingTableId = t.Id;
                    cagenum = t.SerialNumber;
                }
            }
        }

        public void updateCage_btn_Click(object sender, RoutedEventArgs e)
        {
            BirdsControlDBEntities db = new BirdsControlDBEntities();
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


            if (length < 0)
            {
                MessageBox.Show("The length should be positive.");
                return;
            }
            if (width < 0)
            {
                MessageBox.Show("The width should be positive.");
                return;
            }
            if (height < 0)
            {
                MessageBox.Show("The height should be positive.");
                return;
            }



            var r = from d in db.Cage
                    where d.Id == this.updatingTableId
                    select d;

            var result = from cage in db.Cage
                         where (SerialNumber_tb.Text == cage.SerialNumber)
                         select cage;

            var bird = from b in db.Bird
                       where b.CageNumber == cagenum
                       select b;
            foreach(var b in bird )
            {
                b.CageNumber = this.SerialNumber_tb.Text;
            }


            if (!result.Any())
            {

                Cage obj = r.SingleOrDefault();
                if (obj != null)
                {
                    obj.SerialNumber = this.SerialNumber_tb.Text;
                    obj.Length = int.Parse(this.Length_tb.Text);
                    obj.Width = int.Parse(this.Width_tb.Text);
                    obj.Height = int.Parse(this.Height_tb.Text);
                    obj.Material = Material_drop.SelectedItem.ToString().Split(':')[1];
                }
     
            }
            else
            {
                Cage obj=result.SingleOrDefault();
                if(obj.SerialNumber== cagenum)
                {
                    obj.SerialNumber = this.SerialNumber_tb.Text;
                    obj.Length = int.Parse(this.Length_tb.Text);
                    obj.Width = int.Parse(this.Width_tb.Text);
                    obj.Height = int.Parse(this.Height_tb.Text);
                    obj.Material = Material_drop.SelectedItem.ToString().Split(':')[1];
                }
                else 
                MessageBox.Show("Cage is already exists");
            }
            db.SaveChanges();
            this.gridCage.ItemsSource = db.Cage.ToList();
        }

        private void LoadCages_btn_Click(object sender, RoutedEventArgs e)
        {
            BirdsControlDBEntities db = new BirdsControlDBEntities();
            this.gridCage.ItemsSource = db.Cage.ToList();
        }

        private void HomePage_btn_Click(object sender, RoutedEventArgs e)
        {
            MainPage newWindow = new MainPage();
            this.Visibility = Visibility.Hidden;
            newWindow.Show();
        }

        private void Delete_cage_Click(object sender, RoutedEventArgs e)
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

                var r = from d in db.Cage
                        where d.SerialNumber == this.SerialNumber_tb.Text
                        select d;
                var birdsToDelete = from b in db.Bird
                                    where b.CageNumber == this.SerialNumber_tb.Text
                                    select b;
                foreach (var bird in birdsToDelete)
                {
                    db.Bird.Remove(bird);
                }

                db.SaveChanges();

                Cage obj = r.SingleOrDefault();
                if (obj != null)
                {
                    db.Cage.Remove(obj);
                    db.SaveChanges();
                }
                this.gridCage.ItemsSource = db.Cage.ToList();
            }

        }
    }
}
