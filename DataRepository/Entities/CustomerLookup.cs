using System;
using System.Collections.Generic;

namespace DataRepository.Models
{
    public partial class CustomerLookup
    {
        public int CustomerId { get; set; }
        public int OAuthId { get; set; }
        public int UserId { get; set; }
    }
}
