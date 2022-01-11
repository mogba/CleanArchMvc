using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            return await _context.Product.Include(p => p.Category).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> GetProductByIdAsync(int? id)
        {
            return await _context.Product.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
