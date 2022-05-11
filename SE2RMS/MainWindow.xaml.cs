using Microsoft.EntityFrameworkCore;
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
        private string page;
        public MainWindow()
        {
            InitializeComponent();
            info.Content = new Home();
            page = "Home";
            changeButtonColours(homeButton);
            _context.Database.EnsureCreated();
            Console.WriteLine("testing");


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
            //Course course = _context.Courses.Where(c => c.Name == "Computing").FirstOrDefault<Course>();
            //Trace.WriteLine(course.CourseId);
            //Trace.WriteLine(course.Name);
            Student student = _context.Students.Where(s => s.StudentId == 1).FirstOrDefault<Student>();
            Trace.WriteLine(student.FirstName);
            Trace.WriteLine(student.LastName);
            Trace.WriteLine(student.Email);
            Trace.WriteLine(student.Status);
        }

        private void tutorsButtonClick(object sender, RoutedEventArgs e)
        {
            info.Content = new Tutors();
            title.Text = "Tutors";
            liveComboBox.Visibility = Visibility.Visible;
            searchBox.Visibility = Visibility.Visible;
            changeButtonColours(tutorsButton);
            
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

        private void addStudent(object sender, RoutedEventArgs e)
        {

            //Course course = new Course();
            //course.Name = "Computing";
            //_context.Courses.Add(course);
            //_context.SaveChanges();

            Student student = new Student();
            student.FirstName = "Jerry";
            student.MiddleName = "";
            student.LastName = "Smith";
            student.TermAddress = "Test Address";
            student.NonTermAddress = "Non Term Address";
            student.PhoneNumber = "Test Phone";
            student.Email = "Test Email";
            student.EntryQuals = "Test ENtry";
            student.CourseId = 1;
            student.Status = "Live";
            student.DormancyReason = "";
            _context.Students.Add(student);
            _context.SaveChanges();

        }
    }

   
}
