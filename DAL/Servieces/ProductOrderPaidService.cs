using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public class ProductOrderPaidService: IProductOrderPaidService
    {
        private readonly DatabaseContext _context;
        public ProductOrderPaidService(DatabaseContext db)
        {
            _context = db;
        }

        public void Add(ProductOrderPaid productOrderPaid)
        {
            _context.productOrderPaid.Add(productOrderPaid);
            _context.SaveChanges();
        }

        public void AddRange(List<ProductOrderPaid> productsOrderPaid)
        {
            _context.productOrderPaid.AddRange(productsOrderPaid);
            _context.SaveChanges();
        }

        public IEnumerable<ProductOrderPaid> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProductOrderPaid GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductOrderPaid> GetByOrderPaidId(int orderPaidId)
        {
            List<ProductOrderPaid> result = _context.productOrderPaid.Where(pop => pop.OrderPaidId == orderPaidId).ToList();
            
            return result;
        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductOrderPaid order)
        {
            throw new NotImplementedException();
        }
        
    }
}
