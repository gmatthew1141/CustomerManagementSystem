using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness {

    public class Customer {
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public string Note { get; set; }

        // Navigation property for EF Core
        public List<Booking> Bookings { get; set; }
    }
}