using AccountManagement.Models;
using DataRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManagement.Factory
{
    interface iAccountFactory
    {
       Account Convert(Customer record);
    }
}
