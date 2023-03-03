using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCase_telekom_ApiMVC.Data.Interfaces;
using TestCase_telekom_ApiMVC.Model;

namespace TestCase_telekom_ApiMVC.Data
{
    public class Repository : IRepository
    {

        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context; 
        }

        public ICollection<User> GetUsers()
        {
             return _context.Users.OrderBy(u => u.user_id).ToList();
        }

        public ICollection<Item> GetItems()
        {
            return _context.Items.OrderBy(i => i.item_id).ToList();
        }

        public ICollection<Order> GetOrders()
        {
            return _context.Orders.OrderBy(o => o.order_id).ToList();
        }

        public ICollection<RelationOrder> GetRelationOrders()
        {
            return _context.relation_table_order.OrderBy(ro => ro.order_id).ToList();
        }

        public bool Save()  
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(u => u.user_id == id);
        }

        public bool CreateUser(User user)
        {

            _context.Users.Add(user);

            return Save();
        }

    }
}

