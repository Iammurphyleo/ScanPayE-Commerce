using Microsoft.EntityFrameworkCore;
using Scanpay.Contex;
using Scanpay.Dtos;
using Scanpay.Entity;
using Scanpay.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Implementation.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly ScanPayContext _context;

        public ItemRepository(ScanPayContext context)
        {
            _context = context;
        }

        public async Task<Item> CreateItemAsync(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;

        }

        /*public void DeleteItem(Item item)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();

        }*/

        public async Task<IList<Item>> GetAllItemsAsync()
        {
            var item = await _context.Items.Where(i => i.IsDeleted == false).ToListAsync();

            return item;
        }

        public async Task<Item> GetItemAsync(int id)
        {
            var item = await _context.Items.Include(i => i.ItemBrands).ThenInclude(i => i.Brand)

            .Include(i => i.ItemCategories).ThenInclude(i=>i.Category).Include(i=>i.ItemStocks)

              .ThenInclude(i=>i.Stock).Where(i => i.Id == id && i.IsDeleted == false).SingleOrDefaultAsync();

            return item;
        }

        public async Task<Item> GetItemByQRCodeAsync(string qRCode)
        {
            var item = await _context.Items.Include(i => i.ItemBrands).ThenInclude(i => i.Brand)

            .Include(i => i.ItemCategories).ThenInclude(i => i.Category).Include(i => i.ItemStocks)

            .ThenInclude(i => i.Stock).Where(i => i.QrCode == qRCode && i.IsDeleted == false).SingleOrDefaultAsync();

            return item;
        }

        public async Task<Item> GetItemNameAsync(string itemName)
        {
            var item = await _context.Items.Include(i => i.ItemBrands).ThenInclude(i => i.Brand)

            .Include(i => i.ItemCategories).ThenInclude(i => i.Category).Include(i => i.ItemStocks)

            .ThenInclude(i => i.Stock).Where(i => i.ItemtName == itemName && i.IsDeleted == false).SingleOrDefaultAsync();

            return item;
        }

        public async Task<IList<Item>> GetSelectedItemsAsync(IList<int> ids)
        {
            var item = await _context.Items.Include(i=>i.ItemOrders).ThenInclude(i=>i.Order)

            .Where(i => ids.Contains(i.Id) && i.IsDeleted == false).ToListAsync();

            return item;
        }

        public async Task<IList<Item>> GetSelectedItemsInCartAsync(Dictionary<int, int> items)
        {
           var item = await _context.Items.Include(i => i.ItemOrders).ThenInclude(i => i.Order)

           .Where(i => items.Keys.Contains(i.Id) && i.IsDeleted == false).ToListAsync();

            return item;
        }

        public async Task<Item> UpdateItemAsync(Item item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }


        public  IList<ItemDto> SearchItems(string searchText)
        {
            var item = _context.Items.Where(item => EF.Functions.Like(item.ItemtName, $"%{searchText}%") 
            
            && item.IsDeleted == false)

                .Select(p => new ItemDto
                {
                    Id = p.Id,
                    ItemtName = p.ItemtName,
                    ItemWeight = p.ItemWeight,
                    Price = p.Price,
                    Description = p.Description,

                }).ToList();

                return item;
        }

    }
}
