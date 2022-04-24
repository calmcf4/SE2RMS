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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {            
        }

        private void timeTableButtonClick(object sender, RoutedEventArgs e)
        {
            info.Content = new Timetable();
            title.Text = "Timetables";
            yearComboBox.Visibility = Visibility.Visible;
            timetablesButton.Background = new SolidColorBrush(Colors.White);
            timetablesButton.Foreground = new SolidColorBrush(Colors.Black);
            modulesButton.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#568259");
            modulesButton.Foreground = new SolidColorBrush (Colors.White);
        }

        private void modulesButtonClick(object sender, RoutedEventArgs e)
        {
            info.Content = new Modules();
            title.Text = "Modules";
            yearComboBox.Visibility = Visibility.Visible;
            modulesButton.Background = new SolidColorBrush(Colors.White);
            modulesButton.Foreground = new SolidColorBrush(Colors.Black);
            timetablesButton.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#568259");
            timetablesButton.Foreground = new SolidColorBrush (Colors.White);
        }
    }

   
}
