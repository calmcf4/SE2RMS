using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2RMS.Models
{
    public class Register
    {
        public int RegisterId { get; set; }
        public int ModuleCode { get; set; }        
        public DateTime Date { get; set; }
        public int AttendancePercent { get; set; }

    }
}
