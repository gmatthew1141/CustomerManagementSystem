using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces {

    public interface IAttendanceRepository {

        void GenerateAttendance(Booking booking);

        void RemoveAttendance(int bookingId);

        IEnumerable<Attendance> GetAttendancesByBookingId(int attendanceId);

        IEnumerable<Attendance> GetAttendanceByDate(DateTime date, SportType type);
    }
}