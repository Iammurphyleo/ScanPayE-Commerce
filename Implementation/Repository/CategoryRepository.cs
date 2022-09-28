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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ScanPayContext _context;

        public CategoryRepository(ScanPayContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
           await  _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

       /* public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }*/

        public async Task<IList<Category>> GetAllCategoriesAsync()
        {
            var category = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            return category;
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            var category = await _context.Categories.Include(c => c.ItemCategories)
            
           .ThenInclude(c => c.Item).Where(c => c.Id == id && c.IsDeleted == false).SingleOrDefaultAsync();
           
            return category;
        }

        public async Task<Category> GetCategoryByNameAsync(string name)
        {
            var category = await _context.Categories.Include(c => c.ItemCategories)

            .ThenInclude(c => c.Item).SingleOrDefaultAsync(c=>c.CategoryName == name && c.IsDeleted == false);
           
            return category;


        }

        public async Task<IList<Category>> GetSelectedCategoriesAsync(IList<int> ids)
        {
            var category = await _context.Categories.Include(c => c.ItemCategories)
            
           .ThenInclude(c => c.Item).Where(c => ids.Contains(c.Id) && c.IsDeleted == false).ToListAsync();
           
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
