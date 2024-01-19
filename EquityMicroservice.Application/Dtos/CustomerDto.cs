using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityMicroservice.Application.Dtos
{
    public record CustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string AltPhoneNumber { get; set; }
        public string Email { get; set; }
        public string IdNumber { get; set; }
        public string KraPin { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
