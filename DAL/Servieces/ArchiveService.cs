using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public class ArchiveService : IArchiveService
    {
        private readonly DatabaseContext _context;
        public ArchiveService(DatabaseContext context)
        {
            _context = context;
             
        }
        public void Add(Archive archive)
        {
            _context.archive.Add(archive);
            _context.SaveChanges();
        }

        public IEnumerable<Archive> GetAll()
        {
            throw new NotImplementedException();
        }

        public Archive GetById(int id)
        {
            Archive result = _context.archive.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
            return result;
        }

        public IEnumerable<Archive> GetByProductId(int productId)
        {
            List<Archive> result = _context.archive.Where(a => a.ProductId == productId).ToList();
            return result;
        }

        public void Remove(int id)
        {
            Archive archive = _context.archive.Where(a => a.Id == id).FirstOrDefault();
            if(archive != null)
            {
                _context.archive.Remove(archive);
                _context.SaveChanges();
            }
        }

        public void Update(Archive archive)
        {
            throw new NotImplementedException();
        }
    }
}
