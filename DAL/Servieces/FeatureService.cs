using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public class FeatureService : IFeatureService
    {
        private readonly DatabaseContext _context;
        public FeatureService(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(Feature feature)
        {
            _context.features.Add(feature);
            _context.SaveChanges();
        }

        public async void AddAsync(Feature feature)
        {
            await _context.features.AddAsync(feature);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Feature> GetByProductId(int productId)
        {
            List<Feature> result = _context.features.Where(f => f.ProductId == productId).ToList();
            return result;
        }

        public void Remove(int Id)
        {
            Feature feature = _context.features.Where(f => f.Id == Id).FirstOrDefault();
            if (feature != null)
            {
                _context.features.Remove(feature);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Feature>> GetByProductIdAsync(int productId)
        {
            List<Feature> result = await _context.features.Where(f => f.ProductId == productId).ToListAsync();
            return result;
        }

        List<Feature> IFeatureService.GetByProductId(int productId)
        {
            List<Feature> result = _context.features.Where(f => f.ProductId == productId).ToList();
            return result;
        }
    }
}
