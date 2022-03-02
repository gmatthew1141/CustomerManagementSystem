using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases {

    public class GetBookingsByDateUseCase : IGetBookingsByDateUseCase {
        private readonly IBookingRepository bookingRepository;

        public GetBookingsByDateUseCase(IBookingRepository bookingRepository) {
            this.bookingRepository = bookingRepository;
        }

        public IEnumerable<Booking> GetBookingsByDate(DateTime date, SportType type) {
            return bookingRepository.GetBookingByDate(date, type);
        }
    }
}