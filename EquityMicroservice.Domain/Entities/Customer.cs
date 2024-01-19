using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityMicroservice.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string AltPhoneNumber { get; set; }
        public string Email { get; set; }
        public string IdNumber { get; set; }
        public string KraPin { get; set; }
        public string Cif { get; set; }
        public Guid CustomerStatus { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Customer() {
           
        }
        public Customer(string firstName,string lastName,string phoneNumber,
            string altPhoneNumber,string email,string idNumber,string kraPin,
            Guid customerStatus,DateTime dateofBirth)
        {
            Id = Guid.NewGuid();
            Cif = "";
            FirstName =firstName;
            LastName=lastName;  
            PhoneNumber=phoneNumber;
            AltPhoneNumber=altPhoneNumber;
            Email=email;
            IdNumber=idNumber;
            KraPin=kraPin;
            CustomerStatus = customerStatus;
            DateOfBirth=dateofBirth;
        }
        public static Customer AddNewCustomer(string firstName, string lastName, string phoneNumber,
            string altPhoneNumber, string email, string idNumber, string kraPin,
            Guid status, DateTime dateofBirth)
        {
            return new Customer(firstName, lastName, phoneNumber,
             altPhoneNumber, email, idNumber, kraPin,
             status, dateofBirth);
        }
    }
}
