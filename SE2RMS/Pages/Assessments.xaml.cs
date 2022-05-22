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
    /// Interaction logic for Assessments.xaml
    /// </summary>
    public partial class Assessments : Page
    {
        private readonly RMSContext _context = new RMSContext();
        public Assessments()
        {
            InitializeComponent();
            LoadData();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            int assessmentId = (assessmentsGrid.SelectedItem as Assessment).AssessmentId;

            EditAssessmentDialog editAssessmentDialog = new EditAssessmentDialog(assessmentId);
            editAssessmentDialog.ShowDialog();
        }

        private void LoadData()
        {
            List<Assessment> assessmentList = new List<Assessment>();
            var assessments = _context.Assessments;
            assessmentList = assessments.ToList();
            assessmentsGrid.ItemsSource = assessmentList;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            int assessmentId = (assessmentsGrid.SelectedItem as Assessment).AssessmentId;
            Assessment assessment = _context.Assessments.Where(x => x.AssessmentId == assessmentId).FirstOrDefault();
            _context.Assessments.Remove(assessment);
            _context.SaveChanges();
            LoadData();
        }
    }
}
