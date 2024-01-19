using EquityMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityMicroservice.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<bool> SaveCustomerAsync(Customer customer);
    }

    //public interface IMediator
    //{
    //    Task<bool> Send();
    //}
}
