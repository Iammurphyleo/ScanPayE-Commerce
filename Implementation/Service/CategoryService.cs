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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> AddCategoryAsync(CreateCategoryRequestModel model)
        {
            var category = new Category
            { 
                CategoryName = model.CategoryName,
                
                Description = model.Description
                    
            };
            var newCategory = await _categoryRepository.CreateCategoryAsync(category);

            return new CategoryDto 
            { 
                CategoryName = newCategory.CategoryName,

                Description = newCategory.Description,

                Id = newCategory.Id
                
            };
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id);

            category.IsDeleted = true;

            await _categoryRepository.UpdateCategoryAsync(category);
          
            //_categoryRepository.DeleteCategory(category);

            return true;

        }

        public async Task<IList<CategoryDto>> GetAllCategoriesAsync()
        {
            var category = await _categoryRepository.GetAllCategoriesAsync(); 

            var categories = category.Select(c => new CategoryDto 
            { 
                CategoryName = c.CategoryName,
                Id = c.Id,
                Description = c.Description
            }).ToList();

            return categories;
        }

        public async Task<CategoryDto> GetCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id);
            return new CategoryDto
            { Id = category.Id,
                CategoryName = category.CategoryName,
                Description = category.Description,

                Items = category.ItemCategories.Select(i => new ItemDto 
                { 
                    Id = i.Item.Id,
                    ItemtName = i.Item.ItemtName

                }).ToList()
            };
        }

        public async Task<CategoryDto> GetCategoryByNameAsync(string name)
        {
            var category = await _categoryRepository.GetCategoryByNameAsync(name);
            return new CategoryDto
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                Description = category.Description,

                Items = category.ItemCategories.Select(c=> new ItemDto 
                { 
                    Id = c.Item.Id,
                    ItemtName = c.Item.ItemtName

                }).ToList()
            };
        }

        public async Task<bool> UpdateCategoryAsync(int id, UpdateCategoryRequestModel model)
        {
            var category = await _categoryRepository.GetCategoryAsync(id);

            category.CategoryName = model.CategoryName;
            category.Description = model.Description;

           await  _categoryRepository.UpdateCategoryAsync(category);

            return true;


        }
    }
}
