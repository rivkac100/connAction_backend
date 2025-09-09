﻿//בס"ד

using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IDalOrder : ICrud<Order>
    {
        //  public List<Order> GetByCustomerId(int customerId);
        public Task<List<Order>?> GetByDate(DateOnly date);
    }
}
