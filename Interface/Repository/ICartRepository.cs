
using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Repository
{
    public interface ICartRepository
    {
        Task<Cart> CreatCartAsync(Cart cart);

        Task<Cart> UpdateCartAsync(Cart cart);

        Task<Cart> GetCartByIdAsync(int id);

        Task<IList<Cart>> GetAllCartsAsync();

        Task<IList<Cart>> GetCartsOrderedByDateAsync(DateTime date);

        Task<Cart> GetCartsByCustomerIdAsync(int customerId);

        //void DeleteCart(Cart cart);

        Task<IList<Cart>> GetSelectedCartsAsync(IList<int> ids);


        //Task<IList<Order>> GetSelectedItemsAsync(IList<int> ids);

    }
}

