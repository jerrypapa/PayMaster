using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityMicroservice.Domain.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string PostCode { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public Address(Guid customerId, string postCode, string addressLine1, string addressLine2)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            PostCode = postCode;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
        }   
        public static Address AddNewAddress(Guid customerId, string postCode, string addressLine1, string addressLine2) 
        { 
            return new Address(customerId, postCode, addressLine1, addressLine2);
        }
    }
}
