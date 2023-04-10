using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public class ProductOrderService : IProductOrderService
    {
        private readonly DatabaseContext _context;
        public ProductOrderService(DatabaseContext db)
        {
            _context = db;
        }
        public void Add(ProductOrder productOrder)
        {
            _context.productOrders.Add(productOrder);
            _context.SaveChanges();
        }

        public IEnumerable<ProductOrder> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProductOrder GetById(int Id)
        {
            ProductOrder productOrder = _context.productOrders.Where(po => po.Id == Id).FirstOrDefault();
            return productOrder;
        }

        public IEnumerable<ProductOrder> GetByOrderId(int orderId)
        {
            List<ProductOrder> productOrders = _context.productOrders.Where(po => po.OrderId == orderId).ToList();
            return productOrders;
        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductOrder productOrder)
        {
            throw new NotImplementedException();
        }

    }
}
