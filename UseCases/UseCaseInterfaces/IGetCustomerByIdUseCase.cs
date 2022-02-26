using CoreBusiness;

namespace UseCases {
    public interface IGetCustomerByIdUseCase {
        Customer GetCustomerById(int customerId);
    }
}