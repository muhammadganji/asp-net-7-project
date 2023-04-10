using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public class CategoryService : ICategoryService
    {
        private readonly DatabaseContext _Context;
        public CategoryService(DatabaseContext context)
        {
            _Context = context;
            //_Context.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
        }
        public void Add(Category category)
        {
            _Context.categories.Add(category);
            _Context.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            List<Category> categories = new List<Category>();
            categories = _Context.categories.ToList();
            return categories;
        }

        public Category GetById(int id)
        {
            Category category = _Context.categories.AsNoTracking().Where(p => p.Id == id).FirstOrDefault();
            return category;
        }

        public void Remove(int id)
        {
            Category c = _Context.categories.Where(p => p.Id == id).FirstOrDefault();
            if (c != null)
            {
                _Context.categories.Remove(c);
                _Context.SaveChanges();
            }
        }

        public List<Category> GetProductCount()
        {
            string sql = "select ct.*, t1.ProductCount from categories ct left join (select c.Id,COUNT(p.Id) AS 'ProductCount' From categories c left join products p On c.Id = p.CategoryId group by c.Id) as t1 on t1.Id = ct.Id ";
            var result = _Context.categories.FromSqlRaw(sql).TagWith("custom Query").ToList();
            return result;
        }

        public void Update(Category category)
        {
            _Context.categories.Update(category);
            _Context.SaveChanges();
        }
    }
}
