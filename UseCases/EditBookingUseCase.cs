using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases {

    public class EditBookingUseCase : IEditBookingUseCase {
        private readonly IBookingRepository bookingRepository;

        public EditBookingUseCase(IBookingRepository bookingRepository) {
            this.bookingRepository = bookingRepository;
        }

        public void Execute(Booking booking) {
            bookingRepository.UpdateBooking(booking);
        }
    }
}