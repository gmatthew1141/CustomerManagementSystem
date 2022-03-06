using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL {

    public class CustomerRepository : ICustomerRepository {
        private readonly ScheduleContext db;

        public CustomerRepository(ScheduleContext db) {
            this.db = db;
        }

        public void AddCustomer(Customer customer) {
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public Customer GetCustomerById(int customerId) {
            return db.Customers.Find(customerId);
        }

        public IEnumerable<Customer> GetCustomers() {
            return db.Customers.ToList();
        }

        public void RemoveCustomer(int customerId) {
            var cust = db.Customers.Find(customerId);

            if (cust != null) {
                db.Customers.Remove(cust);
                db.SaveChanges();
            }
        }

        public void UpdateCustomer(Customer customer) {
            var cust = db.Customers.Find(customer.CustomerId);

            cust.Name = customer.Name;
            cust.Address = customer.Address;
            cust.PhoneNumber = customer.PhoneNumber;
            cust.Email = customer.Email;
            cust.Note = customer.Note;

            db.SaveChanges();
        }
    }
}