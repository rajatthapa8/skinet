using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return  await _context.Products.FindAsync(id);
            
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }
    }
}