using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public class OrderService : IOrderService
    {

        private readonly DatabaseContext _context;

        public OrderService(DatabaseContext db)
        {
            _context = db;
        }
        public void Add(Order order)
        {
            _context.orders.Add(order);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(int Id)
        {
            Order order = _context.orders.Where(o => o.Id == Id).FirstOrDefault();
            return order;
        }

        public IEnumerable<Order> GetByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Order order)
        {
            _context.orders.Update(order);
            _context.SaveChanges();
        }
    }
}
