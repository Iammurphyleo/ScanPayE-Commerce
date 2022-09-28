using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PayStack.Net;
using Scanpay.Contex;
using Scanpay.Dtos;
using Scanpay.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Scanpay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IPaymentService _paymentService;
        private readonly ICustomerService _customerService;
        private readonly string token;
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
       // private readonly ScanPayContext _context;
        private PayStackApi Paystack { get; set; }

        public PaymentController(IPaymentService paymentService, ICustomerService customerService,
           IOrderService orderService, IConfiguration configuration, ICartService cartService)
        {
            _configuration = configuration;

            _orderService = orderService;

            //_context = scanPayContext;

            _paymentService = paymentService;

            _customerService = customerService;

            _cartService = cartService;

            token = _configuration["Payment:Paystack"];

            Paystack = new PayStackApi(token);


        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreatePaymentForOrder()
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;

            var customer = await _customerService.GetCustomerByEmailAsync(email);
            var orderId = customer.Orders.Last().Id;
            var order = await _orderService.GetOrderAsync(orderId);

            var model = new CreatePaymentRequestModel
            {
                CustomerID = customer.Id,
                OrderId = order.Id,
                OrderReference = order.OrderReference,
                TotalPrice = order.TotalPrice
            };

            
            TransactionInitializeRequest initializeRequest = new()
            {
                AmountInKobo = Convert.ToInt32(order.TotalPrice * 100),
                Email = customer.Email,
                Reference =  $"OI{order.CustomerID}{order.Id}{order.TotalPrice}{Guid.NewGuid().ToString().Substring(0, 3)}",
                Currency = "NGN",
             //   CallbackUrl = "https://localhost:44328/api/payment/verify"
                CallbackUrl = "http://127.0.0.1:5502/Html/Payments/VerifyPayment.html"
            };
            TransactionInitializeResponse initializeResponse = Paystack.Transactions.Initialize(initializeRequest);
            if (initializeResponse.Status )
            {
                await _paymentService.CreatePaymentAsync(model, Enum.PaymentStatus.NotPaid, initializeRequest.Reference);

                var Authorizationurl = new Authorizationurl();
                Authorizationurl.Url = initializeResponse.Data.AuthorizationUrl;

                return Ok(Authorizationurl);
            }
            return BadRequest();       
        }
        [Authorize]
        [HttpGet("Verify/{trxref}")]
        public async Task<IActionResult> Verify([FromRoute] string trxref)
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;

            var userEmail = await _customerService.GetCustomerByEmailAsync(email);

            var pay = await _paymentService.GetPaymentByCustomerIdAsync(userEmail.Id);

            var cart = await _cartService.GetCartsByCustomerIdAsync(userEmail.Id);


            //return Ok(pay);

            TransactionVerifyResponse verifyResponse = Paystack.Transactions.Verify(trxref);

            if (verifyResponse.Data.Status == "success") { 
            
                var payment = await _paymentService.GetPaymentByPaymentReferenceAsync(trxref);
                
                if (payment != null) 
                {
                    UpdatePaymentRequestModel updatePaymentRequestModel = new UpdatePaymentRequestModel
                    {
                        PaymentStatus = Enum.PaymentStatus.Paid,
                    }; 
                    await _paymentService.UpdatePaymentAsync(payment.Id,updatePaymentRequestModel);

                    await _cartService.CartUpdateAsync(cart.Id);

                   // await _orderService.UpdateOrderAsync(payment.OrderId, Enum.OrderStatus.Cleared);
                    
                    return Ok();
                };
                return NotFound();
            }
            return BadRequest();
        }
        [HttpPut("UpdateOrder/{id}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] int id)
        {
            var response = await _orderService.UpdateOrderAsync(id, Enum.OrderStatus.Cleared);

            return Ok(response);
        }

        [HttpDelete("DeletePayment/{id}")]
        public async Task<IActionResult> DeletePayment([FromRoute] int id)
        {
            var payment = await _paymentService.DeletePaymentAsync(id);

            return Ok(payment);
        }

        [HttpGet("PaymentDetailsById/{id}")]
        public async Task<IActionResult> PaymentDetailsById(int id)
        {
            var payment = await _paymentService.GetPaymentAsync(id);

            return Ok(payment);
        }

        [HttpGet("PaymentDetailsByDate/{date}")]
        public async Task<IActionResult> PaymentDetailsByDate([FromRoute] DateTime date)
        {
            var payment = await _paymentService.GetPaymentByDateAsync(date);

            return Ok(payment);
        }

        [HttpGet("PaymentDetailsByCustomerEmail/{email}")]
        public async Task<IActionResult> PaymentDetailsByCustomerEmail([FromRoute]string email)
        {
            var payment = await _paymentService.GetPaymentByCustomerEmailAsync(email);

            return Ok(payment);
        }

        [HttpGet("PaymentDetailsByCustomerId/{customerId}")]
        public async Task<IActionResult> PaymentDetailsByCustomerId([FromRoute] int customerId) 
        {
            var payment = await _paymentService.GetPaymentByCustomerIdAsync(customerId);

            return Ok(payment);
        }

        [HttpGet("PaymentDetailsByPaymentReference/{reference}")]
        public async Task<IActionResult> GetPaymentByPaymentReferenceAsync(string reference) 
        {
            var payment = await _paymentService.GetPaymentByPaymentReferenceAsync(reference);

            return Ok(payment);
        }

        [HttpGet]
        public async Task<IActionResult> AllPaymentDetails() 
        {
            var payment = await _paymentService.GetAllPaymentsAsync();

            return Ok(payment);
        }

        [HttpPut("UpdatePayment/{id}")]
        public async Task<IActionResult> UpdatePayment([FromRoute]int id, [FromBody]UpdatePaymentRequestModel model) 
        {
            var payment = await _paymentService.UpdatePaymentAsync(id, model);

            return Ok(payment);
        }
    
    
    
    }
}
