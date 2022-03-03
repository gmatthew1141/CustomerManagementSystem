using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases {

    public class GetAttendanceByDateUseCase : IGetAttendanceByDateUseCase {
        private readonly IAttendanceRepository attendanceRepository;

        public GetAttendanceByDateUseCase(IAttendanceRepository attendanceRepository) {
            this.attendanceRepository = attendanceRepository;
        }

        public IEnumerable<Attendance> Execute(DateTime date, SportType type) {
            return attendanceRepository.GetAttendanceByDate(date, type);
        }
    }
}