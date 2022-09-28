using Microsoft.EntityFrameworkCore;
using Scanpay.Contex;
using Scanpay.Dtos;
using Scanpay.Entity;
using Scanpay.Enum;
using Scanpay.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Implementation.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ScanPayContext _context;

        public OrderRepository(ScanPayContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
           await _context.SaveChangesAsync();
            return order;

        }

        /*public void DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }*/

        public async Task<IList<Order>> GetAllOrdersAsync()
        {
            var order = await _context.Orders.Where(o => o.IsDeleted == false).ToListAsync();
            return order;
        }

        public async Task<IList<Order>> GetItemsOrderedByCustomerIdAsync(int customerId)
        {
            var order = await _context.Orders.Include(o => o.ItemOrders)

            .ThenInclude(o => o.Item).Where(o => o.CustomerID == customerId && o.IsDeleted == false).ToListAsync();
            
            return order;
           
        }


        public async Task<IList<Order>> GetNotClearedItemsOrderedByCustomerIdAsync(int customerId)
        {
            var order = await _context.Orders.Include(o => o.ItemOrders)

            .ThenInclude(o => o.Item).Where(o => o.CustomerID == customerId && 

            o.OrderStatus == Enum.OrderStatus.Initiate && o.IsDeleted == false).ToListAsync();

            return order;

        }


        public async Task<IList<Order>> GetItemsOrderedByCustomerEmailAsync(string email)
        {
            var order = await _context.Orders.Include(o=>o.Customer).Include(o => o.ItemOrders).ThenInclude(o => o.Item)

            .Where(o => o.Customer.Email == email && o.IsDeleted == false).ToListAsync();

            return order;

        }

        public async Task<IList<Order>> GetItemsOrderedByDateAsync(DateTime date)
        {
            var order = await _context.Orders.Include(o => o.ItemOrders)

            .ThenInclude(o => o.Item).Where(o => o.Datecreated == date && o.IsDeleted == false).ToListAsync();
            
            return order;
        }

        public async Task<Order> GetItemsOrderedByReferenceAsync(string reference)
        {
            var order = await  _context.Orders.Include(o => o.ItemOrders)

            .ThenInclude(o => o.Item).Where(o => o.OrderReference == reference &&
            
            o.IsDeleted == false).SingleOrDefaultAsync();
            
            return order;
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            var order = await _context.Orders.Include(o=>o.ItemOrders)
            
            .ThenInclude(o=>o.Item).Where(o => o.Id == id && o.IsDeleted == false).SingleOrDefaultAsync();
            
            return order;
        }

        public async Task<IList<Order>> GetSelectedOrdersAsync(IList<int> ids)
        {
            var order = await _context.Orders.Include(o => o.ItemOrders)

            .ThenInclude(o => o.Item).Where(o => ids.Contains(o.Id) && o.IsDeleted == false).ToListAsync();
            
            return order;
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
