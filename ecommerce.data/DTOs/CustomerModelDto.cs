using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.data.DTOs
{
    public class CustomerModelDto
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
