using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2RMS.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public char GradeGiven { get; set; }
        public int ModuleCode { get; set; }        
        public int StudentId { get; set; }        

    }
}
