using EasyNetQ;
using EquityMicroservice.Application.Commands;
using EquityMicroservice.Domain.Entities;
using EquityMicroservice.Domain.Repositories;
using Paymaster.Contracts;
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
        private readonly IBus _bus;
        public CustomerService(ICustomerRepository customerRepository,IBus bus)
        {
            _customerRepository = customerRepository??
                throw new ArgumentNullException(nameof(customerRepository));
            _bus = bus;
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

                await _bus.PubSub.PublishAsync(new NewCustomerEvent
                {
                    AccountNumber= await GenerateAccountNo(string.Empty),
                    Email= customerCommand.customerDetails.Email,
                    FullNames=$"{customerCommand.customerDetails.FirstName} {customerCommand.customerDetails.LastName}"
                });

                return newCustomer.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> GenerateAccountNo(string? Cif)
        {
            return $"007{GenerateUniqueDigits(9)}";
        }
        static string GenerateUniqueDigits(int count)
        {
            Random random = new Random();
            var digits = Enumerable.Range(0, 10).OrderBy(x => random.Next()).Take(count).ToArray();

            return string.Join("", digits);
        }
    }
}
