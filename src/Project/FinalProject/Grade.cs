using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Grade
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string SubjectName { get; set; }
        public string StudentName { get; set; }
        public double FirstTerm { get; set; }
        public double MidTerm { get; set; }
        public double FinalTerm { get; set; }
    }
}
