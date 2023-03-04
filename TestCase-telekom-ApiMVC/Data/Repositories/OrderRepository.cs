using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCase_telekom_ApiMVC.Data.Interfaces;
using TestCase_telekom_ApiMVC.Model;

namespace TestCase_telekom_ApiMVC.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Order> GetOrders()
        {
            return _context.Orders.OrderBy(o => o.order_id).ToList();
        }

        public ICollection<RelationOrder> GetRelationOrders()
        {
            return _context.relation_table_order.OrderBy(ro => ro.order_id).ToList();
        }


    }
}
