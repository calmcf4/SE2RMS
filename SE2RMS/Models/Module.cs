using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2RMS.Models
{
    public class Module
    {
        public int ModuleId { get; set; }
        public int Level { get; set; }
        public int Points { get; set; }
        public string Title { get; set; }        
        public int CourseId { get; set; }        
        public string Room { get; set; }
        public string RoomType { get; set; }
        public string RoomCapacity { get; set; }
        public int StaffId { get; set; }        
        public int Student_ModuleId { get; set; }        
        public string LectureDay { get; set; }
        public string LectureTime { get; set; }


    }
}
