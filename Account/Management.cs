using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AccountManagement.Models;
using DataRepository.Infastructure;
using DataRepository.Models;

namespace AccountManagement
{
    public static class Management
    {
        [FunctionName("Management")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            var customer = new Customer();
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            if (requestBody != null)
            {
                customer = JsonConvert.DeserializeObject<Customer>(requestBody);
            }

            AccountRepository rep = new AccountRepository(new AccountDbContext());
            rep.UpdateCustomer(customer);

            return (ActionResult)new OkObjectResult("");
            //var Account

            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            //return name != null
            //    ? (ActionResult)new OkObjectResult($"Hello, {name}")
            //    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
