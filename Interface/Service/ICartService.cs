using Scanpay.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Service
{
    public interface ICartService
    {
        Task<CartDto> CreatCartAsync(CreateCartRequestModel model);

        Task<bool> UpdateCartAsync( UpdateCartRequestModel model , int id);

        Task<bool> CartUpdateAsync( int id);

        Task<CartDto> GetCartByIdAsync(int id);

        Task<IList<CartDto>> GetAllCartsAsync();

        Task<IList<CartDto>> GetCartsOrderedByDateAsync(DateTime date);

        Task<CartDto> GetCartsByCustomerIdAsync(int customerId);

        Task<bool> DeleteCartAsync(int id);

        
    }
}
