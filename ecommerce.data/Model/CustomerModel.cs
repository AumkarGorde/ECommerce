using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.data.Model
{
    public class CustomerModel
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Guid AddressId { get; set; }
        public string Address { get; set; }
    }
}
