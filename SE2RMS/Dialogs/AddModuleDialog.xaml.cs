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
    /// Interaction logic for AddModuleDialog.xaml
    /// </summary>
    public partial class AddModuleDialog : Window
    {
        private readonly RMSContext _context = new RMSContext();
        public AddModuleDialog()
        {
            InitializeComponent();
            LoadTutors();
        }

        private void LoadTutors()
        {
            List<Staff> staffList = new List<Staff>();
            staffList = _context.Staff.ToList();
            foreach (Staff staff in staffList)
            {
                moduleLeaderComboBox.Items.Add(staff.FirstName + " " + staff.LastName);
            }
            moduleLeaderComboBox.SelectedIndex = 0;
        }

        private void addModule(object sender, RoutedEventArgs e)
        {
            Module module = new Module();
            module.ModuleCode = moduleCodeTextBox.Text;
            module.Level = Int32.Parse(levelTextBox.Text);
            module.Points = Int32.Parse(pointsTextBox.Text);
            module.Title = titleTextBox.Text;
            module.CourseId = 1;
            module.Room = roomTextBox.Text;
            module.RoomType = roomTypeTextBox.Text;
            module.RoomCapacity = roomCapacityTextBox.Text;
            module.StaffId = 1;
            module.Student_ModuleId = 1;
            module.LectureDay = lectureDayTextBox.Text;
            module.LectureTime = lectureTimeTextBox.Text;
            module.ModuleLeader = moduleLeaderComboBox.Text.ToString();
            _context.Modules.Add(module);
            _context.SaveChanges();
            this.DialogResult = true;
        }
    }
}
