using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
     
        public string Street { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public Customer Customer { get; set; }
    }
}
