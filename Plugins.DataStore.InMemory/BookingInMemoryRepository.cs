using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory {

    public class BookingInMemoryRepository : IBookingRepository {
        private List<Booking> Bookings;
        private Dictionary<int, string> Timestamps;

        public BookingInMemoryRepository() {
            Bookings = new List<Booking> {
                new Booking {
                    BookingId = 1,
                    CustomerId = 1,
                    StartTime = 0,
                    Duration = 2,
                    SportType = SportType.Tennis,
                    CourtNum = 2,
                    StartDate = DateTime.Today.AddDays(5),
                    ExpirationDate = DateTime.Today.AddDays(12),
                    NumOfPlay = 1,
                    NumOfPlayed = 0,
                    NumOfPlayedLeft = 1,
                    Note = ""
                },
                new Booking {
                    BookingId = 2,
                    CustomerId = 3,
                    StartTime = 1,
                    Duration = 2,
                    SportType = SportType.Squash,
                    CourtNum = 2,
                    StartDate = DateTime.Today.AddDays(3),
                    ExpirationDate = DateTime.Today.AddDays(10),
                    NumOfPlay = 1,
                    NumOfPlayed = 0,
                    NumOfPlayedLeft = 1,
                    Note = "Some long note that will be filled by someone who is still alive"
                },
                new Booking {
                    BookingId = 3,
                    CustomerId = 2,
                    StartTime = 2,
                    Duration = 2,
                    SportType = SportType.Tennis,
                    CourtNum = 2,
                    StartDate = DateTime.Today.AddDays(-7),
                    ExpirationDate = DateTime.Today.AddDays(14),
                    NumOfPlay = 3,
                    NumOfPlayed = 1,
                    NumOfPlayedLeft = 2,
                    Note = "Weirdly short note"
                },
            };

            Timestamps = new Dictionary<int, string>();
            #region
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
            #endregion
        }

        public void AddBooking(Booking booking) {
            int bookingId;

            if (Bookings != null && Bookings.Count > 0) {
                int maxId = Bookings.Max(x => x.BookingId);
                bookingId = ++maxId;
            } else {
                bookingId = 1;
            }

            // Calculate expiration date
            var expirationDate = booking.StartDate.AddDays(7 * (booking.NumOfPlay - 1));

            var newBooking = new Booking {
                BookingId = bookingId,
                CustomerId = booking.CustomerId,
                StartTime = booking.StartTime,
                Duration = booking.Duration,
                SportType = booking.SportType,
                CourtNum = booking.CourtNum,
                StartDate = booking.StartDate,
                ExpirationDate = expirationDate,
                NumOfPlay = booking.NumOfPlay,
                NumOfPlayed = 0,
                NumOfPlayedLeft = booking.NumOfPlay,
                Note = booking.Note
            };

            Bookings.Add(newBooking);
        }

        public IEnumerable<Booking> GetBookings() {
            return Bookings;
        }

        public string GetTimestampByKey(int key) {
            if (Timestamps.ContainsKey(key)) {
                return Timestamps[key];
            }

            return "Timestamp key not available.";
        }

        public IEnumerable<KeyValuePair<int, string>> GetTimestamps() {
            if (Timestamps != null) {
                return Timestamps;
            }
            return null;
        }
    }
}