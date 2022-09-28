using Scanpay.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Service
{
    public interface ICategoryService
    {
       Task<CategoryDto>  AddCategoryAsync(CreateCategoryRequestModel model);

        Task<bool> UpdateCategoryAsync(int id, UpdateCategoryRequestModel model);

        Task<CategoryDto> GetCategoryAsync(int id);

        Task<CategoryDto> GetCategoryByNameAsync(string name);

        Task<IList<CategoryDto>> GetAllCategoriesAsync();

        Task<bool> DeleteCategoryAsync(int id);
    }
}
