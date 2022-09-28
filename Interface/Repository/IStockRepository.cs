using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Repository
{
    public interface IStockRepository
    {
        Task<Stock> CreateStockAsync(Stock stock);

        Task<Stock> UpdateStockAsync(Stock stock);

        Task<Stock> GetStockAsync(int id);

        Task<IList<Stock>> GetAllStocksAsync();

        Task<IList<Stock>> GetSelectedStocksAsync(IList<int> ids);

        //void DeleteStock(Stock stock);
           
    }
}
