using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases {

    public class AddBookingUseCase : IAddBookingUseCase {
        private readonly IBookingRepository bookingRepository;

        public AddBookingUseCase(IBookingRepository bookingRepository) {
            this.bookingRepository = bookingRepository;
        }

        public void Execute(Booking booking) {
            bookingRepository.AddBooking(booking);
        }
    }
}