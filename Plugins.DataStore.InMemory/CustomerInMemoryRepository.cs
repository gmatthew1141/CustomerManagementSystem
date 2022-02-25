using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory {

    public class CustomerInMemoryRepository : ICustomerRepository {
        public List<Customer> Customers;

        public CustomerInMemoryRepository() {
            Customers = new List<Customer> {
                new Customer {
                    CustomerId = 1,
                    Name = "John Doe",
                    Address = "Some address, city here",
                    PhoneNumber = "02123421441",
                    Email = "doe@mail.com",
                    Note = ""
                },
                new Customer {
                    CustomerId = 2,
                    Name = "Rushmore",
                    Address = "Some other address, some city here",
                    PhoneNumber = "08123577641",
                    Email = "more@mail.com",
                    Note = "Note 2"
                },
                new Customer {
                    CustomerId = 2,
                    Name = "Alexie Conrad",
                    Address = "Some different address, small city somewhere",
                    PhoneNumber = "5552213415",
                    Email = "ac@mail.com",
                    Note = "Required assistance regularly"
                }
            };
        }

        public IEnumerable<Customer> GetCustomers() {
            return Customers;
        }
    }
}