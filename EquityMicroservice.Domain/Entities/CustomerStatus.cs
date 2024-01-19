using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityMicroservice.Domain.Entities
{
    public class CustomerStatus
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Codes will contain actual Customer Account status
        /// </summary>
        public string Code { get; set; }
        public string Description { get; set; }
        public CustomerStatus(string code, string description)
        {
            Id = Guid.NewGuid();
            Code = code;
            Description = description;
        }  
        public static CustomerStatus AddStatus(string code, string description) 
        {
            return new CustomerStatus(code, description);

        }
    }
}
