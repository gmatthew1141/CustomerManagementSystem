using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases {

    public class EditCustomerUseCase : IEditCustomerUseCase {
        private readonly ICustomerRepository customerRepository;

        public EditCustomerUseCase(ICustomerRepository customerRepository) {
            this.customerRepository = customerRepository;
        }

        public void Execute(Customer customer) {
            customerRepository.UpdateCustomer(customer);
        }
    }
}