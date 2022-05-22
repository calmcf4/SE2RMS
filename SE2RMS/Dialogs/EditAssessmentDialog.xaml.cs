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
    /// Interaction logic for EditAssessmentDialog.xaml
    /// </summary>
    public partial class EditAssessmentDialog : Window
    {

        private readonly RMSContext _context = new RMSContext();
        Assessment assessmentToEdit;
        public EditAssessmentDialog(int id)
        {
            InitializeComponent();
            GetModules();
            assessmentToEdit = _context.Assessments.Where(a => a.AssessmentId == id).FirstOrDefault();
            LoadData(assessmentToEdit);
        }


        private void LoadData(Assessment assessment)
        {
            moduleCodeComboBox.SelectedIndex = 0;
            typeTextBox.Text = assessment.AssessmentType;
            weightingTextBox.Text = assessment.Weighting.ToString();
        }

        private void GetModules()
        {
            List<Module> modules = new List<Module>();
            modules = _context.Modules.ToList();
            foreach (Module module in modules)
            {
                moduleCodeComboBox.Items.Add(module.ModuleCode);
            }
            moduleCodeComboBox.SelectedIndex = 0;
        }

        private void EditAssessment(object sender, RoutedEventArgs e)
        {
            assessmentToEdit.ModuleCode = moduleCodeComboBox.SelectedItem.ToString();
            assessmentToEdit.AssessmentType = typeTextBox.Text;
            assessmentToEdit.Weighting = Int32.Parse(weightingTextBox.Text);
            _context.SaveChanges();
            DialogResult = true;
        }
    }
}
