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

namespace tfmarkt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void tapetenTab_Clicked(object sender, MouseButtonEventArgs e)
        {
            TapetenGUI tapetenGui = new TapetenGUI();
            TapetenTab.Content = tapetenGui.Content;
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
            if (TapetenTab.IsSelected)
            {
                TapetenGUI tapetenGui = new TapetenGUI();
                TapetenTab.Content = tapetenGui.Content;
            }
            if (VerwaltungTab.IsSelected)
            {
                Verwaltung verwaltungGui = new Verwaltung();
                VerwaltungTab.Content = verwaltungGui.Content;
            }
            if (FliesenTab.IsSelected)
            {
                FliesenGUI fliesenGui = new FliesenGUI();
                FliesenTab.Content = fliesenGui;
            }
            if (MainMenuTab.IsSelected)
            {
                MainMenuTab.Content = "Main Menu Stuff";
            }
        }
    }
}
