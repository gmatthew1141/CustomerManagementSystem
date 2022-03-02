using CoreBusiness;
using System;
using System.Collections.Generic;

namespace UseCases {
    public interface IGetBookingsByDateUseCase {
        IEnumerable<Booking> GetBookingsByDate(DateTime date, SportType type);
    }
}