using AccountManagement.Factory;
using AccountManagement.Models;
using DataRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    internal class AccountFactory : iAccountFactory
    {
       
        public Account Convert(Customer record)
        {
            var account = new Account(){
                FirstName = record.FirstName,
                LastName = record.LastName,
                BirthMonth = record.BirthMonth,
                CustomerId = record.CustomerId
            };
            return account; 
    
        }
    }
}
