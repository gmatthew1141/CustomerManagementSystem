using CoreBusiness;

namespace UseCases {
    public interface IGetBookingByIdUseCase {
        Booking GetBooking(int bookingId);
    }
}