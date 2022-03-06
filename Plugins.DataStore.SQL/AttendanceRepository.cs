using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL {

    public class AttendanceRepository : IAttendanceRepository {
        private readonly ScheduleContext db;

        public AttendanceRepository(ScheduleContext db) {
            this.db = db;
        }

        public void GenerateAttendance(Booking booking) {
            for (int i = 0; i < booking.NumOfPlay; i++) {
                for (int j = 0; j < booking.Duration; j++) {
                    Attendance newAttendance = new Attendance {
                        BookingId = booking.BookingId,
                        PlayDate = booking.StartDate.AddDays(i * 7),
                        PlayTime = booking.StartTime + j,
                        SportType = booking.SportType,
                        CourtNum = booking.CourtNum,
                        Present = false,
                    };

                    db.Attendances.Add(newAttendance);
                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<Attendance> GetAttendanceByDate(DateTime date, SportType type) {
            return db.Attendances.Where(x => x.PlayDate.Equals(date) && x.SportType == type);
        }

        public IEnumerable<Attendance> GetAttendancesByBookingId(int attendanceId) {
            return db.Attendances.Where(x => x.AttendanceId == attendanceId);
        }

        public void RemoveAttendance(int bookingId) {
            foreach (var att in db.Attendances.Where(x => x.BookingId == bookingId)) {
                db.Attendances.Remove(att);
            }

            db.SaveChanges();
        }

        public void UpdateAttendance(Attendance attendance) {
            var att = db.Attendances.Find(attendance.AttendanceId);

            att.Present = !att.Present;

            db.SaveChanges();
        }
    }
}