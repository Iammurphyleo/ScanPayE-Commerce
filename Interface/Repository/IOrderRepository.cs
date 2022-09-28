using Scanpay.Dtos;
using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Repository
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);

        Task<Order> UpdateOrderAsync(Order order);

        Task<Order> GetOrderAsync(int id);

        Task<IList<Order>> GetAllOrdersAsync();

        Task<IList<Order>> GetItemsOrderedByDateAsync(DateTime date);

        Task<IList<Order>> GetItemsOrderedByCustomerIdAsync(int customerId);

        Task<IList<Order>> GetNotClearedItemsOrderedByCustomerIdAsync(int customerId);

        Task<IList<Order>> GetItemsOrderedByCustomerEmailAsync(string email);

        Task<Order> GetItemsOrderedByReferenceAsync(string reference);

        //void DeleteOrder(Order order);

        Task<IList<Order>> GetSelectedOrdersAsync(IList<int> ids);


        //Task<IList<Order>> GetSelectedItemsAsync(IList<int> ids);

    }
}
