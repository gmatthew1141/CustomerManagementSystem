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
        private readonly IAttendanceRepository attendanceRepository;

        public EditBookingUseCase(IBookingRepository bookingRepository, IAttendanceRepository attendanceRepository) {
            this.bookingRepository = bookingRepository;
            this.attendanceRepository = attendanceRepository;
        }

        public void Execute(Booking booking) {
            attendanceRepository.RemoveAttendance(booking.BookingId);
            bookingRepository.UpdateBooking(booking);
            attendanceRepository.GenerateAttendance(booking);
        }
    }
}