using Entities;

namespace DAL.Servieces
{
    public interface IProductOrderService
    {
        void Add(ProductOrder productOrder);
        void Update(ProductOrder productOrder);
        void Remove(int Id);
        ProductOrder GetById(int Id);
        IEnumerable<ProductOrder> GetAll();
        IEnumerable<ProductOrder> GetByOrderId(int orderId);
    }
}
