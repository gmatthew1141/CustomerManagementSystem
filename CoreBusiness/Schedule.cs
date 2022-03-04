using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness {

    public class Schedule {
        public string Timestamp { get; set; }
        public Attendance Court1 { get; set; }
        public Attendance Court2 { get; set; }
        public Attendance Court3 { get; set; }
        public Attendance Court4 { get; set; }
        public int TotalAttendance { get; set; }
    }
}