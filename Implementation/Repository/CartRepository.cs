using Microsoft.EntityFrameworkCore;
using Scanpay.Contex;
using Scanpay.Entity;
using Scanpay.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Implementation.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ScanPayContext _context;

        public CartRepository(ScanPayContext context)
        {
            _context = context;
        }

        public async Task<Cart> CreatCartAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);

            await _context.SaveChangesAsync();

            return (cart);


        }

        /*public void DeleteCart(Cart cart)
        {
            _context.Remove(cart);
            _context.SaveChanges();
        }*/

        public async Task<IList<Cart>> GetAllCartsAsync()
        {
            var cart = await _context.Carts.Where(c => c.IsDeleted == false).ToListAsync();

            return cart;
        }

        public async Task<Cart> GetCartByIdAsync(int id)
        {
            var cart = await _context.Carts.Include(c => c.CartItems).ThenInclude(c => c.Item)

            .Where(c => c.Id == id && c.IsDeleted == false).SingleOrDefaultAsync();

            return cart;
        }

        public async Task<Cart> GetCartsByCustomerIdAsync(int customerId)
        {
            var cart = await _context.Carts.Include(a => a.CartItems).ThenInclude(a => a.Item)
                
           .Where(c => c.CustomerId == customerId && c.IsDeleted == false).FirstOrDefaultAsync();

            return cart;
        }

        public async Task<IList<Cart>> GetCartsOrderedByDateAsync(DateTime date)
        {
            var cart = await _context.Carts.Include(c => c.CartItems).ThenInclude(c => c.Item)

            .Where(c => c.Datecreated == date && c.IsDeleted == false).ToListAsync();

            return cart;
        }

        public async Task<IList<Cart>> GetSelectedCartsAsync(IList<int> ids)
        {
            var cart = await _context.Carts.Include(c=>c.CartItems).ThenInclude(c=>c.Item)

            .Where(c => ids.Contains(c.Id) && c.IsDeleted == false).ToListAsync();

            return cart;

        }

        public async Task<Cart> UpdateCartAsync(Cart cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
            return cart;
        }
    }
}
