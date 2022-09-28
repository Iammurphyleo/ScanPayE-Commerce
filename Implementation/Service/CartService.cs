using Scanpay.Dtos;
using Scanpay.Entity;
using Scanpay.Interface.Repository;
using Scanpay.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Implementation.Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IItemRepository _itemRepository;

        public CartService(ICartRepository cartRepository, IItemRepository itemRepository, ICustomerRepository customerRepository)
        {
            _cartRepository = cartRepository;

            _customerRepository = customerRepository;

            _itemRepository = itemRepository;
        }

        public async Task<bool> CartUpdateAsync(int id)
        {  
            var cart = await _cartRepository.GetCartByIdAsync(id);

            cart.IsDeleted = true;

            await _cartRepository.UpdateCartAsync(cart);

            return true;

        }

        public async Task<CartDto> CreatCartAsync(CreateCartRequestModel model)
        {

            var customer = await _customerRepository.GetCustomerAsync(model.CustomerId);

            var carts = await _cartRepository.GetCartsByCustomerIdAsync(model.CustomerId);

            bool itContains = false;

            if (customer.Carts.Where(a => a.IsDeleted == false).Count() == 0)
            {
                var cart = new Cart
                {
                    CustomerId = model.CustomerId,
                    Customer = customer,
                    IsDeleted = false,

                };
                var item = await _itemRepository.GetItemAsync(model.ItemId);
                var cartItem = new CartItem
                {
                    Cart = cart,
                    CartId = cart.Id,
                    Item = item,
                    ItemId = item.Id,
                    ItemQuantity = model.ItemQuantity,
                    ItemWeigth = item.ItemWeight,
                };
                cart.CartItems.Add(cartItem);
                
                var cartInfo = await _cartRepository.CreatCartAsync(cart);
                return new CartDto
                {
                    CustomerId = customer.Id,

                };
            }
             foreach (var items in carts.CartItems)
             {
                    if (items.Item.Id == model.ItemId)
                    {
                        itContains = true;
                        break;
                    }

             }

                if (!itContains)
                {
                    var cart = await _cartRepository.GetCartsByCustomerIdAsync(model.CustomerId);

                    var item = await _itemRepository.GetItemAsync(model.ItemId);

                    var cartItems = new CartItem
                    {
                        Cart = carts,
                        CartId = carts.Id,
                        Item = item,
                        ItemId = item.Id,
                        ItemQuantity = model.ItemQuantity,
                        ItemWeigth = model.ItemQuantity * item.ItemWeight
                    };

                    carts.CartItems.Add(cartItems);
                    var cartInfos = await _cartRepository.UpdateCartAsync(carts);
                
                }

            

            return new CartDto { 
                CustomerId = carts.CustomerId,
                Id = carts.Id,
                
            };

        }   

        public async Task<bool> DeleteCartAsync(int id)
        {
            var cart = await _cartRepository.GetCartByIdAsync(id);

            cart.IsDeleted = true;

            await _cartRepository.UpdateCartAsync(cart);

            //_cartRepository.DeleteCart(cart);

            return true;

        }

        public async Task<IList<CartDto>> GetAllCartsAsync()
        {
            var cart = await _cartRepository.GetAllCartsAsync();

            var carts = cart.Select(c => new CartDto
            {
                Id = c.Id,
                CustomerId = c.CustomerId,

            }).ToList();

            return carts;
        }

        public async Task<CartDto> GetCartByIdAsync(int id)
        {
            var cart = await _cartRepository.GetCartByIdAsync(id);

            return new CartDto
            {
                Id = cart.Id,
                CustomerId = cart.CustomerId,
                Items = cart.CartItems.Select(c => new ItemDto
                {
                    Id = c.Item.Id,
                    ItemtName = c.Item.ItemtName

                }).ToList()
            };

        }

        public async  Task<CartDto> GetCartsByCustomerIdAsync(int customerId)
        {
            var cart = await _cartRepository.GetCartsByCustomerIdAsync(customerId);
            if(cart == null)
            {
                return new CartDto
                {

                };
            }

            return new CartDto
            {
                Id = cart.Id,
                CustomerId = cart.CustomerId,
                Items = cart.CartItems.Select(i => new ItemDto
                {
                    Id = i.Item.Id,
                    ItemtName = i.Item.ItemtName,
                    Price = i.Item.Price,
                    ItemWeight = i.ItemWeigth,
                    CartItemQuantity = i.ItemQuantity,


                }).ToList(),


            };

            

        }

        public async Task<IList<CartDto>> GetCartsOrderedByDateAsync(DateTime date)
        {

            var cart = await _cartRepository.GetCartsOrderedByDateAsync(date);

            var carts = cart.ToList().Select(c => new CartDto
            {
                Id = c.Id,
                CustomerId = c.CustomerId,

                Items = c.CartItems.Select(i => new ItemDto
                {
                    Id = i.Item.Id,
                    ItemtName = i.Item.ItemtName

                }).ToList()

            }).ToList();

            return carts;

        }

        public async Task<bool> UpdateCartAsync(UpdateCartRequestModel model , int id)
        {
            var customer = await _customerRepository.GetCustomerAsync(id);

            //var cart = await _cartRepository.GetCartByIdAsync(model.Id);
            
            foreach(var item in customer.Carts.Where(a => a.IsDeleted == false).FirstOrDefault().CartItems)
            {
                if(item.ItemId == model.Id)
                {
                    item.ItemQuantity = model.ItemQuantity;
                    await _cartRepository.UpdateCartAsync(customer.Carts.LastOrDefault());
                    break;
                }
            }


            return true;
        }
    }
}
