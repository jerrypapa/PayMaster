using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EquityMicroservice.Domain.Entities
{
    public class FundsTransfer
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Credit/Debit Acccounts
        /// </summary>
        public string CreditAccount { get; set; }
        public string DebitAccount { get; set; }
        public decimal Amount { get; set; }
        public string SenderBic { get; set; }
        public string Description { get; set; }
        public string RecipientBic { get; set; }
        public Guid TransactionStatus { get; set; }
        public DateTime TransactionDate { get; set; }
        public FundsTransfer() { }
        public FundsTransfer(string creditAccount, string debitAccount, decimal amount, string senderBic, string description, string recipientBic, Guid transactionStatus, DateTime transactionDate)
        {
            Id = Guid.NewGuid();
            CreditAccount = creditAccount;
            DebitAccount = debitAccount;
            Amount = amount;
            SenderBic = senderBic;
            Description = description;
            RecipientBic = recipientBic;
            TransactionStatus = transactionStatus;
            TransactionDate = transactionDate;
        }   
        public static FundsTransfer AddFundsTransfer(string creditAccount, string debitAccount, decimal amount, string senderBic, string description, string recipientBic, Guid transactionStatus, DateTime transactionDate)
        {
            return new FundsTransfer(creditAccount,debitAccount,amount,senderBic,description,recipientBic,transactionStatus,transactionDate);
        }
    }
}
