using Microsoft.EntityFrameworkCore;
using Scanpay.Contex;
using Scanpay.Entity;
using Scanpay.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Implementation.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ScanPayContext _context;

        public StockRepository(ScanPayContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateStockAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public void DeleteStock(Stock stock)
        {
            _context.Stocks.Remove(stock);
            _context.SaveChanges();
        }

        public async Task<IList<Stock>> GetAllStocksAsync()
        {
            var stock = await _context.Stocks.Where(s=> s.IsDeleted == false).ToListAsync();
            return stock;
        }

        public async Task<IList<Stock>> GetSelectedStocksAsync(IList<int> ids)
        {
            var stock = await _context.Stocks.Include(s => s.ItemStocks).ThenInclude(s => s.Item)
               
            .Where(s => ids.Contains(s.Id) && s.IsDeleted == false).ToListAsync();

            return stock;
        }

        public async Task<Stock> GetStockAsync(int id)
        {
            var stock = await _context.Stocks.Include(s => s.ItemStocks).ThenInclude(s => s.Item)

            .Where(s => s.Id == id && s.IsDeleted == false).SingleOrDefaultAsync();

            return stock;
        }

        public async Task<Stock> UpdateStockAsync(Stock stock)
        {
            _context.Stocks.Update(stock);

            await _context.SaveChangesAsync();

            return stock;
        }
    }
}
