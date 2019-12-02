using AccountManagement.Models;

namespace AccountManagement.Service
{
    public interface IAccountService
    {
        Account GetCustomerById (int id);
        Account UpdateCustomer(Account acc);
    }
}