using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2RMS.Models
{
    public class Assessment
    {
        public int AssessmentId { get; set; }
        public string ModuleCode { get; set; }        
        public string AssessmentType { get; set; }
        public int Weighting { get; set; }
    }
}
