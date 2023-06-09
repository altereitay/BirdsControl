﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using MaterialDesignThemes.Wpf;
using Microsoft.Office.Interop.Excel;
using MaterialDesignThemes.Wpf;

namespace BirdsControl
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : System.Windows.Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            readExcel();
        }
        private void readExcel()
        {
            
            string path = @"..\..\login_file.xlsx";
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = excel.Workbooks.Open(Directory.GetCurrentDirectory() + "\\"+path);
            Worksheet worksheet = workbook.Worksheets[1];
            Range usedRange = worksheet.UsedRange;
            int rowCount = usedRange.Rows.Count;
            int flag = 0;
            for (int i = 1;i <= rowCount; i++)
            {
                object email = worksheet.Cells[i, 1].Value;
                object pass = worksheet.Cells[i, 2].Value;

                if(email_tb.Text== email.ToString() && Pass_tb.Password==pass.ToString())
                {
                    MainPage newWindow = new MainPage();
                    this.Visibility = Visibility.Hidden;
                    newWindow.Show();
                    flag = 1;
                    break;
                }
            }
            if (flag == 0)
            {
                MessageBox.Show("Invalid Credentials");
            }
            workbook.Close();
            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            excel.Quit();
            Marshal.ReleaseComObject(excel);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Signxaml signxaml = new Signxaml();
            this.Visibility = Visibility.Hidden;
            signxaml.Show();
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
