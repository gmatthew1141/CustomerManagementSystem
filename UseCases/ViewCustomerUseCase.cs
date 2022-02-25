using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases {

    public class ViewCustomerUseCase : IViewCustomerUseCase {
        private readonly ICustomerRepository customerRepository;

        public ViewCustomerUseCase(ICustomerRepository customerRepository) {
            this.customerRepository = customerRepository;
        }

        public IEnumerable<Customer> Execute() {
            return customerRepository.GetCustomers();
        }
    }
}