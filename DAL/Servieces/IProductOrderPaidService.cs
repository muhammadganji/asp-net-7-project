using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public interface IProductOrderPaidService
    {
        void Add(ProductOrderPaid productOrderPaid);
        void AddRange(List<ProductOrderPaid> productsOrderPaid);
        void Remove(int Id);
        void Update(ProductOrderPaid order);
        ProductOrderPaid GetById(int Id);
        IEnumerable<ProductOrderPaid> GetByOrderPaidId(int orderPaidId);
        IEnumerable<ProductOrderPaid> GetAll();
    }
}
