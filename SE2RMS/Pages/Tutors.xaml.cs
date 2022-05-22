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
    /// Interaction logic for Tutors.xaml
    /// </summary>
    public partial class Tutors : Page
    {
        private readonly RMSContext _context = new RMSContext();
        public Tutors()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            List<Staff> staffList = new List<Staff>();
            var staff = _context.Staff;
            staffList = staff.ToList();
            tutorsGrid.ItemsSource = staffList;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            int staffId = (tutorsGrid.SelectedItem as Staff).StaffId;

            EditTutorDialog editTutorDialog = new EditTutorDialog(staffId);
            editTutorDialog.ShowDialog();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            int staffId = (tutorsGrid.SelectedItem as Staff).StaffId;
            Staff staff = _context.Staff.Where(s => s.StaffId == staffId).FirstOrDefault();
            _context.Staff.Remove(staff);
            _context.SaveChanges();
            LoadData();
        }
    }
}
