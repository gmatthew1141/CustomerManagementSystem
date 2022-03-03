using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory {

    public class AttendanceInMemoryRepository : IAttendanceRepository {
        public List<Attendance> Attendances;

        public AttendanceInMemoryRepository() {
            Attendances = new List<Attendance> {
                new Attendance {
                    AttendanceId = 1,
                    BookingId = 1,
                    PlayDate = DateTime.Today,
                    PlayTime = 5,
                    SportType = SportType.Tennis,
                    CourtNum = 1,
                    Present = false
                },
                new Attendance {
                    AttendanceId = 2,
                    BookingId = 1,
                    PlayDate = DateTime.Today.AddDays(7),
                    PlayTime = 5,
                    SportType = SportType.Tennis,
                    CourtNum = 1,
                    Present = false
                },
                new Attendance {
                    AttendanceId = 3,
                    BookingId = 2,
                    PlayDate = DateTime.Today,
                    PlayTime = 6,
                    SportType = SportType.Tennis,
                    CourtNum = 3,
                    Present = false
                },
                new Attendance {
                    AttendanceId = 4,
                    BookingId = 2,
                    PlayDate = DateTime.Today.AddDays(7),
                    PlayTime = 6,
                    SportType = SportType.Tennis,
                    CourtNum = 3,
                    Present = false
                }
            };
        }

        public void GenerateAttendance(Booking booking) {
            // Loop 'num of play' and 'duration' times
            // Create a new attendance for each time range
            // generate attendance id
            // Get information required

            for (int i = 0; i < booking.NumOfPlay; i++) {
                for (int j = 0; j < booking.Duration; j++) {
                    int attendanceId;
                    if (Attendances != null && Attendances.Count != 0) {
                        int maxId = Attendances.Max(x => x.AttendanceId);
                        attendanceId = ++maxId;
                    } else {
                        attendanceId = 1;
                    }

                    Attendance newAttendance = new Attendance {
                        AttendanceId = attendanceId,
                        BookingId = booking.BookingId,
                        PlayDate = booking.StartDate.AddDays(i * 7),
                        PlayTime = booking.StartTime + j,
                        SportType = booking.SportType,
                        CourtNum = booking.CourtNum,
                        Present = false,
                    };

                    Attendances.Add(newAttendance);
                }
            }
        }

        public IEnumerable<Attendance> GetAttendancesByBookingId(int bookingId) {
            return Attendances.FindAll(x => x.BookingId == bookingId);
        }

        public void RemoveAttendance(int bookingId) {
            var attendances = GetAttendancesByBookingId(bookingId);

            foreach (var attendance in attendances) {
                Attendances.Remove(attendance);
            }
        }

        public IEnumerable<Attendance> GetAttendanceByDate(DateTime date, SportType type) {
            return Attendances.FindAll(x => x.PlayDate.Equals(date) && x.SportType == type);
        }
    }
}