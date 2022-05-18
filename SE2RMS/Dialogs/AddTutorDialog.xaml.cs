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
    /// Interaction logic for AddTutorDialog.xaml
    /// </summary>
    public partial class AddTutorDialog : Window
    {
        private readonly RMSContext _context = new RMSContext();
        public AddTutorDialog()
        {
            InitializeComponent();
        }

        private void addTutor(object sender, RoutedEventArgs e)
        {
            Staff staff = new Staff();
            staff.FirstName = firstNameTextBox.Text;
            staff.MiddleName = middleNameTextBox.Text;
            staff.LastName = lastNameTextBox.Text;
            staff.Address = addressTextBox.Text;
            staff.PhoneNumber = phoneNumberTextBox.Text;
            staff.Email = emailTextBox.Text;
            staff.Role = roleTextBox.Text;
            staff.Subject = subjectTextBox.Text;
            staff.Status = "Live";
            staff.DormancyReason = "";
            staff.CourseId = 1;
            _context.Staff.Add(staff);
            _context.SaveChanges();
            this.DialogResult = true;
        }
    }
}
