using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public interface IProductService
    {
        void Add(Product product);
        void Update(Product product);
        void UpdateRange(List<Product> products);
        bool Remove(int id);
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        IEnumerable<Product> GetByCategory(int categoryId);
        IEnumerable<Product> GetByName(string name);

        IEnumerable<Product> GetLastAdded();

        IEnumerable<Product> GetSliderProducts();

        IEnumerable<Product> GetSameProducts(int categoryId);

        /// <summary>
        /// get by list
        /// </summary>
        /// <param name="Ids">1,2,5,6,8</param>
        /// <returns></returns>
        IEnumerable<Product> GetByListProductId(string Ids);

    }
}
