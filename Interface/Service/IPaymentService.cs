using Scanpay.Dtos;
using Scanpay.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Service
{
    public interface IPaymentService
    {
       Task<PaymentDto>  CreatePaymentAsync(CreatePaymentRequestModel model, PaymentStatus paymentStatus, string reference);

        Task<bool> UpdatePaymentAsync(int id, UpdatePaymentRequestModel model);

        Task<PaymentDto> GetPaymentAsync(int id);

        Task<IList<PaymentDto>> GetPaymentByCustomerEmailAsync(string email);

        Task<IList<PaymentDto>> GetPaymentByCustomerIdAsync(int CustomerId);

        Task<IList<PaymentDto>> GetPaymentByDateAsync(DateTime date);

        Task<PaymentDto> GetPaymentByPaymentReferenceAsync(string reference);

        Task<IList<PaymentDto>> GetAllPaymentsAsync();

        Task<bool> DeletePaymentAsync(int id);
    }
}
