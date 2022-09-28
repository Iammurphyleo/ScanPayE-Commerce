using Scanpay.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Service
{
    public interface IBrandService
    {
        Task<BrandDto> AddBrandAsync(CreateBrandRequestModel model);

        Task<bool> UpdateBrandAsync(int id, UpdateBrandRequestModel model);

        Task<BrandDto> GetBrandAsync(int id);

        Task<BrandDto> GetBrandByNameAsync(string name);

        Task<IList<BrandDto>> GetAllBrandsAsync();

        Task<bool> DeleteBrandAsync(int id);
    }
}
