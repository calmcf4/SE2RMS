using Microsoft.EntityFrameworkCore;
using SE2RMS.Dialogs;
using SE2RMS.Models;
using SE2RMS.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly RMSContext _context = new RMSContext();        

        private enum Page
        {
            Home,
            Students,
            Tutors,
            Timetable,
            Modules,
            Assessments

        }

        Page page { get; set; }

        
        public MainWindow()
        {
            InitializeComponent();
            info.Content = new Home();            
            changeButtonColours(homeButton);
            _context.Database.EnsureCreated();
            Console.WriteLine("testing");
            page = Page.Home;
            addButton.Visibility = Visibility.Hidden;
            if (!DataCheck())
                DummyData();

        }


        private void timeTableButtonClick(object sender, RoutedEventArgs e)
        {
            info.Content = new Timetable();
            title.Text = "Timetables";
            yearComboBox.Visibility = Visibility.Visible;
            searchBox.Visibility = Visibility.Hidden;
            liveComboBox.Visibility = Visibility.Hidden;
            changeButtonColours(timetablesButton);
            page = Page.Timetable;
            addButton.Visibility = Visibility.Hidden;

        }

        private void modulesButtonClick(object sender, RoutedEventArgs e)
        {
            info.Content = new Modules();
            title.Text = "Modules";
            yearComboBox.Visibility = Visibility.Visible;
            searchBox.Visibility = Visibility.Visible;
            changeButtonColours(modulesButton);
            page = Page.Modules;
            addButton.Visibility = Visibility.Visible;
            Staff staff = new Staff();            
        }

        private void homeButtonClicked(object sender, RoutedEventArgs e)
        {
            info.Content = new Home();
            title.Text = "Home";
            yearComboBox.Visibility = Visibility.Hidden;
            searchBox.Visibility = Visibility.Hidden;
            liveComboBox.Visibility = Visibility.Hidden;
            changeButtonColours(homeButton);
            page = Page.Home;
            addButton.Visibility = Visibility.Hidden;
        }

        private void tutorsButtonClick(object sender, RoutedEventArgs e)
        {
            info.Content = new Tutors();
            title.Text = "Tutors";
            liveComboBox.Visibility = Visibility.Visible;
            searchBox.Visibility = Visibility.Visible;
            changeButtonColours(tutorsButton);
            page = Page.Tutors;
            addButton.Visibility = Visibility.Visible;
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
            tutorsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#568259");
            tutorsButton.Foreground = new SolidColorBrush(Colors.White);
            assessmentsButton.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#568259");
            assessmentsButton.Foreground = new SolidColorBrush(Colors.White);

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
            page = Page.Students;
            addButton.Visibility = Visibility.Visible;
        }

        private void searchBoxSelect(object sender, KeyboardFocusChangedEventArgs e)
        {
            searchBox.Text = "";
        }

        private void searchBoxDeselect(object sender, KeyboardFocusChangedEventArgs e)
        {
            searchBox.Text = "Search...";
        }

        private void AddRecord(object sender, RoutedEventArgs e)
        {
            switch(page)
            {
                case Page.Students:
                    AddStudentDialog addStudentDialog = new AddStudentDialog();
                    addStudentDialog.ShowDialog();
                    break;

                case Page.Tutors:
                    AddTutorDialog addTutorDialog = new AddTutorDialog();
                    addTutorDialog.ShowDialog();
                    break;

                case Page.Modules:
                    AddModuleDialog addModuleDialog = new AddModuleDialog();
                    addModuleDialog.ShowDialog();
                    break;

                case Page.Assessments:
                    AddAssessmentDialog addAssessmentDialog = new AddAssessmentDialog();
                    addAssessmentDialog.ShowDialog();
                    break;

                default:
                    break;
            }
            
        }

        private void AssessmentsButtonClick(object sender, RoutedEventArgs e)
        {
            info.Content = new Assessments();
            title.Text = "Assessments";
            yearComboBox.Visibility = Visibility.Visible;
            searchBox.Visibility = Visibility.Visible;
            changeButtonColours(assessmentsButton);
            page = Page.Assessments;
            addButton.Visibility = Visibility.Visible;
        }

        private bool DataCheck()
        {
            Course course = new Course();
            course = _context.Courses.Where(c => c.CourseId == 1).FirstOrDefault();
            if (course == null)
                return false;
            
            return true;
        }

        private void DummyData()
        {
            Course course = new Course();
            course.Name = "Computing";
            course.CourseId = 1;
            _context.Courses.Add(course);
            _context.SaveChanges();
        }
    }

   
}
