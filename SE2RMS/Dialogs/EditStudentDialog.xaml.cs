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
    /// Interaction logic for EditStudentDialog.xaml
    /// </summary>
    public partial class EditStudentDialog : Window
    {
        private readonly RMSContext _context = new RMSContext();
        Student studentToEdit;

        public EditStudentDialog(int id)
        {
            InitializeComponent();
            studentToEdit = _context.Students.Where(s => s.StudentId == id).FirstOrDefault();
            LoadTutors();
            LoadData(studentToEdit);
        }

        private void LoadData(Student student)
        {
            firstNameTextBox.Text = student.FirstName;
            middleNameTextBox.Text = student.MiddleName;
            lastNameTextBox.Text = student.LastName;
            termAddressTextBox.Text = student.TermAddress;
            nonTermAddressTextBox.Text = student.NonTermAddress;
            phoneNumberTextBox.Text = student.PhoneNumber;
            emailTextBox.Text = student.Email;
            entryQualsTextBox.Text = student.EntryQuals;
            personalTutorComboBox.SelectedIndex = 0;
            statusComboBox.SelectedIndex = 0;
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

        private void EditStudent(object sender, RoutedEventArgs e)
        {
            studentToEdit.FirstName = firstNameTextBox.Text;
            studentToEdit.MiddleName = middleNameTextBox.Text;
            studentToEdit.LastName = lastNameTextBox.Text;
            studentToEdit.NonTermAddress = nonTermAddressTextBox.Text;
            studentToEdit.TermAddress = termAddressTextBox.Text;
            studentToEdit.PhoneNumber = phoneNumberTextBox.Text;
            studentToEdit.Email = emailTextBox.Text;
            studentToEdit.EntryQuals = entryQualsTextBox.Text;
            studentToEdit.PersonalTutor = personalTutorComboBox.Text.ToString();
            studentToEdit.Status = studentToEdit.Status.ToString();
            _context.SaveChanges();
            DialogResult = true;
        }
    }


}
