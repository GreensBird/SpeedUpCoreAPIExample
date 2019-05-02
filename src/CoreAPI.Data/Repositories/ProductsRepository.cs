using CoreAPI.Data.Contexts;
using CoreAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly MainContext _context;

        public ProductsRepository(MainContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            return await _context.Products.AsNoTracking().Where(p => p.ProductId == productId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> FindProductsAsync(string sku)
        {
            return await _context.Products.AsNoTracking().Where(p => p.Sku.Contains(sku)).ToListAsync();
        }

        public async Task<Product> DeleteProductAsync(int productId)
        {
            Product product = await GetProductAsync(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }

            return product;
        }
    }
}
