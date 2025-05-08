using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<Product> AddProductAsync(Product entity);
        Task<Product> UpdateProductAsync(Guid productId, Product entity);
        Task<bool> DeleteProductAsync(Guid productId);
    }
}
