using Scanpay.Dtos;
using Scanpay.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Service
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderForItemAsync(int CustomerId);

        Task<bool> UpdateOrderAsync(int id, OrderStatus status);

        Task<OrderDto> GetOrderAsync(int id);

        Task<IList<OrderDto>> GetAllOrdersAsync();

        Task<IList<OrderDto>> GetItemsOrderedByDateAsync(DateTime date);

        Task<IList<OrderDto>> GetItemsOrderedByCustomerIdAsync(int customerId);

        Task<IList<OrderDto>> GetNotClearedItemsOrderedByCustomerIdAsync(int customerId);

        Task<IList<OrderDto>> GetItemsOrderedByCustomerEmailAsync(string email);

        Task<OrderDto> GetItemsOrderedByReferenceAsync(string reference);

        Task<bool> DeleteOrderAsync(int id);
    }
    

    

    

}

