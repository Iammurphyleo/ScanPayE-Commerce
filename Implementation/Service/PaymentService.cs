using Microsoft.AspNetCore.Hosting;
using Scanpay.Dtos;
using Scanpay.Entity;
using Scanpay.Enum;
using Scanpay.Interface.Repository;
using Scanpay.Interface.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using ZXing;
using ZXing.QrCode;

namespace Scanpay.Implementation.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
       // private readonly IWebHostEnvironment _hostEnvironment;
        //private readonly ICustomerRepository _customerRepository;
        //private readonly IOrderRepository _orderRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;


            
        }

        public async Task<PaymentDto> CreatePaymentAsync(CreatePaymentRequestModel model, PaymentStatus paymentStatus, 
            string reference)
        {
            
            var payment = new Payment
            {
                CustomerID = model.CustomerID,
                OrderId = model.OrderId,
                TotalPrice = model.TotalPrice,
                PaymentStatus = paymentStatus,
                PaymentReference = reference,
                Datecreated = DateTime.UtcNow,
                
                //PayStackReference = payStackReference,
            };
            await _paymentRepository.CreatePaymentAsync(payment);
            

            return new PaymentDto 
            { 
                CustomerID = payment.CustomerID,
                Datecreated = payment.Datecreated,
                PaymentReference = payment.PaymentReference,
                OrderId = payment.OrderId,
                OrderReference = payment.Order.OrderReference,
                PaymentStatus = payment.PaymentStatus,
                TotalPrice = payment.TotalPrice,
                Id = payment.Id,
                               
            };

        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            var payment = await _paymentRepository.GetPaymentAsync(id);

            payment.IsDeleted = true;

            await _paymentRepository.UpdatePaymentAsync(payment);

           // _paymentRepository.DeletePayment(payment);

            return true;
        }

        public async Task<IList<PaymentDto>> GetAllPaymentsAsync()
        {
            var payment = await _paymentRepository.GetAllPaymentsAsync();

            var payments = payment.Select(p => new PaymentDto 
            { 
                CustomerID = p.CustomerID,
                OrderId = p.OrderId,
                TotalPrice = p.TotalPrice,
                PaymentStatus = p.PaymentStatus,
                //CustomerFirstName = p.Customer.FirstName,
                //CustomerLastName = p.Customer.LastName,
                OrderReference = p.Order.OrderReference, 
                PaymentReference = p.PaymentReference,
                Datecreated = p.Datecreated,
                Id = p.Id
                
                      
            }).ToList();

            return payments;
        }

        public async  Task<PaymentDto> GetPaymentAsync(int id)
        {
            var payment = await _paymentRepository.GetPaymentAsync(id);

            if (payment == null) 
            {
                return null;
            }

            return new PaymentDto
            {
                CustomerID = payment.CustomerID,
                OrderId = payment.OrderId,
                PaymentStatus = payment.PaymentStatus,
                TotalPrice = payment.TotalPrice,
                //CustomerFirstName = payment.Customer.FirstName,
                //CustomerLastName = payment.Customer.LastName,
                OrderReference = payment.Order.OrderReference,
                Datecreated = payment.Datecreated,
                Id = payment.Id,
                PaymentReference = payment.PaymentReference
                
                  
            };

        }

        public async Task<IList<PaymentDto>> GetPaymentByDateAsync(DateTime date)
        {
            var payment = await _paymentRepository.GetPaymentByDateAsync(date);

            if (payment == null)
            {
                return null;
            }

            var payments = payment.ToList().Select(p => new PaymentDto
            {
                Datecreated = p.Datecreated,
               // CustomerFirstName = p.Customer.FirstName,
               // CustomerLastName = p.Customer.LastName,
                CustomerID = p.CustomerID,
                PaymentStatus = p.PaymentStatus,
                TotalPrice = p.TotalPrice,
                OrderId = p.OrderId,
                OrderReference = p.Order.OrderReference,
                Id = p.Id,
                PaymentReference = p.PaymentReference

            }).ToList();

            return payments;
        }

        public async Task<IList<PaymentDto>> GetPaymentByCustomerEmailAsync(string email)
        {
            var payment = await _paymentRepository.GetPaymentByCustomerEmailAsync(email);

            if (payment == null)
            {
                return null;
            }

            var payments = payment.ToList().Select(p => new PaymentDto
            {
                Datecreated = p.Datecreated,
               // CustomerFirstName = p.Customer.FirstName,
               // CustomerLastName = p.Customer.LastName,
                CustomerID = p.CustomerID,
                PaymentStatus = p.PaymentStatus,
                TotalPrice = p.TotalPrice,
                OrderId = p.OrderId,
                OrderReference = p.Order.OrderReference,
                PaymentReference = p.PaymentReference

            }).ToList();

            return payments;
        }

        public async Task<bool> UpdatePaymentAsync(int id, UpdatePaymentRequestModel model)
        {
            var payment = await _paymentRepository.GetPaymentAsync(id);

            payment.PaymentStatus = model.PaymentStatus;

            await _paymentRepository.UpdatePaymentAsync(payment);

            return true;


        }

        public async Task<IList<PaymentDto>> GetPaymentByCustomerIdAsync(int CustomerId)
        {
            var payment = await _paymentRepository.GetPaymentByCustomerIdAsync(CustomerId);

            if (payment == null)
            {
                return null;
            }

            var payments = payment.ToList().Select(p => new PaymentDto
            {
                Datecreated = p.Datecreated,
                // CustomerFirstName = p.Customer.FirstName,
                // CustomerLastName = p.Customer.LastName,
                CustomerID = p.CustomerID,
                PaymentStatus = p.PaymentStatus,
                TotalPrice = p.TotalPrice,
                OrderId = p.OrderId,
                OrderReference = p.Order.OrderReference,
                PaymentReference = p.PaymentReference,
                Id = p.Id

            }).ToList();

            return payments;



        }

        public async Task<PaymentDto> GetPaymentByPaymentReferenceAsync(string reference)
        {
            var payment = await _paymentRepository.GetPaymentByPaymentReferenceAsync(reference);

            if (payment == null)
            {
                return null;
            }

            return new PaymentDto
            {
                Id = payment.Id,
                CustomerID = payment.CustomerID,
                OrderId = payment.OrderId,
                PaymentStatus = payment.PaymentStatus,
                TotalPrice = payment.TotalPrice,
                //CustomerFirstName = payment.Customer.FirstName,
                //CustomerLastName = payment.Customer.LastName,
                OrderReference = payment.Order.OrderReference,
                Datecreated = payment.Datecreated,
                PaymentReference = payment.PaymentReference,
                //PayStackReference = payment.PayStackReference,
                
            };
        
        }


        


    }
}
