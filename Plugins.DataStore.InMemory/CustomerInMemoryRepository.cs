using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    CustomerId = 3,
                    Name = "Alexie Conrad",
                    Address = "Some different address, small city somewhere",
                    PhoneNumber = "5552213415",
                    Email = "ac@mail.com",
                    Note = "Required assistance regularly"
                }
            };
        }

        public void AddCustomer(Customer customer) {
            int customerId;

            // When the list is not empty
            if (Customers != null && Customers.Count > 0) {
                var maxId = Customers.Max(x => x.CustomerId);
                customerId = ++maxId;
            } else {
                customerId = 1;
            }

            var newCustomer = customer;
            newCustomer.CustomerId = customerId;

            Customers.Add(newCustomer);
        }

        public void UpdateCustomer(Customer customer) {
            var cust = GetCustomerById(customer.CustomerId);

            if (cust != null) {
                cust.Name = customer.Name;
                cust.Address = customer.Address;
                cust.PhoneNumber = customer.PhoneNumber;
                cust.Email = customer.Email;
                cust.Note = customer.Note;
            }
        }

        public Customer GetCustomerById(int customerId) {
            return Customers.Find(x => x.CustomerId == customerId);
        }

        public IEnumerable<Customer> GetCustomers() {
            return Customers;
        }

        public void RemoveCustomer(int customerId) {
            var customer = GetCustomerById(customerId);

            if (customer != null) {
                Customers.Remove(customer);
            }
        }
    }
}