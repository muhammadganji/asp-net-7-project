using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public interface IViewersStatisticService
    {
        void Add(ViewersStatistics statistics);
        void Update(ViewersStatistics statistics);
        void Remove(int Id);
        ViewersStatistics GetById(int Id);
        ViewersStatistics GetByProductId(int ProductId);
        void Increase(int ProductId);
    }
}
