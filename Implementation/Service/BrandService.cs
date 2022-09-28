using Scanpay.Dtos;
using Scanpay.Entity;
using Scanpay.Interface;
using Scanpay.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Implementation.Service
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<BrandDto> AddBrandAsync(CreateBrandRequestModel model)
        {
            var brand = new Brand
            {
                BrandName = model.BrandName
                               
            };
               var brandInfo = await _brandRepository.CreateBrandAsync(brand);
            return new BrandDto
            {
                BrandName = brandInfo.BrandName,
                Id = brandInfo.Id

            };
        }

        public async Task<bool> DeleteBrandAsync(int id)
        {
            var brand = await _brandRepository.GetBrandAsync(id);

            brand.IsDeleted = true;

            await _brandRepository.UpdateBrandAsync(brand);
             
            //_brandRepository.DeleteBrand(brand);
            return true;
        }

        public async Task<IList<BrandDto>> GetAllBrandsAsync()
        {
            var brand = await _brandRepository.GetAllBrandsAsync();
            var brands = brand.Select(b => new BrandDto 
            { 
                BrandName = b.BrandName,
                Id = b.Id,
                                             
            }).ToList();

            return brands;
        }

        public async Task<BrandDto> GetBrandAsync(int id)
        {
            var brand = await _brandRepository.GetBrandAsync(id);
            return new BrandDto 
            { 
                Id = brand.Id,
                BrandName = brand.BrandName,

                Items = brand.ItemBrands.Select(i=>new ItemDto
                {
                    Id = i.Item.Id,
                    ItemtName = i.Item.ItemtName,
                    
                }).ToList()
            };
        }

        public async Task<BrandDto> GetBrandByNameAsync(string name)
        {
            var brand = await _brandRepository.GetBrandByNameAsync(name);
            return new BrandDto
            {
                Id = brand.Id,
                BrandName = brand.BrandName,

                Items = brand.ItemBrands.Select(i => new ItemDto
                {
                    Id = i.Item.Id,
                    ItemtName = i.Item.ItemtName,

                }).ToList()
            };
        }

        public async Task<bool> UpdateBrandAsync(int id, UpdateBrandRequestModel model)
        {
            var brand = await _brandRepository.GetBrandAsync(id);

            brand.BrandName = model.BrandName;

           await  _brandRepository.UpdateBrandAsync(brand);

            return true;

        }
    }
}
