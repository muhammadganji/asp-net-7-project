using Entities;

namespace DAL.Servieces
{
    public interface ICategoryService
    {
        void Add(Category category);
        void Update(Category category);
        void Remove(int id);
        Category GetById(int id);
        IEnumerable<Category> GetAll();

        public List<Category> GetProductCount();

    }
}
