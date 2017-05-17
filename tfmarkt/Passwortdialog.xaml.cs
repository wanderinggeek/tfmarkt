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

namespace tfmarkt
{
    /// <summary>
    /// Interaktionslogik für Passwortdialog.xaml
    /// </summary>
    public partial class Passwortdialog : Window
    {
        private string password;
        public bool passGueltig { get; private set; }
        public MainWindow mainWindow;

        public Passwortdialog(MainWindow mainWindow)
        {
            InitializeComponent();
            this.password = "password";
            this.mainWindow = mainWindow;

        }

        private void Confirm_OnClick(object sender, RoutedEventArgs e)
        {

            if (PasswordBox.Password == password)
            {
                passGueltig = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Passwort nicht gültig");
            }

        }

        private void AbbrechenButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Passwortdialog_OnClosed(object sender, EventArgs e)
        {
            if (passGueltig)
            {
                this.mainWindow.ladeVerwaltung();
            }
        }
    }
}
