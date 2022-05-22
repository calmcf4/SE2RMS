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
using System.Windows.Shapes;

namespace SE2RMS.Dialogs
{
    /// <summary>
    /// Interaction logic for AddStudentDialog.xaml
    /// </summary>
    public partial class AddStudentDialog : Window
    {
        private readonly RMSContext _context = new RMSContext();

        public AddStudentDialog()
        {
            InitializeComponent();
            LoadTutors();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            firstNameTextBox.SelectAll();
            firstNameTextBox.Focus();
        }

        private void AddStudent(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            student.FirstName = firstNameTextBox.Text;
            student.MiddleName = middleNameTextBox.Text;
            student.LastName = lastNameTextBox.Text;
            student.TermAddress = termAddressTextBox.Text;
            student.NonTermAddress = nonTermAddressTextBox.Text;
            student.PhoneNumber = phoneNumberTextBox.Text;
            student.Email = emailTextBox.Text;
            student.EntryQuals = entryQualsTextBox.Text;
            student.CourseId = 1;
            student.Status = "Live";
            student.DormancyReason = "";
            student.PersonalTutor = personalTutorComboBox.Text.ToString();
            _context.Students.Add(student);
            _context.SaveChanges();
            this.DialogResult = true;
        }

        private void LoadTutors()
        {
            List<Staff> staffList = new List<Staff>();
            staffList = _context.Staff.ToList();
            foreach (Staff staff in staffList)
            {
                personalTutorComboBox.Items.Add(staff.FirstName + " " + staff.LastName);
            }
            personalTutorComboBox.SelectedIndex = 0;
        }
    }
}
