using CoreBusiness;
using System;
using System.Collections.Generic;

namespace UseCases {

    public interface IGetAttendanceByDateUseCase {

        IEnumerable<Attendance> Execute(DateTime date, SportType type);
    }
}