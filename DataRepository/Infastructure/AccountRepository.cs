using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace DataRepository.Infastructure
{
    public class AccountRepository
    {
        private AccountDbContext _context;
        public AccountRepository(AccountDbContext context)
        {
            _context = context;
        }

        public Customer GetCustomer(int id)
        {
            var lookup =  _context.CustomerLookup.FirstOrDefault(x => x.CustomerId == id);
            var customer = _context.Customer.FirstOrDefault(c => c.CustomerId == lookup.CustomerId);
            return customer;
        }

        public Customer UpdateCustomer(Customer cust)
        {
            _context.Customer.Update(cust);
            _context.SaveChanges();
            return cust;
        }
    }
}
