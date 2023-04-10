using Entities;

namespace DAL.Servieces
{
    public interface IArchiveService
    {
        void Add(Archive archive);
        void Remove(int id);

        void Update(Archive archive);
        Archive GetById(int id);
        IEnumerable<Archive> GetAll();
        IEnumerable<Archive> GetByProductId(int productId);

    }
}
