using Scanpay.Dtos;
using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface
{
    public interface IBrandRepository
    {
        Task<Brand> CreateBrandAsync(Brand brand);

        Task<Brand> UpdateBrandAsync(Brand brand);

        Task<Brand> GetBrandAsync(int id);

        Task<Brand> GetBrandByNameAsync(string name);

        Task<IList<Brand>> GetAllBrandsAsync();

        //void DeleteBrand(Brand brand);

        Task<IList<Brand>> GetSelectedBrandsAsync(IList<int> ids);

    }
}
