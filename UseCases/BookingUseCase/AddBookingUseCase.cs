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
        private readonly IAttendanceRepository attendanceRepository;

        public AddBookingUseCase(IBookingRepository bookingRepository, IAttendanceRepository attendanceRepository) {
            this.bookingRepository = bookingRepository;
            this.attendanceRepository = attendanceRepository;
        }

        public void Execute(Booking booking) {
            attendanceRepository.GenerateAttendance(bookingRepository.AddBooking(booking));
        }
    }
}