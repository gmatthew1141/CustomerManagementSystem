using CoreBusiness;
using System.Collections.Generic;

namespace UseCases {
    public interface IViewBookingsUseCase {
        IEnumerable<Booking> Execute();
    }
}