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
    /// Interaction logic for EditModuleDialog.xaml
    /// </summary>
    public partial class EditModuleDialog : Window
    {
        private readonly RMSContext _context = new RMSContext();
        Module moduleToEdit;
        public EditModuleDialog(int id)
        {

            InitializeComponent();
            moduleToEdit = _context.Modules.Where(m => m.ModuleId == id).FirstOrDefault();
            LoadTutors();
            LoadData(moduleToEdit);

        }

        private void EditModule(object sender, RoutedEventArgs e)
        {
            moduleToEdit.ModuleCode = moduleCodeTextBox.Text;
            moduleToEdit.Level = Int32.Parse(levelTextBox.Text);
            moduleToEdit.Points = Int32.Parse(pointsTextBox.Text);
            moduleToEdit.ModuleLeader = moduleLeaderComboBox.Text.ToString();
            moduleToEdit.Title = titleTextBox.Text;
            moduleToEdit.Room = roomTextBox.Text;
            moduleToEdit.RoomType = roomTypeTextBox.Text;
            moduleToEdit.RoomCapacity = roomCapacityTextBox.Text;
            moduleToEdit.LectureDay = lectureDayTextBox.Text;
            moduleToEdit.LectureTime = lectureTimeTextBox.Text;
            _context.SaveChanges();
            DialogResult = true;
        }

        private void LoadData(Module module)
        {
            moduleCodeTextBox.Text = module.ModuleCode;
            levelTextBox.Text = module.Level.ToString();
            pointsTextBox.Text = module.Points.ToString();
            moduleLeaderComboBox.SelectedIndex = 0;
            titleTextBox.Text = module.Title;
            roomTextBox.Text = module.Room;
            roomTypeTextBox.Text = module.RoomType;
            roomCapacityTextBox.Text = module.RoomCapacity;
            lectureDayTextBox.Text = module.LectureDay;
            lectureTimeTextBox.Text = module.LectureTime;
        }

        private void LoadTutors()
        {
            List<Staff> staffList = new List<Staff>();
            staffList = _context.Staff.ToList();
            foreach (Staff staff in staffList)
            {
                moduleLeaderComboBox.Items.Add(staff.FirstName + " " + staff.LastName);
            }            
        }
    }
}
