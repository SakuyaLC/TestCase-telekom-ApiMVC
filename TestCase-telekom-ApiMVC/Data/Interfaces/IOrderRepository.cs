﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCase_telekom_ApiMVC.Model;

namespace TestCase_telekom_ApiMVC.Data.Interfaces
{
    public interface IOrderRepository
    {
        ICollection<Order> GetOrders();
        ICollection<RelationOrder> GetRelationOrders();
    }
}
