
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;


namespace Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext dbcontext) : IProductRepository
    {
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await dbcontext.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await dbcontext.Products.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> AddProductAsync(Product entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            dbcontext.Products.Add(entity);

            await dbcontext.SaveChangesAsync();

            return entity;
        }

        public async Task<Product> UpdateProductAsync(Guid productId, Product entity)
        {
            var product = await dbcontext.Products.SingleOrDefaultAsync(x => x.Id == productId);

            if (product is null)
                return entity;

            product.Name = entity.Name;
            product.Slug = entity.Slug;
            product.ShortDescription = entity.ShortDescription;
            product.Description = entity.Description;
            product.Price = entity.Price;
            product.DiscountPrice = entity.DiscountPrice;
            product.Currency = entity.Currency;
            product.SKU = entity.SKU;
            product.Barcode = entity.Barcode;
            product.StockQuantity = entity.StockQuantity;
            product.IsInStock = entity.IsInStock;
            product.IsActive = entity.IsActive;
            product.IsFeatured = entity.IsFeatured;
            product.UpdatedAt = DateTime.UtcNow;

            await dbcontext.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            var product = await dbcontext.Products.SingleOrDefaultAsync(x => x.Id == productId);

            if (product is null)
                return false;

            dbcontext.Products.Remove(product);
            var changes = await dbcontext.SaveChangesAsync();

            return changes > 0;
        }
    }
}
