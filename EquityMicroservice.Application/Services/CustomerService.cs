using EquityMicroservice.Application.Commands;
using EquityMicroservice.Domain.Entities;
using EquityMicroservice.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityMicroservice.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository??
                throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<Guid> CreateCustomerAsync(CreateCustomerCommand customerCommand)
        {
            try
            {
                var newCustomer = Customer
                    .AddNewCustomer(customerCommand.customerDetails.FirstName,
                    customerCommand.customerDetails.LastName,
                    customerCommand.customerDetails.PhoneNumber,
                    customerCommand.customerDetails.AltPhoneNumber,
                    customerCommand.customerDetails.Email,
                    customerCommand.customerDetails.IdNumber,
                    customerCommand.customerDetails.KraPin,
                   Guid.Empty,
                   customerCommand.customerDetails.DateOfBirth
                    );
                await _customerRepository.SaveCustomerAsync(newCustomer);
                return newCustomer.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
