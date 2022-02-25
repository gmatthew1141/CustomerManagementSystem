using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace RacquetWebapp {

    public class AddCustomerUseCase : IAddCustomerUseCase {
        private readonly ICustomerRepository customerRepository;

        public AddCustomerUseCase(ICustomerRepository customerRepository) {
            this.customerRepository = customerRepository;
        }

        public void Execute(Customer customer) {
            customerRepository.AddCustomer(customer);
        }
    }
}