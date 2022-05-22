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
    /// Interaction logic for AddAssessmentDialog.xaml
    /// </summary>
    public partial class AddAssessmentDialog : Window
    {
        private readonly RMSContext _context = new RMSContext();
        public AddAssessmentDialog()
        {
            InitializeComponent();
            GetModules();
        }

        private void addAssessment(object sender, RoutedEventArgs e)
        {
            Assessment assessment = new Assessment();
            assessment.ModuleCode = moduleCodeComboBox.Text.ToString();
            assessment.AssessmentType = typeTextBox.Text;
            assessment.Weighting = Int32.Parse(weightingTextBox.Text);
            _context.Assessments.Add(assessment);
            _context.SaveChanges();
            this.DialogResult = true;
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
    }
}
