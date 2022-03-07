using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL {

    public class BookingRepository : IBookingRepository {
        private readonly ScheduleContext db;

        private Dictionary<int, string> Timestamps;

        public BookingRepository(ScheduleContext db) {
            this.db = db;

            Timestamps = new Dictionary<int, string>();

            #region Timestamps Initialization

            Timestamps.Add(0, "05:00");
            Timestamps.Add(1, "06:00");
            Timestamps.Add(2, "07:00");
            Timestamps.Add(3, "08:00");
            Timestamps.Add(4, "09:00");
            Timestamps.Add(5, "10:00");
            Timestamps.Add(6, "11:00");
            Timestamps.Add(7, "12:00");
            Timestamps.Add(8, "13:00");
            Timestamps.Add(9, "14:00");
            Timestamps.Add(10, "15:00");
            Timestamps.Add(11, "16:00");
            Timestamps.Add(12, "17:00");
            Timestamps.Add(13, "18:00");
            Timestamps.Add(14, "19:00");
            Timestamps.Add(15, "20:00");
            Timestamps.Add(16, "21:00");
            Timestamps.Add(17, "22:00");
            Timestamps.Add(18, "23:00");
            Timestamps.Add(19, "24:00");

            #endregion Timestamps Initialization
        }

        public Booking AddBooking(Booking booking) {
            booking.ExpirationDate = GetExpirationDate(booking.StartDate, booking.NumOfPlay);
            booking.EndTime = GetEndTime(booking.StartTime, booking.Duration);
            booking.NumOfPlayedLeft = booking.NumOfPlay - booking.NumOfPlayed;

            db.Bookings.Add(booking);
            db.SaveChanges();
            return booking;
        }

        public IEnumerable<Booking> GetBookingByDate(DateTime date, SportType type) {
            return db.Bookings.Where(x => x.StartDate.Equals(date) && x.SportType == type);
        }

        public Booking GetBookingById(int bookingId) {
            return db.Bookings.Find(bookingId);
        }

        public IEnumerable<Booking> GetBookings() {
            return db.Bookings.ToList();
        }

        public string GetTimestampByKey(int key) {
            if (Timestamps.ContainsKey(key)) {
                return Timestamps[key];
            }

            return "Timestamp key not available.";
        }

        public IEnumerable<KeyValuePair<int, string>> GetTimestamps() {
            return Timestamps != null ? Timestamps : null;
        }

        public void RemoveBooking(int id) {
            var booking = db.Bookings.Find(id);
            if (booking != null) {
                db.Bookings.Remove(booking);
                db.SaveChanges();
            }
        }

        public void UpdateBooking(Booking booking) {
            var book = db.Bookings.Find(booking.BookingId);

            book.CustomerId = booking.CustomerId;
            book.StartTime = booking.StartTime;
            book.Duration = booking.Duration;
            book.SportType = booking.SportType;
            book.CourtNum = booking.CourtNum;
            book.NumOfPlay = booking.NumOfPlay;
            book.NumOfPlayed = booking.NumOfPlayed;
            book.Note = booking.Note;

            db.SaveChanges();
        }

        public void UpdateNumPlayed(int bookingId, bool attendance) {
            var booking = db.Bookings.Find(bookingId);

            if (attendance) {
                booking.NumOfPlayed++;
            } else {
                booking.NumOfPlayed--;
            }

            booking.NumOfPlayedLeft = booking.NumOfPlay - booking.NumOfPlayed;

            db.SaveChanges();
        }

        private DateTime GetExpirationDate(DateTime startDate, int numOfPlay) {
            return startDate.AddDays(7 * (numOfPlay - 1));
        }

        private int GetEndTime(int startTime, int duration) {
            return startTime + duration;
        }
    }
}