using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Text.RegularExpressions;
using System.IO;
using MaterialDesignThemes.Wpf;

namespace BirdsControl
{
    /// <summary>
    /// Interaction logic for Signxaml.xaml
    /// </summary>
    public partial class Signxaml : System.Windows.Window
    {
        public Signxaml()
        {
            InitializeComponent();
         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = @"..\..\login_file.xlsx";
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = excel.Workbooks.Open(Directory.GetCurrentDirectory() + "\\" + path);
            Worksheet worksheet = workbook.Worksheets[1];
            int lastRow = worksheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row;
            Range range = worksheet.Range["A" + (lastRow + 1), "C" + (lastRow + 1)];
            string username = email_tb.Text;
            string pass = pass_tb.Text;
            string id = Id.Text;
            if (username.Length < 9 && username.Length > 5)
            {
                int numbers = username.Count(char.IsNumber);
                int letters = username.Count(char.IsLetter);
                bool isValid = Regex.IsMatch(pass, @"^(?=.*[!@#$%^&+=])(?=.*\d)(?=.*[a-zA-Z])[!@#$%^&+=\w]{8,10}$");
                if (numbers <= 2 && numbers + letters == username.Length)
                {
                    if (pass.Length > 7 && pass.Length < 11 && isValid)
                    {
                        if (id.Length == 9 && id.Count(char.IsNumber) == 9)
                        {
                            Range usedRange = worksheet.UsedRange;
                            int rowCount = usedRange.Rows.Count;
                            int flag = 0;
                            for (int i = 2; i <= rowCount; i++)
                            {
                                object oldid = worksheet.Cells[i, 3].Value;

                                if (id == oldid.ToString())
                                {
                                    flag = 1;
                                }
                            }
                            if (flag != 1)
                            {
                                MessageBox.Show("User Added");
                                object[,] values = new object[1, 3] { { username, pass, id } };
                                range.Value = values;
                                workbook.Save();
                                workbook.Close();
                                Marshal.ReleaseComObject(worksheet);
                                Marshal.ReleaseComObject(workbook);
                                excel.Quit();
                                Marshal.ReleaseComObject(excel);
                                MainPage newWindow = new MainPage();
                                this.Visibility = Visibility.Hidden;
                                newWindow.Show();
                            }
                            else
                            {
                                MessageBox.Show("ID already exists");
                            }
                        }
                    else
                        {
                            MessageBox.Show("ID invalid");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Password invalid");

                    }
                }
                else
                {
                    MessageBox.Show("User Name Does not meet the conditions");
                }
            }
            else
            {
                MessageBox.Show("User Name too short");
            }
        }
        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        private void toggleTheme(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();

            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
    }
}
