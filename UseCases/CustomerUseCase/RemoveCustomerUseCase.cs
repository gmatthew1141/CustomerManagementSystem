using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases {

    public class RemoveCustomerUseCase : IRemoveCustomerUseCase {
        private readonly ICustomerRepository customerRepository;

        public RemoveCustomerUseCase(ICustomerRepository customerRepository) {
            this.customerRepository = customerRepository;
        }

        public void Execute(int productId) {
            customerRepository.RemoveCustomer(productId);
        }
    }
}