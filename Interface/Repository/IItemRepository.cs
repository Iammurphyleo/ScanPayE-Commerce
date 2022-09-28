using Scanpay.Dtos;
using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Repository
{
    public interface IItemRepository
    {
        Task<Item> CreateItemAsync(Item item);

        Task<Item> UpdateItemAsync(Item item);

        Task<Item> GetItemAsync(int id);

        Task<Item> GetItemNameAsync(string name);

        Task<Item> GetItemByQRCodeAsync(string qRCode);

        //void DeleteItem(Item item);

        Task<IList<Item>> GetAllItemsAsync();

        Task<IList<Item>> GetSelectedItemsAsync(IList<int> ids);

        Task<IList<Item>> GetSelectedItemsInCartAsync(Dictionary<int, int> items);

        IList<ItemDto> SearchItems(string searchText);


        //Task GetSelectedItemsAsync(IEnumerable<int> itemId);

    }


    

    

    

}
