using CoreBusiness;

namespace RacquetWebapp {
    public interface IAddCustomerUseCase {
        void Execute(Customer customer);
    }
}