using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public interface IOrderPaidService
    {
        void Add(OrderPaid orderPaid);
        void Update(OrderPaid orderPaid);
        void Remove(int Id);
        OrderPaid GetById(int Id);
        IEnumerable<OrderPaid> GetAll();
        IEnumerable<OrderPaid> GetByUserName(string userName);
    }
}
