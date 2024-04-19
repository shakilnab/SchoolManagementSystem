using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject;

public class ClassSubject
{
    public int ClassId { get; set; }
    public ClassS ClassS { get; set; }

    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
}
