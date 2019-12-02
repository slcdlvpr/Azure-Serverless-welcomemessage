using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManagement.Models
{
    public class Account
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthMonth { get; set; }
    }
}
