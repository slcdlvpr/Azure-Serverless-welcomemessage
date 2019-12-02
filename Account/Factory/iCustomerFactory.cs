using System;
using System.Collections.Generic;
using System.Text;
using AccountManagement.Models;
using DataRepository.Models;

namespace Factory
{
    interface iCustomerFactory
    {
        Customer Convert(Account record);
    }
}
