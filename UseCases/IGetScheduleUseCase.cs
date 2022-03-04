using CoreBusiness;
using System.Collections.Generic;

namespace UseCases {
    public interface IGetScheduleUseCase {
        IEnumerable<Schedule> Execute();
    }
}