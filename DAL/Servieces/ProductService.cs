using Dapper;
using Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using System.Data.SqlClient;

namespace DAL.Servieces
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext _context;
        public readonly IConfiguration _configuration;
        public readonly string connectionString;
        public ProductService(DatabaseContext Context, IConfiguration configuration)
        {
            _context = Context;
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefualtConnection");


        }
        public void Add(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            products = _context.products.ToList();
            return products;
        }

        public IEnumerable<Product> GetByCategory(int CategoryId)
        {
            List<Product> products = new List<Product>();
            products = _context.products.Where(p => p.CategoryId == CategoryId).ToList();
            return products;
        }

        public Product GetById(int id)
        {
            Product products = _context.products.Where(p => p.Id == id).FirstOrDefault();
            return products;
        }

        public IEnumerable<Product> GetByName(string name)
        {
            List<Product> products = new List<Product>();
            products = _context.products.Where(p => p.Name.Contains(name)).ToList();
            return products;
        }

        public IEnumerable<Product> GetLastAdded()
        {
            string sql = "SELECT Top(6) * FROM products ";
            using (var connection = new SqlConnection(connectionString))
            {
                List<Product> products = connection.Query<Product>(sql).ToList();
                return products;
            }
        }

        public IEnumerable<Product> GetSliderProducts()
        {
            string sql = "Select Top(2) p.* From products p  Left Join  viewersStatistics v on p.Id = v.ProductId order by v.NumberOfVisits";
            using (var connection = new SqlConnection(connectionString))
            {
                List<Product> products = connection.Query<Product>(sql).ToList();
                return products;
            }
        }

        public bool Remove(int id)
        {
            Product p = _context.products.Where(p => p.Id == id).FirstOrDefault();
            if (p != null)
            {
                _context.products.Remove(p);
                _context.SaveChanges();
                return true;
            }
            else { return false; }

        }

        public void Update(Product product)
        {
            _context.products.Update(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetSameProducts(int categoryId)
        {
            string sql = "Select Top(4) p.* From products p Where p.CategoryId = " + categoryId;
            using (var connection = new SqlConnection(connectionString))
            {
                List<Product> products = connection.Query<Product>(sql).ToList();
                return products;
            }
        }

        public IEnumerable<Product> GetByListProductId(string Ids)
        {
            string sql = "Select * from products where Id in (" + Ids + ")";
            using (var connection = new SqlConnection(connectionString))
            {
                List<Product> products = connection.Query<Product>(sql).ToList();
                return products;
            }
        }

        public void UpdateRange(List<Product> products)
        {
            _context.products.UpdateRange(products);
            _context.SaveChanges();
        }
    }
}
