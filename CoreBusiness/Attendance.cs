using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness {

    public class Attendance {
        public int AttendanceId { get; set; }
        public int BookingId { get; set; }
        public DateTime PlayDate { get; set; }
        public int PlayTime { get; set; }
        public SportType SportType { get; set; }
        public int CourtNum { get; set; }
        public bool Present { get; set; }
    }
}