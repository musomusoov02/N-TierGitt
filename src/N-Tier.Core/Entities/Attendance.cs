using Microsoft.VisualBasic;
using N_Tier.Core.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities;

public class Attendance : BaseEntity
{
    public int StudentId { get; set; }  
    public Student Student { get; set; }
    public DateTime Data { get; set; }
    public int AttendanceStatusId { get; set; }
    public AttendanceStatus? AttendanceStatus { get; set; }

    
}

//public enum Status
//{
//    Present,
//    Absent,
//    Late,
//    Sick
//}

