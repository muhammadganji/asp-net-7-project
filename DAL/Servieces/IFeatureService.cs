using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public interface IFeatureService
    {
        public void Add(Feature feature);
        void AddAsync(Feature feature);
        void Remove(int Id);
        Task<IEnumerable<Feature>> GetByProductIdAsync(int productId);
        List<Feature> GetByProductId(int productId);
    }
}
