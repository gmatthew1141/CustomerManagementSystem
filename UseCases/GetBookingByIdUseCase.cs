using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases {

    public class GetBookingByIdUseCase : IGetBookingByIdUseCase {
        private readonly IBookingRepository bookingRepository;

        public GetBookingByIdUseCase(IBookingRepository bookingRepository) {
            this.bookingRepository = bookingRepository;
        }

        public Booking GetBooking(int bookingId) {
            return bookingRepository.GetBookingById(bookingId);
        }
    }
}