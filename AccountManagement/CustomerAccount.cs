using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using AccountManagement.Factory;
using DataRepository.Infastructure;
using DataRepository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Factory;
using AccountManagement.Models;
using AccountManagement.Service;

namespace AccountManagement
{
    public class CustomerAccount
    {
        private iCustomerFactory _iCustomerFactory;
        private iAccountFactory _iAccountFactory;
        private IAccountService _iAccountService;
        public CustomerAccount(iAccountFactory accountFactory, iCustomerFactory customerFactory, IAccountService accountService)
        {
            _iCustomerFactory = customerFactory;
            _iAccountFactory = accountFactory;
            _iAccountService = accountService;
        }


        [FunctionName("Account")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            AccountService accountService = new AccountService(_iAccountFactory, _iCustomerFactory);
            switch (req.Method) 
            { 
                case "GET":
                    var custId = req.Query["CustomerId"];
                    if (!string.IsNullOrEmpty(custId)) {
                        var account = accountService.GetCustomerById(Convert.ToInt32(custId));
                        return (ActionResult)new OkObjectResult(account);
                    }
                    break;
                case "POST":
                
                    var Account = new Account();
                    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                    if (requestBody != null && requestBody != String.Empty)
                    {
                        Account = JsonConvert.DeserializeObject<Account>(requestBody);
                        accountService.UpdateCustomer(Account);
                        return (ActionResult)new OkObjectResult(Account);
                    }
                    break;
            }
            return (ActionResult)new OkObjectResult("");

        }
    }
}
