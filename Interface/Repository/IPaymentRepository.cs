using Scanpay.Dtos;
using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Repository
{
    public interface IPaymentRepository
    {
        Task<Payment> CreatePaymentAsync(Payment payment);

        Task<Payment> UpdatePaymentAsync(Payment payment);

        Task<Payment> GetPaymentAsync(int id);

        Task<IList<Payment>> GetPaymentByCustomerEmailAsync(string email);

        Task<IList<Payment>> GetPaymentByCustomerIdAsync(int customerId);

        Task<IList<Payment>> GetPaymentByDateAsync(DateTime date);

        Task<Payment> GetPaymentByPaymentReferenceAsync(string reference);

        Task<IList<Payment>> GetAllPaymentsAsync();

        Task<IList<Payment>> GetSelectedPaymentsAsync(IList<int> ids);

        //void DeletePayment(Payment payment);

    }
}
