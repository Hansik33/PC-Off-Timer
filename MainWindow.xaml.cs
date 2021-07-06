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
using System.Text.RegularExpressions;
using System.IO;

namespace PC_Off_Timer
{
    public partial class MainWindow : Window
    {
        int seconds, minutes, hours;

        int x1, x2;

        public MainWindow()
        {
            InitializeComponent();
        }
        void MsgInfo(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("PC Off Timer - Czasowy Wyłącznik Komputera" + "\n"
            + "By Adam Franz" + "\n"
            + "Wersja: 1.0" + "\n"
            + "Web page: www.hansik.pl", "Informacje", MessageBoxButton.OK, MessageBoxImage.Information);
            System.Diagnostics.Process.Start("https://www.hansik.pl");
        }
        void Set(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBhours.Text)) MsgError();
            else if (string.IsNullOrWhiteSpace(TBminutes.Text)) MsgError();
            else
            {

                hours = Convert.ToInt32(TBhours.Text);
                minutes = Convert.ToInt32(TBminutes.Text);

                if (hours == 0 && minutes == 0) MsgError();
                else if (hours > 24) MsgError();
                else if (minutes > 60) MsgError();
                else
                {

                    x1 = (hours * 3600);
                    x2 = (minutes * 60);

                    seconds = x1 + x2;

                    MessageBox.Show("Wyłączenie komputera nastąpi za "
                    + hours
                    + "h i "
                    + minutes
                    + "m.", "Sukces!", MessageBoxButton.OK, MessageBoxImage.Information);
                    System.Diagnostics.Process.Start("shutdown", "-s -t " + seconds);

                }
            }
        }
        void Cancel(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Anulowano wyłączenie komputera.", "Anulowano", MessageBoxButton.OK, MessageBoxImage.Information);
            System.Diagnostics.Process.Start("shutdown", "-a");
        }
        void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        void MsgError()
        {
            MessageBox.Show("Wprowadź poprawne dane!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
