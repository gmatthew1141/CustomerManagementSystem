using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases {

    public class UpdateAttendanceUseCase : IUpdateAttendanceUseCase {
        private readonly IAttendanceRepository attendaceRepository;
        private readonly IScheduleRepository scheduleRepository;
        private readonly IBookingRepository bookingRepository;

        public UpdateAttendanceUseCase(IAttendanceRepository attendaceRepository, IScheduleRepository scheduleRepository, IBookingRepository bookingRepository) {
            this.attendaceRepository = attendaceRepository;
            this.scheduleRepository = scheduleRepository;
            this.bookingRepository = bookingRepository;
        }

        public void Execute(Schedule schedule, Attendance attendance) {
            attendaceRepository.UpdateAttendance(attendance);
            scheduleRepository.CountAttendance(schedule);
            bookingRepository.UpdateNumPlayed(attendance.BookingId, attendance.Present);
        }
    }
}