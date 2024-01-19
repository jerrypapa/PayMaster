using EquityMicroservice.Domain.Entities;
using EquityMicroservice.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityMicroservice.Infrastructure.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly EquityContext _equityContext;
        public CustomerRepository(EquityContext equityContext)
        {
            _equityContext = equityContext??throw new ArgumentNullException(nameof(equityContext));
        }
        public async Task<bool> SaveCustomerAsync(Customer customer)
        {
            try
            {
                await _equityContext.Customers.AddAsync(customer);
                await _equityContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
