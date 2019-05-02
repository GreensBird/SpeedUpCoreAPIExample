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
    public class PricesRepository : IPricesRepository
    {
        private readonly MainContext _context;

        public PricesRepository(MainContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Price>> GetPricesAsync(int productId)
        {
            return await _context.Prices.Where(p => p.ProductId == productId).ToListAsync();
        }
    }
}
