using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityMicroservice.Domain.Entities
{
    public class AccountNumbers
    {
        public Guid Id { get; set; }
        public string Cif { get; set; }
        public string AccountNumber { get; set; }
        public bool IsPersonal { get; set; }
        public AccountNumbers(string cif,string accountNumber,bool isPersonal)
        {
            Id = Guid.NewGuid();
            Cif = cif;
            AccountNumber = accountNumber;
            IsPersonal= isPersonal;
        }
        public AccountNumbers AddNewAccount(string cif, string accountNumber, bool isPersonal)
        { 
            return new AccountNumbers(cif,accountNumber,isPersonal);
        }

    }
   
}
