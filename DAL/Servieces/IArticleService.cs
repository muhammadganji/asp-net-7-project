using Entities;

namespace DAL.Servieces
{
    public interface IArticleService
    {
        void Add(Article article);
        void Update(Article article);
        void Remove(int Id);
        IEnumerable<Article> GetAll();
        Article GetById(int Id);

    }
}
