using CoreBusiness;
using System.Collections.Generic;

namespace UseCases {
    public interface IViewCustomerUseCase {
        IEnumerable<Customer> Execute();
    }
}