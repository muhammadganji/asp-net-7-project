using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public class OrderPaidService : IOrderPaidService
    {
        private readonly DatabaseContext _context;
        public OrderPaidService(DatabaseContext context)
        {

            _context = context;

        }
        public void Add(OrderPaid orderPaid)
        {
            _context.orderPaids.Add(orderPaid);
            _context.SaveChanges();
        }

        public IEnumerable<OrderPaid> GetAll()
        {
            List<OrderPaid> result = _context.orderPaids.ToList();
            return result;
        }

        public OrderPaid GetById(int Id)
        {
            OrderPaid result = _context.orderPaids.Where(op => op.Id == Id).FirstOrDefault();
            return result;
        }

        public IEnumerable<OrderPaid> GetByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderPaid orderPaid)
        {
            throw new NotImplementedException();
        }
    }
}
