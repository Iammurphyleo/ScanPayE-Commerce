using Microsoft.AspNetCore.Hosting;
using Scanpay.Dtos;
using Scanpay.Entity;
using Scanpay.Interface;
using Scanpay.Interface.Repository;
using Scanpay.Interface.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using ZXing;
using ZXing.QrCode;

namespace Scanpay.Implementation.Service
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IBrandRepository _brandRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IStockRepository _stockRepository;
        

        public ItemService(IItemRepository itemRepository, IBrandRepository brandRepository, IWebHostEnvironment hostEnvironment, ICategoryRepository  categoryRepository, IStockRepository stockRepository)
        {
            _itemRepository = itemRepository;
            _hostEnvironment = hostEnvironment;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _stockRepository = stockRepository;

        }
        
        public async Task<ItemDto> AddItemAsync(CreateItemRequestModel model)
        {
            var itemNameExist = await _itemRepository.GetItemNameAsync(model.ItemtName);

            if (itemNameExist != null)
            {
                throw new Exception($"product with {model.ItemtName} already exist");
            }

            var newQrCode = $"IT{model.ItemtName}{model.Price}{model.ItemWeight}{Guid.NewGuid().ToString().Substring(0, 3)}";

            var qRCodeExist = await _itemRepository.GetItemByQRCodeAsync(newQrCode);

            if (qRCodeExist != null)
            {
                throw new Exception($"A product with {newQrCode} already exist");
            }
          
            var item = new Item()
            {
                ItemtName = model.ItemtName,
                Description = model.Description,
                QrCode = newQrCode,
                //ItemImage = model.ItemImage,
                Price = model.Price,
                ManufacturingDate = model.ManufacturingDate,
                ExpiryDate = model.ExpiryDate,
                ItemStatus = Enum.ItemStatus.Available,
                ItemWeight = model.ItemWeight,
                QrCodeImage = $"{model.ItemtName}.png"
                
            };

            var brands = await _brandRepository.GetSelectedBrandsAsync(model.BrandIds);

            foreach (var brand in brands)
            {
                var itembrand = new ItemBrand
                {
                    Brand = brand,
                    BrandId = brand.Id,
                    Item = item,
                    ItemId = item.Id
                };
                item.ItemBrands.Add(itembrand);
            }

            var categories = await _categoryRepository.GetSelectedCategoriesAsync(model.CategoryIds);

            foreach (var category in categories)
            {
                var itemCategory = new ItemCategory
                {
                    Category = category,
                    CategoryId = category.Id,
                    Item = item,
                    ItemId = item.Id
                };
                item.ItemCategories.Add(itemCategory);
            }

            var stocks = await _stockRepository.GetSelectedStocksAsync(model.StockIds);

            foreach(var stock in stocks) 
            {
                var itemStock = new ItemStock 
                { 
                    Stock = stock,
                    StockId = stock.Id,
                    Item = item,
                    ItemId = item.Id
                };
                item.ItemStocks.Add(itemStock);
                
            }

            var itemInfo = await _itemRepository.CreateItemAsync(item);
          
            QRCodeGenerator(item.QrCode, item.ItemtName);
            return new ItemDto
            { 
                ItemtName = itemInfo.ItemtName,
                Description = itemInfo.Description,
                //ItemImage = item.ItemImage,
                ItemStatus = itemInfo.ItemStatus,
                ItemWeight = itemInfo.ItemWeight,
                ExpiryDate = itemInfo.ExpiryDate,
                ManufacturingDate = itemInfo.ManufacturingDate,
                Price = itemInfo.Price,
                QrCode = itemInfo.QrCode,
                QRCodeImage = item.QrCodeImage
                
            };

        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var item = await _itemRepository.GetItemAsync(id);

            item.IsDeleted = true;

            await _itemRepository.UpdateItemAsync(item);
            
            //_itemRepository.DeleteItem(item);

            return true;
        }


        public async Task<IList<ItemDto>> GetAllItemsAsync()
        {
            var item = await _itemRepository.GetAllItemsAsync();
            var items = item.Select(i => new ItemDto
            {
                ItemtName = i.ItemtName,
                ItemStatus = i.ItemStatus,
                Id = i.Id,
                Description = i.Description,
                ExpiryDate = i.ExpiryDate,
                ManufacturingDate = i.ManufacturingDate,
                ItemImage = i.ItemImage,
                Price = i.Price,
                QrCode = i.QrCode,
                ItemWeight = i.ItemWeight


            }).ToList();
            return items;
        }

        public async Task<ItemDto> GetItemAsync(int id)
        {
            var item = await _itemRepository.GetItemAsync(id);
            if (item == null)
            {
                return null;
            }
            return new ItemDto
            {
                Id = item.Id,
                ItemtName = item.ItemtName,
                Description = item.Description,
                ExpiryDate = item.ExpiryDate,
                ManufacturingDate = item.ManufacturingDate,
                ItemImage = item.ItemImage,
                Price = item.Price,
                QrCode = item.QrCode,
                ItemStatus = item.ItemStatus,
                ItemWeight = item.ItemWeight,

                Categories = item.ItemCategories.Select(a => new CategoryDto
                {
                    CategoryName = a.Category.CategoryName,
                    Id = a.CategoryId,
                    Description = a.Category.Description
                    
                }).ToList(),

                Brands = item.ItemBrands.Select(a => new BrandDto
                {
                    BrandName = a.Brand.BrandName,
                    Id = a.BrandId
                    
                }).ToList(),

                Stocks = item.ItemStocks.Select(s => new StockDto 
                { 
                    StockName = s.Stock.StockName,
                    Id = s.StockId
                   
                }).ToList()

            };


        }

        public async Task<ItemDto> GetItemByQRCodeAsync(string qRCode)
        {
            var item = await _itemRepository.GetItemByQRCodeAsync(qRCode);
            if(item == null)
            {
                return null;
            }
            return new ItemDto
            {
                Id = item.Id,
                ItemtName = item.ItemtName,
               // Description = item.Description,
               // ExpiryDate = item.ExpiryDate,
               // ManufacturingDate = item.ManufacturingDate,
                //ItemImage = item.ItemImage,
                Price = item.Price,
               // QrCode = item.QrCode,
               // ItemStatus = item.ItemStatus,
                ItemWeight = item.ItemWeight,
                /*Categories = item.ItemCategories.Select(a => new CategoryDto
                {
                    CategoryName = a.Category.CategoryName,
                    Id = a.CategoryId,
                    Description = a.Category.Description

                }).ToList(),
                Brands = item.ItemBrands.Select(a => new BrandDto
                {
                    BrandName = a.Brand.BrandName,
                    Id = a.BrandId


                }).ToList(),
                Stocks = item.ItemStocks.Select(s => new StockDto
                {
                    StockName = s.Stock.StockName,
                    Id = s.StockId

                }).ToList()*/
            };
        }

        public async Task<ItemDto> GetItemNameAsync(string name)
        {
            var item = await _itemRepository.GetItemNameAsync(name);
            if (item == null)
            {
                return null;
            }
            return new ItemDto
            {
                Id = item.Id,
                ItemtName = item.ItemtName,
                Description = item.Description,
                ExpiryDate = item.ExpiryDate,
                ManufacturingDate = item.ManufacturingDate,
                //ItemImage = item.ItemImage,
                Price = item.Price,
                QrCode = item.QrCode,
                ItemStatus = item.ItemStatus,
                ItemWeight = item.ItemWeight,

                Categories = item.ItemCategories.Select(a => new CategoryDto
                {
                    CategoryName = a.Category.CategoryName,
                    Id = a.CategoryId,
                    Description = a.Category.Description

                }).ToList(),

                Brands = item.ItemBrands.Select(a => new BrandDto
                {
                    BrandName = a.Brand.BrandName,
                    Id = a.BrandId


                }).ToList(),

                Stocks = item.ItemStocks.Select(s => new StockDto
                {
                    StockName = s.Stock.StockName,
                    Id = s.StockId

                }).ToList()

            };
        }

        public async Task<bool> UpdateItemAsync(int id, UpdateItemRequestModel model)
        {
            var item = await _itemRepository.GetItemAsync(id);

            item.ItemtName = model.ItemtName;
            item.ManufacturingDate = model.ManufacturingDate;
            item.ExpiryDate = model.ExpiryDate;
            //item.ItemImage = model.ItemImage;
            item.Price = model.Price;
           // item.QrCode = model.QrCode;
            item.Description = model.Description;
            item.ItemStatus = Enum.ItemStatus.Available;
           // item.QrCodeImage = model.QRCodeImage;
            item.ItemWeight = model.ItemWeight;
            item.QrCodeImage = $"{model.ItemtName}.png";



            await _itemRepository.UpdateItemAsync(item);

            return true;

        }

        public IList<ItemDto> SearchItems(string searchText)
        {
            return _itemRepository.SearchItems(searchText).ToList();
        }


        private void QRCodeGenerator(string qrCode, string itemName)
        {
            var writer = new QRCodeWriter();
            var resultBit = writer.encode(qrCode, BarcodeFormat.QR_CODE, 200, 200);
            var matrix = resultBit;
            int scale = 2;
            Bitmap result = new Bitmap(matrix.Width * scale, matrix.Height * scale);
            for (int x = 0; x < matrix.Height; x++)
            {
                for (int y = 0; y < matrix.Width; y++)
                {
                    Color pixel = matrix[x, y] ? Color.Black : Color.White;
                    for (int i = 0; i < scale; i++)
                        for (int j = 0; j < scale; j++)
                            result.SetPixel(x * scale + i, y * scale + j, pixel);
                }
            }
            string webRootPath = _hostEnvironment.WebRootPath;
            string fileName = $"{itemName}.png";
            result.Save(webRootPath + "\\qrimage\\" + fileName);

        }
    }
}
