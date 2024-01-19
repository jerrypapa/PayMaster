using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityMicroservice.Domain.Entities
{
    public class EquityContext:DbContext
    {
		public DbSet<AccountNumbers> BankAccounts { get; set; }
		public DbSet<Address> Address { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<CustomerStatus> CustomerStatus { get; set; }
		public DbSet<FundsTransfer> FundsTransfer { get; set; }
		public DbSet<TransactionStatus> TransactionStatus { get; set; }
        public EquityContext(DbContextOptions<EquityContext> opt):base(opt) 
        {
			try
			{
				var dbCreator = Database.GetService<IDatabaseCreator>() 
					as RelationalDatabaseCreator;
				if(dbCreator !=null)
				{
					if (!dbCreator.CanConnect()) dbCreator.Create();
					if (!dbCreator.HasTables()) dbCreator.CreateTables();
				}
			}
			catch (Exception)
			{

				throw;
			}
        }  
    }
}
