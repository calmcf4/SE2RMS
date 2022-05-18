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
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class Modules : Page
    {
        private readonly RMSContext _context = new RMSContext();
        public Modules()
        {
            InitializeComponent();
            List<Module> moduleList = new List<Module>();
            var modules = _context.Modules;
            moduleList = modules.ToList();
            modulesGrid.ItemsSource = moduleList;
        }
        
    }
}
