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
    }
}