using CoreBusiness;

namespace UseCases {

    public interface IUpdateAttendanceUseCase {

        void Execute(Schedule schedule, Attendance attendance);
    }
}