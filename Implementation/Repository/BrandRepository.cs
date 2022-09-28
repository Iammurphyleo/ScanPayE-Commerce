using Microsoft.EntityFrameworkCore;
using Scanpay.Contex;
using Scanpay.Entity;
using Scanpay.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Implementation.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ScanPayContext _context;

        public BrandRepository(ScanPayContext context)
        {
            _context = context;
        }

        public async Task<Brand> CreateBrandAsync(Brand brand)
        {
           await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
                return brand;
        }

        /*public void DeleteBrand(Brand brand)
        {
            _context.Remove(brand);
            _context.SaveChanges();
        }*/

        public async Task<IList<Brand>> GetAllBrandsAsync()
        {
            var brand = await _context.Brands.Where(o => o.IsDeleted == false).ToListAsync();
            return brand;
            
        }

        public async Task<Brand> GetBrandAsync(int id)
        {
            var brand = await _context.Brands.Include(s => s.ItemBrands).ThenInclude(s => s.Item)
           
            .Where(s => s.Id == id && s.IsDeleted == false).SingleOrDefaultAsync();
            
            return brand;
           
        }

        public async Task<Brand> GetBrandByNameAsync(string name)
        {
            var brand = await _context.Brands.Include(s => s.ItemBrands).ThenInclude(s => s.Item)
           
           .SingleOrDefaultAsync(s => s.BrandName == name && s.IsDeleted == false);
            
            return brand;
        }

        public async Task<IList<Brand>> GetSelectedBrandsAsync(IList<int> ids)
        {
            var brand = await _context.Brands.Include(b=>b.ItemBrands).ThenInclude(b=>b.Item)
           
            .Where(b => ids.Contains(b.Id) && b.IsDeleted == false).ToListAsync();
            
            return brand;
        }

        public async Task<Brand> UpdateBrandAsync(Brand brand)
        {
             _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
            return brand;
        }
    }

    
    
}
