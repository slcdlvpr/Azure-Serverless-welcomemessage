using System;
using System.Collections.Generic;

namespace DataRepository.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthMonth { get; set; }
    }
}
