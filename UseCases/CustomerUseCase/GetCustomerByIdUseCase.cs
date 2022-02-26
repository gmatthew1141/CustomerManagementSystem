using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases {

    public class GetCustomerByIdUseCase : IGetCustomerByIdUseCase {
        private readonly ICustomerRepository customerRepository;

        public GetCustomerByIdUseCase(ICustomerRepository customerRepository) {
            this.customerRepository = customerRepository;
        }

        public Customer GetCustomerById(int customerId) {
            return customerRepository.GetCustomerById(customerId);
        }
    }
}