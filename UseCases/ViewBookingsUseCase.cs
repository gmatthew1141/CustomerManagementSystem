using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases {

    public class ViewBookingsUseCase : IViewBookingsUseCase {
        private readonly IBookingRepository bookingRepository;

        public ViewBookingsUseCase(IBookingRepository bookingRepository) {
            this.bookingRepository = bookingRepository;
        }

        public IEnumerable<Booking> Execute() {
            return bookingRepository.GetBookings();
        }
    }
}