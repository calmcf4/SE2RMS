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
    /// Interaction logic for EditTutorDialog.xaml
    /// </summary>
    public partial class EditTutorDialog : Window
    {
        private readonly RMSContext _context = new RMSContext();
        Staff staffToEdit;
        public EditTutorDialog(int id)
        {
            InitializeComponent();
            staffToEdit = _context.Staff.Where(s => s.StaffId == id).FirstOrDefault();
            GetCourses();
            LoadData(staffToEdit);

        }

        private void EditTutor(object sender, RoutedEventArgs e)
        {
            staffToEdit.FirstName = firstNameTextBox.Text;
            staffToEdit.MiddleName = middleNameTextBox.Text;
            staffToEdit.LastName = lastNameTextBox.Text;
            staffToEdit.Address = addressTextBox.Text;
            staffToEdit.PhoneNumber = phoneNumberTextBox.Text;
            staffToEdit.Email = emailTextBox.Text;
            staffToEdit.Role = roleComboBox.Text.ToString();
            staffToEdit.Subject = subjectComboBox.Text.ToString();
            staffToEdit.Status = statusComboBox.Text.ToString();
            _context.SaveChanges();
            DialogResult = true;
        }

        private void LoadData(Staff staff)
        {

            firstNameTextBox.Text = staff.FirstName;
            middleNameTextBox.Text = staff.MiddleName;
            lastNameTextBox.Text = staff.LastName;
            addressTextBox.Text = staff.Address;
            phoneNumberTextBox.Text = staff.PhoneNumber;
            emailTextBox.Text = staff.Email;
            subjectComboBox.SelectedIndex = 0;
            roleComboBox.SelectedIndex = 0;
            statusComboBox.SelectedIndex = 0;

        }

        private void GetCourses()
        {
            List<Course> courses = new List<Course>();
            courses = _context.Courses.ToList();
            foreach (Course course in courses)
            {
                subjectComboBox.Items.Add(course.Name);
            }

        }
    }
}
