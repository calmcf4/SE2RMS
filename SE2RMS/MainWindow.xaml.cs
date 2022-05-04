using SE2RMS.Pages;
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

namespace SE2RMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            info.Content = new Home();
            changeButtonColours(homeButton);
        }

        private void timeTableButtonClick(object sender, RoutedEventArgs e)
        {
            info.Content = new Timetable();
            title.Text = "Timetables";
            yearComboBox.Visibility = Visibility.Visible;
            searchBox.Visibility = Visibility.Hidden;
            liveComboBox.Visibility = Visibility.Hidden;
            changeButtonColours(timetablesButton);
        }

        private void modulesButtonClick(object sender, RoutedEventArgs e)
        {
            info.Content = new Modules();
            title.Text = "Modules";
            yearComboBox.Visibility = Visibility.Visible;
            searchBox.Visibility = Visibility.Visible;
            changeButtonColours(modulesButton);
        }

        private void homeButtonClicked(object sender, RoutedEventArgs e)
        {
            info.Content = new Home();
            title.Text = "Home";
            yearComboBox.Visibility = Visibility.Hidden;
            searchBox.Visibility = Visibility.Hidden;
            liveComboBox.Visibility = Visibility.Hidden;
            changeButtonColours(homeButton);
        }

        private void changeButtonColours(Button button)
        {
            timetablesButton.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#568259");
            timetablesButton.Foreground = new SolidColorBrush(Colors.White);
            modulesButton.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#568259");
            modulesButton.Foreground = new SolidColorBrush(Colors.White);
            homeButton.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#568259");
            homeButton.Foreground = new SolidColorBrush(Colors.White);
            studentsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#568259");
            studentsButton.Foreground = new SolidColorBrush(Colors.White);

            button.Background = new SolidColorBrush(Colors.White);
            button.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void studentsButtonClick(object sender, RoutedEventArgs e)
        {
            info.Content = new Students();
            title.Text = "Students";
            yearComboBox.Visibility = Visibility.Visible;
            searchBox.Visibility = Visibility.Visible;
            liveComboBox.Visibility = Visibility.Visible;
            changeButtonColours(studentsButton);
        }

        private void searchBoxSelect(object sender, KeyboardFocusChangedEventArgs e)
        {
            searchBox.Text = "";
        }

        private void searchBoxDeselect(object sender, KeyboardFocusChangedEventArgs e)
        {
            searchBox.Text = "Searching...";
        }
    }

   
}
