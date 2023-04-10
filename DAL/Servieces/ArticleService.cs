using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public class ArticleService : IArticleService
    {
        private readonly DatabaseContext _context;
        public ArticleService(DatabaseContext db)
        {
            _context = db;
        }
        public void Add(Article article)
        {
            _context.articles.Add(article);
            _context.SaveChanges();
        }

        public IEnumerable<Article> GetAll()
        {
            List<Article> result = _context.articles.ToList();
            return result;
        }

        public Article GetById(int Id)
        {
            Article result = _context.articles.Where(a => a.Id == Id).FirstOrDefault();
            return result;
        }

        public void Remove(int Id)
        {
            Article result = _context.articles.Where(a => a.Id == Id).FirstOrDefault();
            if (result != null)
            {
                _context.articles.Remove(result);
                _context.SaveChanges();
            }
        }

        public void Update(Article article)
        {
            _context.articles.Update(article);
            _context.SaveChanges();
        }
    }
}
