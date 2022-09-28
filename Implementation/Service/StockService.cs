using Scanpay.Dtos;
using Scanpay.Entity;
using Scanpay.Interface.Repository;
using Scanpay.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Implementation.Service
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRespository;

        public StockService(IStockRepository stockRespository)
        {
            _stockRespository = stockRespository;
        }

        public async Task<StockDto> AddStockAsync(CreateStockRequestModel model)
        {
            var stock = new Stock 
            { 
                StockName = model.StockName
            };
            var newStock = await _stockRespository.CreateStockAsync(stock);
            return new StockDto 
            { 
                Id = newStock.Id,
                StockName = newStock.StockName
            };


        }

        public async Task<bool> DeleteStockAsync(int id)
        {
            var stock = await _stockRespository.GetStockAsync(id);

            stock.IsDeleted = true;

            await _stockRespository.UpdateStockAsync(stock);

            //_stockRespository.DeleteStock(stock);

            return true;

        }

        public async Task<IList<StockDto>> GetallStocksAsync()
        {
            var stock = await _stockRespository.GetAllStocksAsync();
             var stocks = stock.Select(s => new StockDto 
            { 
                Id = s.Id,
                StockName = s.StockName
               
            }).ToList();
            return stocks;
        }

        public async Task<StockDto> GetStockAsync(int id)
        {
            var stock = await _stockRespository.GetStockAsync(id);
            return new StockDto
            { 
                Id = stock.Id,
                StockName = stock.StockName
            };
        }

        public async Task<bool> UpdateStockAsync(int id, UpdateStockRquestModel model)
        {
            var stock = await _stockRespository.GetStockAsync(id);

            stock.StockName = model.StockName;

            await _stockRespository.UpdateStockAsync(stock);

            return true;
        }
        
    }
}
