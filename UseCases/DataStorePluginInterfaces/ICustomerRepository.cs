using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces {

    public interface ICustomerRepository {

        IEnumerable<Customer> GetCustomers();

        void AddCustomer(Customer customer);

        void UpdateCustomer(Customer customer);

        Customer GetCustomerById(int customerId);

        void RemoveCustomer(int customerId);
    }
}