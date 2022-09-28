using Scanpay.Dtos;
using Scanpay.Entity;
using Scanpay.Enum;
using Scanpay.Interface.Repository;
using Scanpay.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Implementation.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository , ICartRepository cartRepository, IItemRepository itemRepository,IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _itemRepository = itemRepository;
            _userRepository = userRepository;
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
        }

        public async Task<OrderDto> CreateOrderForItemAsync(int id)
        {
            //var cart = model.OrderItems.Where(c => c. > 0).ToDictionary(c => c.ItemId, c => c.Quantity);
            var cart = await _cartRepository.GetCartsByCustomerIdAsync(id);
            //  var cartItems = await _itemRepository.GetSelectedItemsInCartAsync(cart);
            var customer = await _customerRepository.GetCustomerAsync(id);
            var customerOrders = await _orderRepository.GetNotClearedItemsOrderedByCustomerIdAsync(customer.Id);
            var orderReference = $"OI{id}{Guid.NewGuid().ToString().Substring(0, 3)}";
            if(customerOrders.Count == 0)
            {
                var order = new Order
                {
                    CustomerID = id,
                    OrderReference = orderReference,

                    OrderStatus = Enum.OrderStatus.Initiate,
                    Datecreated = DateTime.UtcNow,

                    //TotalPrice = model.TotalPrice,

                };

                foreach (var item in cart.CartItems)
                {
                    var itemOrder = new ItemOrder
                    {
                        Item = item.Item,
                        ItemId = item.ItemId,
                        Order = order,
                        OrderId = order.Id,
                        Quantity = item.ItemQuantity,
                        UnitPrice = item.ItemQuantity * item.Item.Price,
                        UnitWeight = item.ItemQuantity * item.Item.ItemWeight,
                    };
                    order.TotalPrice += item.Item.Price * item.ItemQuantity;
                    order.TotalWeight += item.Item.ItemWeight * item.ItemQuantity;
                    order.ItemOrders.Add(itemOrder);
                }

                await _orderRepository.CreateOrderAsync(order);
                return new OrderDto
                {
                    CustomerID = order.CustomerID,
                    OrderReference = order.OrderReference,
                    TotalPrice = order.TotalPrice,
                    Id = order.Id,
                    OrderStatus = order.OrderStatus,
                    Datecreated = order.Datecreated,
                    IsTrue = true

                };

            }


            /*foreach (var item in cartItems)
            {
                var itemOrder = new ItemOrder
                {
                    
                    Item = item,
                    ItemId = item.Id,
                    Order = order,
                    OrderId = order.Id
                };
                item.ItemOrders.Add(itemOrder);
            }

            foreach (var item in cartItems)
            {
                var quantity = cart[item.Id];
                var price = item.Price;
                var itemOrder = new ItemOrder
                {
                    ItemId = item.Id,
                    Quantity = quantity,
                    Order = order,
                    UnitPrice = item.Price,
                    OrderId = order.Id,
                    Item = item
                };
                order.TotalPrice += itemOrder.UnitPrice * itemOrder.Quantity;
                order.ItemOrders.Add(itemOrder);
            }*/



            return new OrderDto
            {
            };

        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _orderRepository.GetOrderAsync(id);

            order.IsDeleted = true;

            await _orderRepository.UpdateOrderAsync(order);
           
           // _orderRepository.DeleteOrder(order);

            return true;

        }

        public async Task<IList<OrderDto>> GetAllOrdersAsync()
        {
            var order = await _orderRepository.GetAllOrdersAsync();

            var orders = order.Select(o => new OrderDto 
            { 
                CustomerID = o.CustomerID,
                Id = o.Id,
                OrderReference = o.OrderReference,
                OrderStatus = o.OrderStatus,
                TotalPrice = o.TotalPrice,
                Datecreated = o.Datecreated

            }).ToList();

            return orders;
        }

        public async Task<OrderDto> GetOrderAsync(int id)
        {
            var order = await _orderRepository.GetOrderAsync(id);

            if(order == null) 
            {
                return null;
            }
            return new OrderDto
            {
                CustomerID = order.CustomerID,
                Id = order.Id,
                OrderReference = order.OrderReference,
                OrderStatus = order.OrderStatus,
                TotalPrice = order.TotalPrice,
                Datecreated = order.Datecreated,
                TotalWeight = order.TotalWeight,
                

                Items = order.ItemOrders.Select(i => new ItemDto 
                { 
                    Id = i.ItemId,
                    ItemtName = i.Item.ItemtName,
                    ItemWeight = i.UnitWeight,
                   Price = i.UnitPrice,
                    ItemPrice = i.Item.Price,
                    QrCode = i.Item.QrCode,
                   CartItemQuantity = i.Quantity,

                                    
                }).ToList()
           
            };

        }

        public async Task<bool> UpdateOrderAsync(int id, OrderStatus status)
        {
            var order = await _orderRepository.GetOrderAsync(id);

            order.OrderStatus = status;

           await _orderRepository.UpdateOrderAsync(order);

            return true;
                
        }

        public async Task<IList<OrderDto>> GetItemsOrderedByDateAsync(DateTime date)
        {
            var order = await _orderRepository.GetItemsOrderedByDateAsync(date);
            var orders = order.ToList().Select(o => new OrderDto
            {
                CustomerID = o.CustomerID,
                Id = o.Id,
                OrderReference = o.OrderReference,
                OrderStatus = o.OrderStatus,
                TotalPrice = o.TotalPrice,
                Datecreated = o.Datecreated,

                Items = o.ItemOrders.Select(i => new ItemDto
                {
                    Id = i.ItemId,
                    ItemtName = i.Item.ItemtName,
                    ItemWeight = i.Item.ItemWeight,
                    Price = i.Item.Price,
                    QrCode = i.Item.QrCode

                }).ToList()

            }).ToList();
            return orders;
        }   
            
            
        public async Task<IList<OrderDto>> GetItemsOrderedByCustomerIdAsync(int customerId)
        {
            var order = await _orderRepository.GetItemsOrderedByCustomerIdAsync(customerId);
            var orders = order.ToList().Select( o => new OrderDto
            {
                CustomerID = o.CustomerID,
                Id = o.Id,
                OrderReference = o.OrderReference,
                OrderStatus = o.OrderStatus,
                TotalPrice = o.TotalPrice,
                Datecreated = o.Datecreated,
                TotalWeight = o.TotalWeight,

                Items = o.ItemOrders.Select(i => new ItemDto
                {
                    Id = i.ItemId,
                    ItemtName = i.Item.ItemtName,
                    ItemWeight = i.UnitWeight,
                    Price = i.UnitPrice,
                    ItemPrice = i.Item.Price,
                    QrCode = i.Item.QrCode,
                    CartItemQuantity = i.Quantity,



                }).ToList()

            }).ToList();
            return orders;
            
        }


        public async Task<IList<OrderDto>> GetNotClearedItemsOrderedByCustomerIdAsync(int customerId) 
        {
            var order = await _orderRepository.GetNotClearedItemsOrderedByCustomerIdAsync(customerId);

            var orders = order.ToList().Select(o => new OrderDto
            {
                CustomerID = o.CustomerID,
                Id = o.Id,
                OrderReference = o.OrderReference,
                OrderStatus = o.OrderStatus,
                TotalPrice = o.TotalPrice,
                Datecreated = o.Datecreated,
                TotalWeight = o.TotalWeight,

                Items = o.ItemOrders.Select(i => new ItemDto
                {
                    Id = i.ItemId,
                    ItemtName = i.Item.ItemtName,
                    ItemWeight = i.UnitWeight,
                    Price = i.UnitPrice,
                    ItemPrice = i.Item.Price,
                    QrCode = i.Item.QrCode,
                    CartItemQuantity = i.Quantity,



                }).ToList()

            }).ToList();
            return orders;
        }


        public async Task<OrderDto> GetItemsOrderedByReferenceAsync(string reference)
        {
            var order = await _orderRepository.GetItemsOrderedByReferenceAsync(reference);
            return new OrderDto
            {
                CustomerID = order.CustomerID,
                Id = order.Id,
                OrderReference = order.OrderReference,
                OrderStatus = order.OrderStatus,
                TotalPrice = order.TotalPrice,
                Datecreated = order.Datecreated,

                Items = order.ItemOrders.Select(i => new ItemDto
                {
                    Id = i.ItemId,
                    ItemtName = i.Item.ItemtName,
                    ItemWeight = i.Item.ItemWeight,
                    Price = i.Item.Price,
                    QrCode = i.Item.QrCode

                }).ToList()

            };       
        }

        public async Task<IList<OrderDto>> GetItemsOrderedByCustomerEmailAsync(string email)
        {
            var order = await _orderRepository.GetItemsOrderedByCustomerEmailAsync(email);

            var orders = order.ToList().Select(o => new OrderDto
            {
                CustomerID = o.CustomerID,
                Id = o.Id,
                OrderReference = o.OrderReference,
                OrderStatus = o.OrderStatus,
                TotalPrice = o.TotalPrice,
                Datecreated = o.Datecreated,
                //CustomerFirstName = o.Customer.FirstName,
               // CustomerLastName = o.Customer.LastName,

                Items = o.ItemOrders.Select(i => new ItemDto
                {
                    Id = i.ItemId,
                    ItemtName = i.Item.ItemtName,
                    ItemWeight = i.Item.ItemWeight,
                    Price = i.Item.Price,
                    QrCode = i.Item.QrCode

                }).ToList()

            }).ToList();
            return orders;


        }
    }
}
