using Microsoft.EntityFrameworkCore;
using Scanpay.Contex;
using Scanpay.Dtos;
using Scanpay.Entity;
using Scanpay.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Implementation.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ScanPayContext _context;

        public PaymentRepository(ScanPayContext context)
        {
            _context = context;
        }

        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        /*public void DeletePayment(Payment payment)
        {
            _context.Payments.Remove(payment);
            _context.SaveChanges();

        }*/

        public async Task<IList<Payment>> GetAllPaymentsAsync()
        {
            var payment = await  _context.Payments.Include(p => p.Order).Include(p => p.Customer)

           .Where(p => p.IsDeleted == false).ToListAsync();

            return payment;
        }

        public async Task<Payment> GetPaymentAsync(int id)
        {
            var payment = await _context.Payments.Include(p => p.Order).Include(p => p.Customer)

            .Where(p => p.Id == id && p.IsDeleted == false).SingleOrDefaultAsync();
           
            return payment;
        }

        public async Task<IList<Payment>> GetPaymentByDateAsync(DateTime date)
        {
            var payment = await _context.Payments.Include(p => p.Customer).Include(p => p.Order)
            
            .Where(p => p.Datecreated == date && p.IsDeleted == false).ToListAsync();

            return payment;
        }

        public async Task<IList<Payment>> GetPaymentByCustomerEmailAsync(string email)
        {
            var payment = await _context.Payments.Include(p => p.Customer).Include(p => p.Order)

            .Where(p=>p.Customer.Email == email && p.IsDeleted == false).ToListAsync();

            return payment;
        }

        public async Task<IList<Payment>> GetSelectedPaymentsAsync(IList<int> ids)
        {
            var payment = await _context.Payments.Include(p => p.Order).Include(p => p.Customer)
                
            .Where(p => ids.Contains(p.Id) && p.IsDeleted == false).ToListAsync();

            return payment;
        }

        public async Task<Payment> UpdatePaymentAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<IList<Payment>> GetPaymentByCustomerIdAsync(int customerId)
        {
            var payment = await _context.Payments.Include(p => p.Customer).Include(p => p.Order)

            .Where(p => p.CustomerID == customerId && p.IsDeleted == false).ToListAsync();

            return payment;

        }

        public async Task<Payment> GetPaymentByPaymentReferenceAsync(string reference)
        {
            var payment = await _context.Payments.Include(p => p.Customer).Include(p => p.Order)

            .Where(p => p.PaymentReference == reference && p.IsDeleted == false).SingleOrDefaultAsync();

            return payment;
        }
    }
}
