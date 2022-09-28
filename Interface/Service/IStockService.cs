using Scanpay.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Service
{
    public interface IStockService
    {
        Task<StockDto> AddStockAsync(CreateStockRequestModel model);

        Task<bool> UpdateStockAsync(int id, UpdateStockRquestModel model);

        Task<StockDto> GetStockAsync(int id);

        Task<IList<StockDto>> GetallStocksAsync();

       Task<bool>  DeleteStockAsync(int id);
    }
}
