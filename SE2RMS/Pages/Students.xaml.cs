using SE2RMS.Dialogs;
using SE2RMS.Models;
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


namespace SE2RMS.Pages
{
    /// <summary>
    /// Interaction logic for Students.xaml
    /// </summary>
    /// 
    
    public partial class Students : Page
    {

        private readonly RMSContext _context = new RMSContext();

        public Students()
        {
            InitializeComponent();
            LoadData();

        }

        private void LoadData()
        {
            List<Student> studentList = new List<Student>();
            var students = _context.Students;
            studentList = students.ToList();
            studentsGrid.ItemsSource = studentList;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            int studentId = (studentsGrid.SelectedItem as Student).StudentId;

            EditStudentDialog editStudentDialog = new EditStudentDialog(studentId);
            editStudentDialog.ShowDialog();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            int studentId = (studentsGrid.SelectedItem as Student).StudentId;
            Student student = _context.Students.Where(x => x.StudentId == studentId).FirstOrDefault();
            _context.Students.Remove(student);
            _context.SaveChanges();
            LoadData();
        }
    }
}
