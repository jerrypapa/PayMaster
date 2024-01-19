using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityMicroservice.Domain.Entities
{
    public class TransactionStatus
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Codes will contain actual transaction status
        /// </summary>
        public string Code { get; set; }
        public string Description { get; set; }
        public TransactionStatus() { }
        public TransactionStatus(string code, string description)
        {
            Id = Guid.NewGuid();
            Code = code;
            Description = description;
        }
        public static TransactionStatus AddTransactionStatus(string code, string description)
        {
            return new TransactionStatus(code, description);

        }
    }
}
