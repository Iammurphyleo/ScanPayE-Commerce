using Scanpay.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Service
{
    public interface IItemService
    {
       Task<ItemDto> AddItemAsync(CreateItemRequestModel model);

        Task<bool> UpdateItemAsync(int id, UpdateItemRequestModel model);

        Task<ItemDto> GetItemByQRCodeAsync(string qRCode);

        Task<ItemDto> GetItemNameAsync(string name);

        Task<ItemDto> GetItemAsync(int id);

        Task<IList<ItemDto>>  GetAllItemsAsync();

        IList<ItemDto> SearchItems(string searchText);

        Task<bool> DeleteItemAsync(int id);

        
    }

    

}
