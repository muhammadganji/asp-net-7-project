using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public interface IOrderService
    {
        void Add(Order order);
        void Remove(int Id);
        void Update(Order order);
        Order GetById(int Id);
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetByUserName(string userName);
    }
}
