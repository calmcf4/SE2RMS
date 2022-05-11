using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2RMS.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string? TermAddress { get; set; }
        public string? NonTermAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string EntryQuals { get; set; }
        //public int CourseId { get; set; }        
        public string Status { get; set; }
        public string? DormancyReason { get; set; }

    }
}
