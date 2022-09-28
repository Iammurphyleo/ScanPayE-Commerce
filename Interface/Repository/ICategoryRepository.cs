using Scanpay.Dtos;
using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategoryAsync(Category category);

        Task<Category> UpdateCategoryAsync(Category category);

        Task<Category> GetCategoryAsync(int id);

        Task<Category> GetCategoryByNameAsync(string name);

        Task<IList<Category>> GetAllCategoriesAsync();

        //void DeleteCategory(Category category);

        Task<IList<Category>> GetSelectedCategoriesAsync(IList<int> ids);
    }
}
