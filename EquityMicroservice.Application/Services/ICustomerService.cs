using EquityMicroservice.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityMicroservice.Application.Services
{
    public interface ICustomerService
    {
        Task<Guid> CreateCustomerAsync(CreateCustomerCommand customerCommand);
        Task<string> GenerateAccountNo(string? Cif);
    }
}
