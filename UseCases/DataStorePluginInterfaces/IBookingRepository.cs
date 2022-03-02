using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces {

    public interface IBookingRepository {

        IEnumerable<Booking> GetBookings();

        string GetTimestampByKey(int key);

        IEnumerable<KeyValuePair<int, string>> GetTimestamps();

        void AddBooking(Booking booking);

        void UpdateBooking(Booking booking);

        Booking GetBookingById(int bookingId);

        void RemoveBooking(int id);

        IEnumerable<Booking> GetBookingByDate(DateTime date, SportType type);
    }
}