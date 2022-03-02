using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases {

    public class RemoveBookingUseCase : IRemoveBookingUseCase {
        private readonly IBookingRepository bookingRepository;

        public RemoveBookingUseCase(IBookingRepository bookingRepository) {
            this.bookingRepository = bookingRepository;
        }

        public void Execute(int bookingId) {
            bookingRepository.RemoveBooking(bookingId);
        }
    }
}