using System;
using System.Collections.Generic;
using System.Text;
using AccountManagement.Models;
using DataRepository.Models;


namespace Factory
{
    internal  class CustomerFactory : iCustomerFactory
    {
        public Customer Convert(Account record)
        {
            var customer = new Customer()
            {
                FirstName = record.FirstName,
                LastName = record.LastName,
                BirthMonth = record.BirthMonth,
                CustomerId = record.CustomerId
            };
            return customer;
        }
    }
}
