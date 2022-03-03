using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases {

    public class RemoveBookingUseCase : IRemoveBookingUseCase {
        private readonly IBookingRepository bookingRepository;
        private readonly IAttendanceRepository attendanceRepository;

        public RemoveBookingUseCase(IBookingRepository bookingRepository, IAttendanceRepository attendanceRepository) {
            this.bookingRepository = bookingRepository;
            this.attendanceRepository = attendanceRepository;
        }

        public void Execute(int bookingId) {
            attendanceRepository.RemoveAttendance(bookingId);
            bookingRepository.RemoveBooking(bookingId);
        }
    }
}