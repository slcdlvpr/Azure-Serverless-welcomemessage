using AccountManagement.Models;
using DataRepository.Infastructure;
using Factory;
using System;
using System.Collections.Generic;
using System.Text;
using AccountManagement.Factory;

namespace AccountManagement.Service
{
    public class AccountService : IAccountService
    {
        private iCustomerFactory _iCustomerFactory;
        private iAccountFactory _iAccountFactory;
        public AccountService(iAccountFactory accountFactory, iCustomerFactory customerFactory)
        {
            _iCustomerFactory = customerFactory;
            _iAccountFactory = accountFactory;
        }

        public Account GetCustomerById (int id)
        {
            AccountRepository rep = new AccountRepository(new AccountDbContext());
            var customer = rep.GetCustomer(Convert.ToInt32(id));
            return _iAccountFactory.Convert(customer);
        }

        public Account UpdateCustomer(Account acc)
        {
            AccountRepository rep = new AccountRepository(new AccountDbContext());
            rep.UpdateCustomer(_iCustomerFactory.Convert(acc));
            return acc;
        }
    }
}
