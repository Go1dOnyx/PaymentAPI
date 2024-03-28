using Microsoft.EntityFrameworkCore;
using ResourceAPI.EF.DbContexts;
using ResourceAPI.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceAPI.EF.Repositories
{
    public class PaymentRepository
    {
        private readonly PaymentsContext _paymentContext;
        public PaymentRepository(PaymentsContext dbContext)
        {
            _paymentContext = dbContext;
        }
        public async Task<Payment> Create(Payment payMethod)
        {
            await _paymentContext.AddAsync(payMethod);
            _paymentContext.SaveChanges();

            return payMethod;
        }
        public async Task<Payment> Update(Payment payment) 
        {
            Payment getPayMethod = await _paymentContext.Payments.FindAsync(payment.PaymentId);

            getPayMethod.PaymentId = payment.PaymentId;
            getPayMethod.UserID = payment.UserID;
            getPayMethod.CardNum = payment.CardNum;
            getPayMethod.CardholderName = payment.CardholderName;
            getPayMethod.ExpirationDate = payment.ExpirationDate;
            getPayMethod.SecurityNum = payment.SecurityNum;
            getPayMethod.Amount = payment.Amount;
            getPayMethod.CardType = payment.CardType;
            getPayMethod.Status = payment.Status;

            _paymentContext.SaveChanges();

            return getPayMethod;
        }
        public async Task<bool> Delete(int payId) 
        {
            Payment delPay = await _paymentContext.Payments.FindAsync(payId);

            if (delPay != null) 
            {
                _paymentContext.Remove(delPay);
                _paymentContext.SaveChanges();

                return true;
            }

            return false;
        }
        public async Task<List<Payment>> GetAllPayments() 
        {
            List<Payment> getPayments = await _paymentContext.Payments.ToListAsync();
            return getPayments;
        }
        public async Task<Payment?> GetPaymentById(int payId) 
        {
            Payment getPay = await _paymentContext.Payments.FindAsync(payId);
            return getPay;
        }
        public async Task<List<Payment>> GetAllFromId(int userId)
        {
            List<Payment> getAllPayments = await _paymentContext.Payments.Where(u => u.UserID == userId).ToListAsync();
            return getAllPayments;
        }
    }
}
